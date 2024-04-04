namespace DataBase
{
    class User
    {
        private static string _userName;

        public string userName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (userName != "")
                    _userName = userName;
            }
        }

        public User() { }

        public User(string user)
        {
            _userName = user;
        }

    }
}
