using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DbData
    {
        private string _source;
        private string _dbName;
        private string _user;
        private string _password;

        public string Source { get => _source; set => _source = value; }
        public string DbName { get => _dbName; set => _dbName = value; }
        public string User { get => _user; set => _user = value; }
        public string Password { get => _password; set => _password = value; }

        public DbData(string source,string dbName,string user, string password) 
        {
            if (password.Length > 128) 
            {
                throw new ArgumentException("The password can't contain more than 128 chars");
            }
            this.Source = source;
            this.DbName = dbName;
            this.User = user;
            this.Password = password;
        }

        
    }
}
