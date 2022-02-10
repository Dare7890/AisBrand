using BrandDataProcessing;
using BrandDataProcessingBL;
using LoginUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            ITranslater translater = new EntitiyNameTranslater();
            IClassificationsRetriever classificationsRetriever = new ClassificationsRetriever();
            BrandDataProcessingForm form = new BrandDataProcessingForm(translater);
            ExcavationPresenter excavationPresenter = new ExcavationPresenter(form, classificationsRetriever);
            FindsClassPresenter findsClassPresenter = new FindsClassPresenter(form, classificationsRetriever);
            ClassificationPresenter classificationPresenter = new ClassificationPresenter(form);
            FindPresenter findPresenter = new FindPresenter(form);
            Application.Run(form);
        }
    }
}
