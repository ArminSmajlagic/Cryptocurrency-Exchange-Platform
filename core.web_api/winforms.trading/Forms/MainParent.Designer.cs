namespace winforms.trading.Forms
{
    partial class MainParent
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
            this.navPanel = new System.Windows.Forms.Panel();
            this.btnKorisnik = new System.Windows.Forms.Button();
            this.btnWallet = new System.Windows.Forms.Button();
            this.btnKripto = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanelOnMainForm = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.navPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navPanel
            // 
            this.navPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.navPanel.AutoSize = true;
            this.navPanel.BackColor = System.Drawing.Color.White;
            this.navPanel.Controls.Add(this.button2);
            this.navPanel.Controls.Add(this.btnKorisnik);
            this.navPanel.Controls.Add(this.btnWallet);
            this.navPanel.Controls.Add(this.btnKripto);
            this.navPanel.Controls.Add(this.btnHome);
            this.navPanel.Controls.Add(this.button1);
            this.navPanel.Controls.Add(this.logoPanel);
            this.navPanel.Location = new System.Drawing.Point(0, 0);
            this.navPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(232, 920);
            this.navPanel.TabIndex = 0;
            // 
            // btnKorisnik
            // 
            this.btnKorisnik.BackColor = System.Drawing.Color.White;
            this.btnKorisnik.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKorisnik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKorisnik.Font = new System.Drawing.Font("Segoe UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKorisnik.ForeColor = System.Drawing.Color.Black;
            this.btnKorisnik.Location = new System.Drawing.Point(0, 818);
            this.btnKorisnik.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKorisnik.Name = "btnKorisnik";
            this.btnKorisnik.Size = new System.Drawing.Size(232, 53);
            this.btnKorisnik.TabIndex = 21;
            this.btnKorisnik.Text = "Logout";
            this.btnKorisnik.UseVisualStyleBackColor = false;
            this.btnKorisnik.Click += new System.EventHandler(this.logout);
            // 
            // btnWallet
            // 
            this.btnWallet.BackColor = System.Drawing.Color.White;
            this.btnWallet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWallet.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWallet.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnWallet.Location = new System.Drawing.Point(0, 281);
            this.btnWallet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWallet.Name = "btnWallet";
            this.btnWallet.Size = new System.Drawing.Size(232, 71);
            this.btnWallet.TabIndex = 20;
            this.btnWallet.Text = "Narudžbe";
            this.btnWallet.UseVisualStyleBackColor = false;
            this.btnWallet.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnKripto
            // 
            this.btnKripto.BackColor = System.Drawing.Color.White;
            this.btnKripto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKripto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKripto.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKripto.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnKripto.Location = new System.Drawing.Point(0, 210);
            this.btnKripto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKripto.Name = "btnKripto";
            this.btnKripto.Size = new System.Drawing.Size(232, 71);
            this.btnKripto.TabIndex = 19;
            this.btnKripto.Text = "Korisnici";
            this.btnKripto.UseVisualStyleBackColor = false;
            this.btnKripto.Click += new System.EventHandler(this.btnKorisnici_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHome.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHome.Location = new System.Drawing.Point(0, 139);
            this.btnHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(232, 71);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(0, 871);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 49);
            this.button1.TabIndex = 18;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.close_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.logoPanel.Controls.Add(this.label1);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(232, 139);
            this.logoPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans MT", 39.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 93);
            this.label1.TabIndex = 13;
            this.label1.Text = "Logos";
            // 
            // mainPanelOnMainForm
            // 
            this.mainPanelOnMainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanelOnMainForm.Location = new System.Drawing.Point(227, 0);
            this.mainPanelOnMainForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainPanelOnMainForm.Name = "mainPanelOnMainForm";
            this.mainPanelOnMainForm.Size = new System.Drawing.Size(1429, 920);
            this.mainPanelOnMainForm.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.button2.Location = new System.Drawing.Point(0, 352);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 71);
            this.button2.TabIndex = 22;
            this.button2.Text = "Dashboard";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // MainParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1656, 920);
            this.ControlBox = false;
            this.Controls.Add(this.mainPanelOnMainForm);
            this.Controls.Add(this.navPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.navPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.logoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       // public Panel displayPanel;
        private Panel navPanel;
        private Panel logoPanel;
        private Button button1;
        private Button btnWallet;
        private Button btnKripto;
        private Button btnHome;
        private Button btnKorisnik;
        private Label label1;
        private Panel mainPanelOnMainForm;
        private Button button2;
    }
}