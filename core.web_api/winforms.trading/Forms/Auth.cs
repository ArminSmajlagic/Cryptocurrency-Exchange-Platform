using modeli.trading.Security.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winforms.trading.LocalStorage;
using winforms.trading.Servisi;

namespace winforms.trading.Forms
{
    public partial class Auth : Form
    {
        private readonly AuthServis authServis;
        public Auth()
        {
            authServis = new AuthServis();
            InitializeComponent();
            loginPanel.Show();
            registracijaPanel.Show();
            verifyPanel.Hide();

        }

        private async void prijava_Click(object sender, EventArgs e)
        {

            var request = new LoginRequest() { username = tbUsername.Text, lozinka = tbPasscode.Text };

            var response = await authServis.Login(request);

            if (response)
            {
                this.Hide();

                MainParent home = new MainParent();
                home.Show();
            }
            else
            {
                tbUsername.Text = "";
                tbPasscode.Text = "";
            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void registracija_click(object sender, EventArgs e)
        {
            registracijaPanel.Show();
            loginPanel.Hide();
        }

        private void registracija_exit_click(object sender, EventArgs e)
        {
            registracijaPanel.Hide();
            loginPanel.Show();
        }

        private async void register_Click(object sender, EventArgs e)
        {
            var request = new RegisterRequest() { username = tbUsernameReg.Text, lozinka = tbLozinka.Text,broj_telefona= tbBrojTelefona.Text,drzava=tbDrzava.Text,email = tbEmail.Text,ime_prezime=tbIme.Text,spol=1 };

            var response = await authServis.Registracija(request);

            if (response)
            {
                registracijaPanel.Hide();
                verifyPanel.Show();
            }
            else
            {
                tbUsernameReg.Clear();
                tbRepeatLozinka.Clear();
                tbLozinka.Clear();
                tbEmail.Clear();
                tbBrojTelefona.Clear();
                tbDrzava.Clear();
                tbIme.Clear();
            }

        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            var response = await authServis.Verifikacija(new modeli.trading.Security.Requests.ConfirmationRequest() { 
                code = tbCode.Text,
                user_id = DataStorage.user_id
            });

            if (response)
            {
                this.Hide();

                MainParent home = new MainParent();
                home.Show();
            }
            else
            {
                tbCode.Text = "";
            }
        }
    }
}
