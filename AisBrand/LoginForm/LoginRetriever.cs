using System.Collections.Generic;
using System.Configuration;

namespace LoginForm
{
    public class LoginRetriever : ILoginRetriever
    {
        public IEnumerable<AccountInfo> GetAllAccountsInfo()
        {
            string[] allKeys = GetLogins();
            return GetAllAccountsInfo(allKeys);
        }

        private string[] GetLogins()
        {
            return ConfigurationManager.AppSettings.AllKeys;
        }

        private IEnumerable<AccountInfo> GetAllAccountsInfo(IEnumerable<string> logins)
        {
            List<AccountInfo> accountsInfo = new List<AccountInfo>();
            foreach (string login in logins)
            {
                string password = ConfigurationManager.AppSettings[login];
                AccountInfo accountInfo = new AccountInfo(login, password);

                accountsInfo.Add(accountInfo);
            }

            return accountsInfo;
        }
    }
}
