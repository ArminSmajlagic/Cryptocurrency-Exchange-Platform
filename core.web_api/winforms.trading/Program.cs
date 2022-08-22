using winforms.trading.Forms;
using System.Runtime.InteropServices;

namespace winforms.trading
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AllocConsole();

            ApplicationConfiguration.Initialize();
            Application.Run(new Auth());
            //Application.Run(new MainParent());
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

    }
}