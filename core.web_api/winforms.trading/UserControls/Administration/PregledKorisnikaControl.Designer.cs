namespace winforms.trading.UserControls.Administration
{
    partial class PregledKorisnikaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbTrazi = new System.Windows.Forms.TextBox();
            this.dgvListaKorisnika = new System.Windows.Forms.DataGridView();
            this.user_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ime_prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stanje_walleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.details = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDetalji = new System.Windows.Forms.Panel();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblShib = new System.Windows.Forms.Label();
            this.lblEth = new System.Windows.Forms.Label();
            this.lblBtc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDrzava = new System.Windows.Forms.Label();
            this.lblBrojTelefona = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblImePrezime = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvHistorijaTransakcija = new System.Windows.Forms.DataGridView();
            this.naziv_valute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicina_valute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicina_transakcije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vrijeme_obavljanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblTotalTransakcija = new System.Windows.Forms.Label();
            this.lblAvgUplata = new System.Windows.Forms.Label();
            this.lblAvgIsplata = new System.Windows.Forms.Label();
            this.lblTotalIsplata = new System.Windows.Forms.Label();
            this.lblTotalUplata = new System.Windows.Forms.Label();
            this.lblTopIsplata = new System.Windows.Forms.Label();
            this.lblTopUplata = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaKorisnika)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDetalji.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorijaTransakcija)).BeginInit();
            this.panelStats.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbTrazi
            // 
            this.tbTrazi.Location = new System.Drawing.Point(21, 34);
            this.tbTrazi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTrazi.Name = "tbTrazi";
            this.tbTrazi.Size = new System.Drawing.Size(231, 23);
            this.tbTrazi.TabIndex = 0;
            // 
            // dgvListaKorisnika
            // 
            this.dgvListaKorisnika.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvListaKorisnika.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaKorisnika.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.user_ID,
            this.ime_prezime,
            this.username,
            this.stanje_walleta,
            this.details});
            this.dgvListaKorisnika.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaKorisnika.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvListaKorisnika.Location = new System.Drawing.Point(3, 79);
            this.dgvListaKorisnika.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListaKorisnika.Name = "dgvListaKorisnika";
            this.dgvListaKorisnika.RowHeadersWidth = 51;
            this.dgvListaKorisnika.RowTemplate.Height = 29;
            this.dgvListaKorisnika.Size = new System.Drawing.Size(457, 476);
            this.dgvListaKorisnika.TabIndex = 1;
            this.dgvListaKorisnika.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaKorisnika_CellContentClick);
            // 
            // user_ID
            // 
            this.user_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.user_ID.DataPropertyName = "user_ID";
            this.user_ID.HeaderText = "ID";
            this.user_ID.MinimumWidth = 6;
            this.user_ID.Name = "user_ID";
            // 
            // ime_prezime
            // 
            this.ime_prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ime_prezime.DataPropertyName = "ime_prezime";
            this.ime_prezime.HeaderText = "Ime i Prezime";
            this.ime_prezime.MinimumWidth = 6;
            this.ime_prezime.Name = "ime_prezime";
            // 
            // username
            // 
            this.username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.username.DataPropertyName = "ime_prezime";
            this.username.HeaderText = "Korisnicko Ime";
            this.username.MinimumWidth = 6;
            this.username.Name = "username";
            // 
            // stanje_walleta
            // 
            this.stanje_walleta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stanje_walleta.DataPropertyName = "stanje_walleta";
            this.stanje_walleta.HeaderText = "Balans";
            this.stanje_walleta.MinimumWidth = 6;
            this.stanje_walleta.Name = "stanje_walleta";
            // 
            // details
            // 
            this.details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.details.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.details.HeaderText = "Detalji";
            this.details.MinimumWidth = 6;
            this.details.Name = "details";
            this.details.Text = "Detalji";
            this.details.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(466, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(562, 476);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji Korisnika";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDetalji, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelStats, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDetalji
            // 
            this.panelDetalji.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDetalji.Controls.Add(this.lblCash);
            this.panelDetalji.Controls.Add(this.lblShib);
            this.panelDetalji.Controls.Add(this.lblEth);
            this.panelDetalji.Controls.Add(this.lblBtc);
            this.panelDetalji.Controls.Add(this.label3);
            this.panelDetalji.Controls.Add(this.lblDrzava);
            this.panelDetalji.Controls.Add(this.lblBrojTelefona);
            this.panelDetalji.Controls.Add(this.lblEmail);
            this.panelDetalji.Controls.Add(this.lblImePrezime);
            this.panelDetalji.Controls.Add(this.lblUsername);
            this.panelDetalji.Controls.Add(this.label2);
            this.panelDetalji.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetalji.Location = new System.Drawing.Point(3, 2);
            this.panelDetalji.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDetalji.Name = "panelDetalji";
            this.panelDetalji.Size = new System.Drawing.Size(550, 146);
            this.panelDetalji.TabIndex = 0;
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCash.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCash.Location = new System.Drawing.Point(323, 104);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(67, 22);
            this.lblCash.TabIndex = 14;
            this.lblCash.Text = "default";
            // 
            // lblShib
            // 
            this.lblShib.AutoSize = true;
            this.lblShib.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblShib.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblShib.Location = new System.Drawing.Point(323, 78);
            this.lblShib.Name = "lblShib";
            this.lblShib.Size = new System.Drawing.Size(67, 22);
            this.lblShib.TabIndex = 13;
            this.lblShib.Text = "default";
            // 
            // lblEth
            // 
            this.lblEth.AutoSize = true;
            this.lblEth.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEth.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblEth.Location = new System.Drawing.Point(323, 52);
            this.lblEth.Name = "lblEth";
            this.lblEth.Size = new System.Drawing.Size(67, 22);
            this.lblEth.TabIndex = 12;
            this.lblEth.Text = "default";
            // 
            // lblBtc
            // 
            this.lblBtc.AutoSize = true;
            this.lblBtc.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBtc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblBtc.Location = new System.Drawing.Point(323, 27);
            this.lblBtc.Name = "lblBtc";
            this.lblBtc.Size = new System.Drawing.Size(67, 22);
            this.lblBtc.TabIndex = 11;
            this.lblBtc.Text = "default";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(323, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kripto novcanik";
            // 
            // lblDrzava
            // 
            this.lblDrzava.AutoSize = true;
            this.lblDrzava.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDrzava.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDrzava.Location = new System.Drawing.Point(3, 128);
            this.lblDrzava.Name = "lblDrzava";
            this.lblDrzava.Size = new System.Drawing.Size(67, 22);
            this.lblDrzava.TabIndex = 9;
            this.lblDrzava.Text = "default";
            // 
            // lblBrojTelefona
            // 
            this.lblBrojTelefona.AutoSize = true;
            this.lblBrojTelefona.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBrojTelefona.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblBrojTelefona.Location = new System.Drawing.Point(3, 104);
            this.lblBrojTelefona.Name = "lblBrojTelefona";
            this.lblBrojTelefona.Size = new System.Drawing.Size(67, 22);
            this.lblBrojTelefona.TabIndex = 8;
            this.lblBrojTelefona.Text = "default";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblEmail.Location = new System.Drawing.Point(3, 78);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(67, 22);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "default";
            // 
            // lblImePrezime
            // 
            this.lblImePrezime.AutoSize = true;
            this.lblImePrezime.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImePrezime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblImePrezime.Location = new System.Drawing.Point(3, 52);
            this.lblImePrezime.Name = "lblImePrezime";
            this.lblImePrezime.Size = new System.Drawing.Size(67, 22);
            this.lblImePrezime.TabIndex = 6;
            this.lblImePrezime.Text = "default";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUsername.Location = new System.Drawing.Point(3, 27);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(67, 22);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "default";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Licni podaci";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvHistorijaTransakcija);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 152);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 146);
            this.panel2.TabIndex = 1;
            // 
            // dgvHistorijaTransakcija
            // 
            this.dgvHistorijaTransakcija.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvHistorijaTransakcija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorijaTransakcija.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.naziv_valute,
            this.kolicina_valute,
            this.kolicina_transakcije,
            this.tip,
            this.vrijeme_obavljanja});
            this.dgvHistorijaTransakcija.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorijaTransakcija.Location = new System.Drawing.Point(0, 0);
            this.dgvHistorijaTransakcija.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvHistorijaTransakcija.Name = "dgvHistorijaTransakcija";
            this.dgvHistorijaTransakcija.RowHeadersWidth = 51;
            this.dgvHistorijaTransakcija.RowTemplate.Height = 29;
            this.dgvHistorijaTransakcija.Size = new System.Drawing.Size(550, 146);
            this.dgvHistorijaTransakcija.TabIndex = 0;
            // 
            // naziv_valute
            // 
            this.naziv_valute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.naziv_valute.DataPropertyName = "naziv_valute";
            this.naziv_valute.HeaderText = "Valuta";
            this.naziv_valute.MinimumWidth = 6;
            this.naziv_valute.Name = "naziv_valute";
            // 
            // kolicina_valute
            // 
            this.kolicina_valute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kolicina_valute.DataPropertyName = "kolicina_valute";
            this.kolicina_valute.HeaderText = "Kolicina";
            this.kolicina_valute.MinimumWidth = 6;
            this.kolicina_valute.Name = "kolicina_valute";
            // 
            // kolicina_transakcije
            // 
            this.kolicina_transakcije.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kolicina_transakcije.DataPropertyName = "kolicina_transakcije";
            this.kolicina_transakcije.HeaderText = "Iznos";
            this.kolicina_transakcije.MinimumWidth = 6;
            this.kolicina_transakcije.Name = "kolicina_transakcije";
            // 
            // tip
            // 
            this.tip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tip.DataPropertyName = "tip";
            this.tip.HeaderText = "Tip";
            this.tip.MinimumWidth = 6;
            this.tip.Name = "tip";
            // 
            // vrijeme_obavljanja
            // 
            this.vrijeme_obavljanja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vrijeme_obavljanja.DataPropertyName = "vrijeme_obavljanja";
            this.vrijeme_obavljanja.HeaderText = "Vrijeme";
            this.vrijeme_obavljanja.MinimumWidth = 6;
            this.vrijeme_obavljanja.Name = "vrijeme_obavljanja";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelStats.Controls.Add(this.lblTotalTransakcija);
            this.panelStats.Controls.Add(this.lblAvgUplata);
            this.panelStats.Controls.Add(this.lblAvgIsplata);
            this.panelStats.Controls.Add(this.lblTotalIsplata);
            this.panelStats.Controls.Add(this.lblTotalUplata);
            this.panelStats.Controls.Add(this.lblTopIsplata);
            this.panelStats.Controls.Add(this.lblTopUplata);
            this.panelStats.Controls.Add(this.label4);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStats.Location = new System.Drawing.Point(3, 302);
            this.panelStats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(550, 146);
            this.panelStats.TabIndex = 2;
            // 
            // lblTotalTransakcija
            // 
            this.lblTotalTransakcija.AutoSize = true;
            this.lblTotalTransakcija.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalTransakcija.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTotalTransakcija.Location = new System.Drawing.Point(382, 119);
            this.lblTotalTransakcija.Name = "lblTotalTransakcija";
            this.lblTotalTransakcija.Size = new System.Drawing.Size(67, 22);
            this.lblTotalTransakcija.TabIndex = 21;
            this.lblTotalTransakcija.Text = "default";
            // 
            // lblAvgUplata
            // 
            this.lblAvgUplata.AutoSize = true;
            this.lblAvgUplata.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAvgUplata.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAvgUplata.Location = new System.Drawing.Point(382, 67);
            this.lblAvgUplata.Name = "lblAvgUplata";
            this.lblAvgUplata.Size = new System.Drawing.Size(67, 22);
            this.lblAvgUplata.TabIndex = 20;
            this.lblAvgUplata.Text = "default";
            // 
            // lblAvgIsplata
            // 
            this.lblAvgIsplata.AutoSize = true;
            this.lblAvgIsplata.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAvgIsplata.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAvgIsplata.Location = new System.Drawing.Point(381, 33);
            this.lblAvgIsplata.Name = "lblAvgIsplata";
            this.lblAvgIsplata.Size = new System.Drawing.Size(67, 22);
            this.lblAvgIsplata.TabIndex = 19;
            this.lblAvgIsplata.Text = "default";
            // 
            // lblTotalIsplata
            // 
            this.lblTotalIsplata.AutoSize = true;
            this.lblTotalIsplata.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalIsplata.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTotalIsplata.Location = new System.Drawing.Point(3, 125);
            this.lblTotalIsplata.Name = "lblTotalIsplata";
            this.lblTotalIsplata.Size = new System.Drawing.Size(67, 22);
            this.lblTotalIsplata.TabIndex = 18;
            this.lblTotalIsplata.Text = "default";
            // 
            // lblTotalUplata
            // 
            this.lblTotalUplata.AutoSize = true;
            this.lblTotalUplata.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalUplata.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTotalUplata.Location = new System.Drawing.Point(3, 95);
            this.lblTotalUplata.Name = "lblTotalUplata";
            this.lblTotalUplata.Size = new System.Drawing.Size(67, 22);
            this.lblTotalUplata.TabIndex = 17;
            this.lblTotalUplata.Text = "default";
            // 
            // lblTopIsplata
            // 
            this.lblTopIsplata.AutoSize = true;
            this.lblTopIsplata.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTopIsplata.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTopIsplata.Location = new System.Drawing.Point(3, 64);
            this.lblTopIsplata.Name = "lblTopIsplata";
            this.lblTopIsplata.Size = new System.Drawing.Size(67, 22);
            this.lblTopIsplata.TabIndex = 16;
            this.lblTopIsplata.Text = "default";
            // 
            // lblTopUplata
            // 
            this.lblTopUplata.AutoSize = true;
            this.lblTopUplata.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTopUplata.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTopUplata.Location = new System.Drawing.Point(3, 33);
            this.lblTopUplata.Name = "lblTopUplata";
            this.lblTopUplata.Size = new System.Drawing.Size(67, 22);
            this.lblTopUplata.TabIndex = 15;
            this.lblTopUplata.Text = "default";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Statistika transakcija";
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(283, 33);
            this.btnTrazi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(82, 22);
            this.btnTrazi.TabIndex = 4;
            this.btnTrazi.Text = "Traži";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvListaKorisnika, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86272F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.13728F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1031, 557);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.tbTrazi);
            this.panel4.Controls.Add(this.btnTrazi);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(457, 73);
            this.panel4.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Traži korisnika :";
            // 
            // PregledKorisnikaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PregledKorisnikaControl";
            this.Size = new System.Drawing.Size(1031, 557);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaKorisnika)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDetalji.ResumeLayout(false);
            this.panelDetalji.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorijaTransakcija)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox tbTrazi;
        private DataGridView dgvListaKorisnika;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelDetalji;
        private Panel panel2;
        private Panel panelStats;
        private Label lblCash;
        private Label lblShib;
        private Label lblEth;
        private Label lblBtc;
        private Label label3;
        private Label lblDrzava;
        private Label lblBrojTelefona;
        private Label lblEmail;
        private Label lblImePrezime;
        private Label lblUsername;
        private Label label2;
        private DataGridView dgvHistorijaTransakcija;
        private Button btnTrazi;
        private Label lblTotalTransakcija;
        private Label lblAvgUplata;
        private Label lblAvgIsplata;
        private Label lblTotalIsplata;
        private Label lblTotalUplata;
        private Label lblTopIsplata;
        private Label lblTopUplata;
        private Label label4;
        private DataGridViewTextBoxColumn naziv_valute;
        private DataGridViewTextBoxColumn kolicina_valute;
        private DataGridViewTextBoxColumn kolicina_transakcije;
        private DataGridViewTextBoxColumn tip;
        private DataGridViewTextBoxColumn vrijeme_obavljanja;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel4;
        private Label label1;
        private DataGridViewTextBoxColumn user_ID;
        private DataGridViewTextBoxColumn ime_prezime;
        private DataGridViewTextBoxColumn username;
        private DataGridViewTextBoxColumn stanje_walleta;
        private DataGridViewButtonColumn details;
    }
}
