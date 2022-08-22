using modeli.trading.Kripto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using winforms.trading.UserControls.Crypto;

namespace winforms.trading.Servisi
{
    public class NavigationServis
    {
        public Panel mainDisplayPanel { get; set; }
        public NavigationServis()
        {
            mainDisplayPanel = new Panel();
            mainDisplayPanel.AutoSize = true;
            mainDisplayPanel.BackColor = Color.White;
            mainDisplayPanel.Location = new Point(204, 0);
            mainDisplayPanel.Name = "displayPanel";
            mainDisplayPanel.Size = new Size(1245, 690);
            mainDisplayPanel.TabIndex = 8;
            mainDisplayPanel.Dock = DockStyle.Fill;

        }

        public void Navigate(UserControl navigateToUserControl)
        {
            mainDisplayPanel.Controls.Add(navigateToUserControl);
            navigateToUserControl.Dock = DockStyle.Fill;
            navigateToUserControl.BringToFront();
        }

    }
}
