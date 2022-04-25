using System.Collections.Generic;
using System.Linq;

namespace LoginForm
{
    public class LoginManager : ILoginManager
    {
        private ILoginRetriever loginRetriever;

        public LoginManager(ILoginRetriever loginRetriever)
        {
            this.loginRetriever = loginRetriever;
        }

        public bool IsLogin(AccountInfo accountInfo)
        {
            List<AccountInfo> accountsInfo = GetAccountsInfo().ToList();
            return accountsInfo.Contains(accountInfo);
        }

        private IEnumerable<AccountInfo> GetAccountsInfo()
        {
            return loginRetriever.GetAllAccountsInfo();
        }
    }
}
