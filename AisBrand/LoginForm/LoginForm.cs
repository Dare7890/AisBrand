using BrandDataProcessing;
using BrandDataProcessingBL;
using BrandDataProcessingUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        private ILoginManager loginManager;

        public LoginForm(ILoginManager loginManager)
        {
            InitializeComponent();

            this.loginManager = loginManager;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartApplication();
        }

        private void StartApplication()
        {
            AccountInfo accountInfo = GetAccountInfo();
            if (loginManager.IsLogin(accountInfo))
                Start();
            else
                ShowErrorMessage();
        }

        private AccountInfo GetAccountInfo()
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            return new AccountInfo(login, password);
        }

        private void Start()
        {
            ITranslater translater = new EntitiyNameTranslater();
            IClassificationsRetriever classificationsRetriever = new ClassificationsRetriever();
            BrandDataProcessingForm form = new BrandDataProcessingForm(translater);
            ExcavationPresenter excavationPresenter = new ExcavationPresenter(form, classificationsRetriever);
            FindsClassPresenter findsClassPresenter = new FindsClassPresenter(form, classificationsRetriever);
            ClassificationPresenter classificationPresenter = new ClassificationPresenter(form);
            FindPresenter findPresenter = new FindPresenter(form);

            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void ShowErrorMessage()
        {
            const string errorMessage = "Неверный логин/пароль";
            const string errorCaption = "Ошибка авторизации";
            MessageBox.Show(errorMessage, errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
