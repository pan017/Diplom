using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Model.Base;
using Diplom.Model.Lookups;

namespace Diplom.Model
{
    public class User:BaseObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Profile Profile { get; set; }
    }
}
