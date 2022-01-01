using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrandDataProcessingBL;

namespace BrandDataProcessingUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BrandDataProcessingForm form = new BrandDataProcessingForm();
            ExcavationPresenter excavationPresenter = new ExcavationPresenter(form);
            FindsClassPresenter findsClassPresenter = new FindsClassPresenter(form);
            Application.Run(form);
        }
    }
}
