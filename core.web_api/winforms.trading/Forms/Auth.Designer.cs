namespace winforms.trading.Forms
{
    partial class Auth
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Exit = new System.Windows.Forms.Button();
            this.prijava = new System.Windows.Forms.Button();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPasscode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.registracija = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.registracijaPanel = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbDrzava = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbBrojTelefona = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRepeatLozinka = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLozinka = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbUsernameReg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.register = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.verifyPanel = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loginPanel.SuspendLayout();
            this.registracijaPanel.SuspendLayout();
            this.verifyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Azure;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Exit.ForeColor = System.Drawing.Color.Red;
            this.Exit.Location = new System.Drawing.Point(760, 28);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(40, 37);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "X";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // prijava
            // 
            this.prijava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prijava.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prijava.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.prijava.ForeColor = System.Drawing.Color.White;
            this.prijava.Location = new System.Drawing.Point(346, 361);
            this.prijava.Name = "prijava";
            this.prijava.Size = new System.Drawing.Size(107, 37);
            this.prijava.TabIndex = 6;
            this.prijava.Text = "Login";
            this.prijava.UseVisualStyleBackColor = true;
            this.prijava.Click += new System.EventHandler(this.prijava_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.LightCyan;
            this.tbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbUsername.Location = new System.Drawing.Point(295, 197);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(221, 34);
            this.tbUsername.TabIndex = 7;
            // 
            // tbPasscode
            // 
            this.tbPasscode.BackColor = System.Drawing.Color.LightCyan;
            this.tbPasscode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPasscode.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPasscode.Location = new System.Drawing.Point(295, 274);
            this.tbPasscode.MaxLength = 16;
            this.tbPasscode.Name = "tbPasscode";
            this.tbPasscode.PasswordChar = '*';
            this.tbPasscode.Size = new System.Drawing.Size(221, 34);
            this.tbPasscode.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(295, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(295, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lozinka";
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.loginPanel.Controls.Add(this.label4);
            this.loginPanel.Controls.Add(this.registracija);
            this.loginPanel.Controls.Add(this.linkLabel1);
            this.loginPanel.Controls.Add(this.label3);
            this.loginPanel.Controls.Add(this.tbPasscode);
            this.loginPanel.Controls.Add(this.Exit);
            this.loginPanel.Controls.Add(this.prijava);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.tbUsername);
            this.loginPanel.Controls.Add(this.label1);
            this.loginPanel.Controls.Add(this.label14);
            this.loginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginPanel.Location = new System.Drawing.Point(0, 0);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(837, 490);
            this.loginPanel.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(46, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Dont have an account?";
            // 
            // registracija
            // 
            this.registracija.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registracija.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.registracija.ForeColor = System.Drawing.Color.MidnightBlue;
            this.registracija.Location = new System.Drawing.Point(83, 295);
            this.registracija.Name = "registracija";
            this.registracija.Size = new System.Drawing.Size(86, 35);
            this.registracija.TabIndex = 14;
            this.registracija.Text = "Register";
            this.registracija.UseVisualStyleBackColor = true;
            this.registracija.Click += new System.EventHandler(this.registracija_click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(647, 440);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(153, 15);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Zaboravili ste vašu lozinku ?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans MT", 39.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(57, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 74);
            this.label3.TabIndex = 11;
            this.label3.Text = "Logos";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Light", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(318, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(177, 72);
            this.label14.TabIndex = 35;
            this.label14.Text = "Prijava";
            // 
            // registracijaPanel
            // 
            this.registracijaPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.registracijaPanel.Controls.Add(this.label21);
            this.registracijaPanel.Controls.Add(this.label16);
            this.registracijaPanel.Controls.Add(this.label15);
            this.registracijaPanel.Controls.Add(this.label13);
            this.registracijaPanel.Controls.Add(this.tbDrzava);
            this.registracijaPanel.Controls.Add(this.label12);
            this.registracijaPanel.Controls.Add(this.tbBrojTelefona);
            this.registracijaPanel.Controls.Add(this.label11);
            this.registracijaPanel.Controls.Add(this.tbEmail);
            this.registracijaPanel.Controls.Add(this.label10);
            this.registracijaPanel.Controls.Add(this.tbIme);
            this.registracijaPanel.Controls.Add(this.label9);
            this.registracijaPanel.Controls.Add(this.tbRepeatLozinka);
            this.registracijaPanel.Controls.Add(this.label8);
            this.registracijaPanel.Controls.Add(this.tbLozinka);
            this.registracijaPanel.Controls.Add(this.label6);
            this.registracijaPanel.Controls.Add(this.tbUsernameReg);
            this.registracijaPanel.Controls.Add(this.label7);
            this.registracijaPanel.Controls.Add(this.register);
            this.registracijaPanel.Controls.Add(this.button1);
            this.registracijaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registracijaPanel.Location = new System.Drawing.Point(0, 0);
            this.registracijaPanel.Name = "registracijaPanel";
            this.registracijaPanel.Size = new System.Drawing.Size(837, 490);
            this.registracijaPanel.TabIndex = 16;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI Light", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label21.Location = new System.Drawing.Point(46, 165);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(145, 72);
            this.label21.TabIndex = 37;
            this.label21.Text = "Logo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(12, 276);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(208, 15);
            this.label16.TabIndex = 36;
            this.label16.Text = "World\'s best app for analysis and trading.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(68, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 15);
            this.label15.TabIndex = 35;
            this.label15.Text = "Welcome to Logo.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(346, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(286, 55);
            this.label13.TabIndex = 34;
            this.label13.Text = "Registracija";
            // 
            // tbDrzava
            // 
            this.tbDrzava.BackColor = System.Drawing.Color.LightCyan;
            this.tbDrzava.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDrzava.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbDrzava.Location = new System.Drawing.Point(539, 302);
            this.tbDrzava.Name = "tbDrzava";
            this.tbDrzava.Size = new System.Drawing.Size(221, 34);
            this.tbDrzava.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(539, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 21);
            this.label12.TabIndex = 33;
            this.label12.Text = "Država";
            // 
            // tbBrojTelefona
            // 
            this.tbBrojTelefona.BackColor = System.Drawing.Color.LightCyan;
            this.tbBrojTelefona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBrojTelefona.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbBrojTelefona.Location = new System.Drawing.Point(539, 216);
            this.tbBrojTelefona.Name = "tbBrojTelefona";
            this.tbBrojTelefona.Size = new System.Drawing.Size(221, 34);
            this.tbBrojTelefona.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(539, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 21);
            this.label11.TabIndex = 31;
            this.label11.Text = "Broj telefona";
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.Color.LightCyan;
            this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbEmail.Location = new System.Drawing.Point(539, 137);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(221, 34);
            this.tbEmail.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(539, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 21);
            this.label10.TabIndex = 29;
            this.label10.Text = "Email";
            // 
            // tbIme
            // 
            this.tbIme.BackColor = System.Drawing.Color.LightCyan;
            this.tbIme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIme.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbIme.Location = new System.Drawing.Point(261, 137);
            this.tbIme.Name = "tbIme";
            this.tbIme.Size = new System.Drawing.Size(221, 34);
            this.tbIme.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(261, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 21);
            this.label9.TabIndex = 27;
            this.label9.Text = "Ime i prezime";
            // 
            // tbRepeatLozinka
            // 
            this.tbRepeatLozinka.BackColor = System.Drawing.Color.LightCyan;
            this.tbRepeatLozinka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRepeatLozinka.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbRepeatLozinka.Location = new System.Drawing.Point(261, 391);
            this.tbRepeatLozinka.Name = "tbRepeatLozinka";
            this.tbRepeatLozinka.PasswordChar = '*';
            this.tbRepeatLozinka.Size = new System.Drawing.Size(221, 34);
            this.tbRepeatLozinka.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(261, 359);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 21);
            this.label8.TabIndex = 25;
            this.label8.Text = "Ponovi lozinku";
            // 
            // tbLozinka
            // 
            this.tbLozinka.BackColor = System.Drawing.Color.LightCyan;
            this.tbLozinka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLozinka.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbLozinka.Location = new System.Drawing.Point(261, 302);
            this.tbLozinka.Name = "tbLozinka";
            this.tbLozinka.PasswordChar = '*';
            this.tbLozinka.Size = new System.Drawing.Size(221, 34);
            this.tbLozinka.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(261, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "Lozinka";
            // 
            // tbUsernameReg
            // 
            this.tbUsernameReg.BackColor = System.Drawing.Color.LightCyan;
            this.tbUsernameReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsernameReg.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbUsernameReg.Location = new System.Drawing.Point(261, 216);
            this.tbUsernameReg.Name = "tbUsernameReg";
            this.tbUsernameReg.Size = new System.Drawing.Size(221, 34);
            this.tbUsernameReg.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(261, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Username";
            // 
            // register
            // 
            this.register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.register.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.register.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.register.Location = new System.Drawing.Point(601, 390);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(86, 35);
            this.register.TabIndex = 18;
            this.register.Text = "Register";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(760, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 37);
            this.button1.TabIndex = 17;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.registracija_exit_click);
            // 
            // verifyPanel
            // 
            this.verifyPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.verifyPanel.Controls.Add(this.label23);
            this.verifyPanel.Controls.Add(this.label22);
            this.verifyPanel.Controls.Add(this.label20);
            this.verifyPanel.Controls.Add(this.label17);
            this.verifyPanel.Controls.Add(this.btnVerify);
            this.verifyPanel.Controls.Add(this.tbCode);
            this.verifyPanel.Controls.Add(this.label19);
            this.verifyPanel.Controls.Add(this.label18);
            this.verifyPanel.Controls.Add(this.label5);
            this.verifyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verifyPanel.Location = new System.Drawing.Point(0, 0);
            this.verifyPanel.Name = "verifyPanel";
            this.verifyPanel.Size = new System.Drawing.Size(837, 490);
            this.verifyPanel.TabIndex = 37;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(83, 303);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(167, 20);
            this.label23.TabIndex = 32;
            this.label23.Text = "where sky is not a limit !";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Light", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label22.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label22.Location = new System.Drawing.Point(413, 60);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(294, 81);
            this.label22.TabIndex = 31;
            this.label22.Text = "Verifikacija";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.ForeColor = System.Drawing.SystemColors.Window;
            this.label20.Location = new System.Drawing.Point(441, 279);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(138, 17);
            this.label20.TabIndex = 30;
            this.label20.Text = "Enter your code here :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(24, 270);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(291, 20);
            this.label17.TabIndex = 29;
            this.label17.Text = "Welcome to the wold of trading with Logo";
            // 
            // btnVerify
            // 
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(441, 354);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(223, 43);
            this.btnVerify.TabIndex = 28;
            this.btnVerify.Text = "Verify your account";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // tbCode
            // 
            this.tbCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCode.Location = new System.Drawing.Point(441, 305);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(223, 29);
            this.tbCode.TabIndex = 27;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.SystemColors.Window;
            this.label19.Location = new System.Drawing.Point(485, 216);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(159, 25);
            this.label19.TabIndex = 26;
            this.label19.Text = "check your inbox.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(393, 184);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(362, 25);
            this.label18.TabIndex = 25;
            this.label18.Text = "You have recived your code in your email,";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(83, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 81);
            this.label5.TabIndex = 23;
            this.label5.Text = "Logo";
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 490);
            this.ControlBox = false;
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.registracijaPanel);
            this.Controls.Add(this.verifyPanel);
            this.Name = "Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.registracijaPanel.ResumeLayout(false);
            this.registracijaPanel.PerformLayout();
            this.verifyPanel.ResumeLayout(false);
            this.verifyPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button Exit;
        private Button prijava;
        private TextBox tbUsername;
        private TextBox tbPasscode;
        private Label label1;
        private Label label2;
        public Panel loginPanel;
        private LinkLabel linkLabel1;
        private Label label3;
        private Label label4;
        private Button registracija;
        private Panel registracijaPanel;
        private Label label5;
        private TextBox tbLozinka;
        private Label label6;
        private TextBox tbUsernameReg;
        private Label label7;
        private Button register;
        private Button button1;
        private TextBox tbIme;
        private Label label9;
        private TextBox tbRepeatLozinka;
        private Label label8;
        private TextBox tbEmail;
        private Label label10;
        private Label label13;
        private TextBox tbDrzava;
        private Label label12;
        private TextBox tbBrojTelefona;
        private Label label11;
        private Label label14;
        private Label label16;
        private Label label15;
        private Panel verifyPanel;
        private Label label20;
        private Label label17;
        private Button btnVerify;
        private TextBox tbCode;
        private Label label19;
        private Label label18;
        private Label label21;
        private Label label23;
        private Label label22;
    }
}