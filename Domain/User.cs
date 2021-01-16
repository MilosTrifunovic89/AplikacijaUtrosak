using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        #region Properties
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        #endregion
    }
}
