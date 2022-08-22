using modeli.trading.Trading;
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

namespace winforms.trading.UserControls.Administration
{
    public partial class OrderBookControl : UserControl
    {
        private APIServis<Narudzba> servis = null;
        private APIServis<int> servisNarudzbiOdbij = null;
       

        private List<Narudzba> narudzbe = null;
        public OrderBookControl()
        {
            InitializeComponent();

            servis = new APIServis<Narudzba>("Narudzba/Forms");

            narudzbe= new List<Narudzba>();
            LoadData();

            cbTip.SelectedItem = "Sve";
        }

        private async void LoadData()
        {
            dgvOrders.DataSource = null;
            narudzbe = await servis.Get<List<Narudzba>>();

            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = narudzbe;

            DataGridViewButtonColumn btn = (DataGridViewButtonColumn)dgvOrders.Columns[6];

            btn.DefaultCellStyle.BackColor = Color.PaleVioletRed;
        }

        private void valutaChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbValuta.Text))
            {
                dgvOrders.DataSource = narudzbe;
            }
            else
            {
                var tempData = narudzbe.Where(x => x.valutaNaziv.ToLower().Contains(tbValuta.Text.ToLower())).ToList();

                dgvOrders.DataSource = tempData;
            }
        }

        private void korisnikChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbKorisnik.Text))
            {
                dgvOrders.DataSource = narudzbe;
            }
            else
            {
                var tempData = narudzbe.Where(x => x.userIme.ToLower().Contains(tbKorisnik.Text.ToLower())).ToList();

                dgvOrders.DataSource = tempData;

            }
        }

        private void cbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTip.SelectedIndex == 0)
            {
                dgvOrders.AutoGenerateColumns = false;
                dgvOrders.DataSource = narudzbe;
            }
            else
            {
                var tempData = narudzbe.Where(x => x.tip == cbTip.SelectedIndex - 1).ToList();

                dgvOrders.DataSource = tempData;
            }

        }

        private async void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                var narudzba = narudzbe[e.RowIndex];
                servisNarudzbiOdbij = new APIServis<int>("Narudzba/Odbij");

                await servisNarudzbiOdbij.GetById<int>(narudzba.id);
                LoadData();

            }
        }
    }
}
