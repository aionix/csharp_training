using System;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    public class AccountData
    {
        private String username;
        private String password;

        public AccountData(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


    }
}


