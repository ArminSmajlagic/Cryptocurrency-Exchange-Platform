using modeli.trading.Dashboard;
using modeli.trading.Trading;
using System.Data;
using winforms.trading.Servisi;


namespace winforms.trading.UserControls.Administration
{
    public partial class ReportingControl : UserControl
    {
        private APIServis<Report> reportingServis = null;

        private Report report = null;

        private List<cbFilterItem> cbItems = null;
        public ReportingControl()
        {
            InitializeComponent();

            LoadServices();

            loadFilter();

            LoadData();
        }



        private async void LoadData()
        {
            if(report == null)
                report = new Report();

            report = await reportingServis.Get<Report>();

            var data1 = report.narudzbe.OrderByDescending(x => x.cijena).ToList();

            dgvTopNarudzbe.AutoGenerateColumns = false;
            dgvTopNarudzbe.DataSource = data1;


            var data2 = report.users.OrderByDescending(x => x.stanje_walleta).ToList();

            dgvTopKorisnici.AutoGenerateColumns = false;
            dgvTopKorisnici.DataSource = data2;


            var data3 = report.valute.OrderBy(x => x.rank).ToList();

            dgvNajKripto.AutoGenerateColumns = false;
            dgvNajKripto.DataSource = data3;

            var data4 = report.novoRegistrovani.ToList();

            dgvNoviKorisnici.AutoGenerateColumns = false;
            dgvNoviKorisnici.DataSource = data4;
        }


        private async void LoadServices()
        {
            reportingServis = new APIServis<Report>("Dashboard/GetReport");
        }

        private void loadFilter()
        {
            cbItems = new List<cbFilterItem>() {
                new cbFilterItem(){
                    naziv = "Sve",
                    vrjednost = 1
                },
                new cbFilterItem(){
                    naziv = "Top Korisnici",
                    vrjednost = 2
                },
                new cbFilterItem(){
                    naziv = "Top Narudžbe",
                    vrjednost = 3
                },

            };

            cbTabele.DataSource = cbItems;

            cbTabele.ValueMember = "vrjednost";
            cbTabele.DisplayMember = "naziv";
        }

        private void btnFiltriraj_Click(object sender, EventArgs e)
        {
            DateTime _od = dtpStart.Value;

            DateTime _do = dtpEnd.Value;

            cbFilterItem _tabela = cbItems[cbTabele.SelectedIndex];

            if (_tabela.vrjednost == 1 || _tabela.vrjednost == 2)
            {
                var korisnici = report.users.Where(x => x.datum_kreiranja >= _od && x.datum_kreiranja <= _do).ToList();
                dgvTopKorisnici.DataSource = korisnici;
            }


            if (_tabela.vrjednost == 1 || _tabela.vrjednost == 3)
            {
                var narudzbe = report.narudzbe.Where(x => x.kreirana >= _od && x.kreirana <= _do).ToList();
                dgvTopNarudzbe.DataSource = narudzbe;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var korisnici = report.users.ToList();
            dgvTopKorisnici.DataSource = korisnici;

            var narudzbe = report.narudzbe.ToList();
            dgvTopNarudzbe.DataSource = narudzbe;
        }
    }

    class cbFilterItem
    {
        public string naziv { get; set; }
        public int vrjednost { get; set; }
    }
}
