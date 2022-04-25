using System;

namespace LoginForm
{
    public class AccountInfo : IEquatable<AccountInfo>
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public AccountInfo(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public bool Equals(AccountInfo other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Login == other.Login && Password == other.Password;
        }

        public override bool Equals(object obj)
        {
            AccountInfo accountInfo = obj as AccountInfo;

            return Equals(accountInfo);
        }

        public static bool operator ==(AccountInfo a, AccountInfo b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(AccountInfo a, AccountInfo b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash = (hash << 4) ^ (hash >> 28) ^ Login.GetHashCode();
            hash = (hash << 4) ^ (hash >> 28) ^ Password.GetHashCode();

            return hash;
        }
    }
}
