using System.Collections.Generic;

namespace LoginForm
{
    public interface ILoginRetriever
    {
        IEnumerable<AccountInfo> GetAllAccountsInfo();
    }
}