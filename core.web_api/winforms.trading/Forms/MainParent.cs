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
using winforms.trading.UserControls;
using winforms.trading.UserControls.Administration;


namespace winforms.trading.Forms
{
    public partial class MainParent : Form
    {
        List<UserControl> userControls = null;

        private readonly AuthServis authServis;
        private readonly NavigationServis navigationServis;

        public MainParent()
        {
            authServis = new AuthServis();
            navigationServis = new NavigationServis();
            InitializeComponent();
            initUserControls();
            mainPanelOnMainForm.Controls.Add(navigationServis.mainDisplayPanel);
            navigationServis.Navigate(userControls[0]);
        }    

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            navigationServis.Navigate(new HomeControl());
        }

        //private void btnKripto_Click(object sender, EventArgs e)
        //{
        //    navigationServis.Navigate(new MainKriptoPanel());
        //}

        //private void btnWallet_Click(object sender, EventArgs e)
        //{
        //    navigationServis.Navigate(new WalletControl(navigationServis));
        //}

        //private void btnKorisnik_Click(object sender, EventArgs e)
        //{
        //    navigationServis.Navigate(new KorisnikControl());
        //}


        private void initUserControls()
        {
            userControls = new List<UserControl>();
            //userControls.Add(new HomeControl());
            //userControls.Add(new MainKriptoPanel());
            //userControls.Add(new WalletControl(navigationServis));
            //userControls.Add(new KorisnikControl());
            //userControls.Add(new KorisnikControl());
            userControls.Add(new PregledKorisnikaControl());
        }

        private async void logout(object sender, EventArgs e)
        {
            var response = await authServis.Logout();

            if (response)
            {
                Auth auth = new Auth();
                auth.Show();
                this.Hide();
            }
        }

        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            navigationServis.Navigate(new PregledKorisnikaControl());
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            navigationServis.Navigate(new OrderBookControl());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            navigationServis.Navigate(new ReportingControl());
        }
    }
}
