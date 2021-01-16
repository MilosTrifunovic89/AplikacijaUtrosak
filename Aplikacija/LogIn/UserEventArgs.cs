using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.LogIn
{
    public class UserEventArgs
    {
        private readonly User _user;
        public User User => _user;

        public UserEventArgs(User user)
        {
            _user = user;
        }
    }
}
