using System;
using System.Windows.Forms;

namespace DataBase
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Авторизація());
            Application.Run(new Головна());
        }
    }
}
