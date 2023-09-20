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

        public string Source { get => _source;}
        public string DbName { get => _dbName;}
        public string User { get => _user;}
        public string Password { get => _password;}

        public DbData(string source,string dbName,string user, string password) 
        {
            if (password.Length > 128) 
            {
                throw new ArgumentException("The password can't contain more than 128 chars");
            }
            this._source = source;
            this._dbName = dbName;
            this._user = user;
            this._password = password;
        }

        
    }
}
