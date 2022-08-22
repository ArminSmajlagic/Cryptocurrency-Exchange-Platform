using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winforms.trading.Servisi;
using winforms.trading.UserControls.Wallet.Servisi;

namespace winforms.trading.UserControls.Administration
{
    public partial class PregledKorisnikaControl : UserControl
    {
        private readonly APIServis<modeli.trading.User.User> korisnikServis = null;
        private readonly WalletServis walletServis;

        private List<modeli.trading.User.User> korisnici = null;
        private modeli.trading.User.User korisnik = null;

        public PregledKorisnikaControl()
        {
            InitializeComponent();

            korisnici = new List<modeli.trading.User.User>();
            korisnikServis = new APIServis<modeli.trading.User.User>("user");
            walletServis = new WalletServis();

            LoadData();

            if(korisnik == null)
            {
                panelStats.Visible = false;
                panelDetalji.Visible = false;
                dgvHistorijaTransakcija.Visible = false;
            }
        }

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTrazi.Text))
            {
                dgvListaKorisnika.DataSource = korisnici;
            }
            else
            {
                var search = tbTrazi.Text.ToLower();

                var searchKorisnici = korisnici.Where(x => x.ime_prezime.ToLower().Contains(search)).ToList();

                dgvListaKorisnika.DataSource = searchKorisnici;
            }
        }

        private async void LoadData()
        {
            korisnici = await korisnikServis.Get<List<modeli.trading.User.User>>();

            dgvListaKorisnika.AutoGenerateColumns = false;
            dgvListaKorisnika.DataSource = korisnici;

        }

        private async void LoadDetalji(int id)
        {
            dgvHistorijaTransakcija.DataSource = new List<object>();
            walletServis.assets = null;
            walletServis.walletTransactions = null;
            walletServis.wallet = null;

            korisnik = korisnici[id];

            //load personal information

            //korisnik = await korisnikServis.GetById<modeli.trading.User.User>(id);

            lblEmail.Text = "Email : "+ korisnik.email;
            lblImePrezime.Text = "Ime prezime : " + korisnik.ime_prezime;
            lblDrzava.Text = "Drzava : " + korisnik.drzava;
            lblBrojTelefona.Text = "Broj tel. : " + korisnik.broj_telefona;
            lblUsername.Text = "Username : " + korisnik.ime_prezime;

            //load crypto assets



            if (korisnik != null)
            {
                await walletServis.getWalletData(korisnik.user_id);

                panelStats.Visible = true;
                panelDetalji.Visible = true;
                dgvHistorijaTransakcija.Visible = true;
            }

            if (walletServis.assets != null)
            {           
                foreach (var item in walletServis.assets)
                {
                    if (item.naziv_valute == "Bitcoin")
                        lblBtc.Text = item.naziv_valute + " : " + Math.Round(item.kolicina_valute, 4);

                    if (item.naziv_valute == "SHIB")
                        lblShib.Text = item.naziv_valute + " : " + Math.Round(item.kolicina_valute, 4);

                    if (item.naziv_valute == "Ethereum")
                        lblEth.Text = item.naziv_valute + " : " + Math.Round(item.kolicina_valute, 4);

                    if (item.naziv_valute == "WCash")
                        lblCash.Text = item.naziv_valute + " : " + Math.Round(item.kolicina_valute, 4);
                }
            }


            if (lblBtc.Text == "default")
                lblBtc.Text = "Bitcoin : 0";

            if (lblShib.Text == "default")
                lblShib.Text = "Shiba : 0";

            if (lblEth.Text == "default")
                lblEth.Text = "Ethereum : 0";

            if (lblCash.Text == "default")
                lblCash.Text = "LCash : 0";

            //load history data
            if (walletServis.wallet != null) { 
            var result = await walletServis.getTransactionData();
            var rows = new List<tableRow>();
            var metoda = "";
            var tip = "";


                if (walletServis.walletTransactions != null)
                {

                    foreach (var item in walletServis.walletTransactions)
                    {
                        if (item.tip_metode_id == 0)
                            metoda = "bank_transfer";
                        else if (item.tip_metode_id == 1)
                            metoda = "kartica";
                        else if (item.tip_metode_id == 2)
                            metoda = "paypal";
                        else
                            metoda = "cryptoNetwork";

                        if (item.tip_transakcije_id == 0)
                            tip = "depozit";
                        else
                            tip = "withdraw";


                        rows.Add(new tableRow()
                        {
                            kolicina_valute = item.wcash,
                            naziv_valute = item.naziv_valute,
                            kolicina_transakcije = item.kolicina_transakcije,
                            vrijeme_obavljanja = item.vrijeme_obavljanja.ToString(),
                            tip = tip,
                            metoda = metoda
                        });
                    }

                    if (result)
                    {
                        dgvHistorijaTransakcija.DataSource = rows;

                        foreach (DataGridViewColumn item in dgvHistorijaTransakcija.Columns)
                        {
                            item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }

                //load stats
                if (rows.Count > 1)
                {

                    var depozit = rows.Where(x => x.tip == "depozit");
                    var withdraw = rows.Where(x => x.tip == "withdraw");

                    if (depozit.Count() > 0)
                    {
                        lblTopUplata.Text = "Najveca ostvarena uplata : " + depozit.Max(x => x.kolicina_transakcije).ToString() + " WCASH";
                        lblAvgUplata.Text = "AVG. uplata : " + depozit.Average(x => x.kolicina_transakcije).ToString() + " WCASH";
                        lblTotalUplata.Text = "Ukupan broj uplata : " + depozit.Count().ToString();
                    }
                    else
                    {
                        lblTopUplata.Text = "Najveca ostvarena isplata : " + 0 + " WCASH";
                        lblAvgUplata.Text = "AVG. isplata : " + 0 + " WCASH";
                        lblTotalUplata.Text = "Ukupan broj isplata : " + 0;
                    }
                    
                    if(withdraw.Count() > 0)
                    {
                        lblTopIsplata.Text = "Najveca ostvarena isplata : " + withdraw.Max(x => x.kolicina_transakcije).ToString() + " WCASH";
                        lblAvgIsplata.Text = "AVG. isplata : " + withdraw.Average(x => x.kolicina_transakcije).ToString() + " WCASH";
                        lblTotalIsplata.Text = "Ukupan broj isplata : " + withdraw.Count().ToString();
                    }
                    else
                    {
                        lblTopIsplata.Text = "Najveca ostvarena isplata : " + 0 + " WCASH";
                        lblAvgIsplata.Text = "AVG. isplata : " + 0 + " WCASH";
                        lblTotalIsplata.Text = "Ukupan broj isplata : "+ 0;
                    }

                    lblTotalTransakcija.Text = "Ukupan broj svih transakcija :" + rows.Count.ToString();
                }
                else if(rows.Count == 1)
                {
                    
                    
                    if(rows[0].tip == "withdraw")
                    {
                        lblTopIsplata.Text = "Najveca ostvarena prodaja :" + rows[0].kolicina_transakcije.ToString() + " WCASH";
                        lblAvgUplata.Text = "AVG. prodaja :" + rows[0].kolicina_transakcije.ToString() + " WCASH";
                        lblTotalUplata.Text = "Ukupan broj prodaja :" + 1;

                        lblTopUplata.Text = "Najveca ostvarena prodaja :" + 0 + " WCASH";
                        lblAvgIsplata.Text = "AVG. prodaja :" + 0 + " WCASH";
                        lblTotalIsplata.Text = "Ukupan broj prodaja :" + 0;
                    }
                    else
                    {
                        lblTopUplata.Text = "Najveca ostvarena prodaja :" + rows[0].kolicina_transakcije.ToString() + " WCASH";
                        lblAvgIsplata.Text = "AVG. prodaja :" + rows[0].kolicina_transakcije.ToString() + " WCASH";
                        lblTotalIsplata.Text = "Ukupan broj prodaja :" + 1;

                        lblTopIsplata.Text = "Najveca ostvarena prodaja :" + 0 + " WCASH";
                        lblAvgUplata.Text = "AVG. prodaja :" + 0 + " WCASH";
                        lblTotalUplata.Text = "Ukupan broj prodaja :" + 0;
                    }

                    lblTotalTransakcija.Text = "Ukupan broj svih transakcija :" + 1;
                }
                else
                {
                    dgvHistorijaTransakcija.DataSource = null;

                    lblTopIsplata.Text = "Najveca ostvarena prodaja :" + 0 + " WCASH";
                    lblAvgUplata.Text = "AVG. prodaja :" + 0 + " WCASH";
                    lblTotalUplata.Text = "Ukupan broj prodaja :" + 0;
                    lblTopUplata.Text = "Najveca ostvarena prodaja :" + 0 + " WCASH";
                    lblAvgIsplata.Text = "AVG. prodaja :" + 0 + " WCASH";
                    lblTotalIsplata.Text = "Ukupan broj prodaja :" + 0;

                    lblTotalTransakcija.Text = "Ukupan broj svih transakcija :" + 0;

                }
            }

        }

        private void dgvListaKorisnika_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                LoadDetalji(e.RowIndex);
            }
        }
    }
    public class tableRow
    {
        public string naziv_valute { get; set; }
        public double kolicina_transakcije { get; set; }
        public double kolicina_valute { get; set; }
        public string vrijeme_obavljanja { get; set; }
        public string tip { get; set; }
        public string metoda { get; set; }
    }
}
