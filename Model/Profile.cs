using Diplom.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model
{
    public class Profile: Base.BaseObject
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Email { get; set; }

        public virtual Education Education { get; set; }
        public virtual FamilyState FamilyState { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual Group Group { get; set; }
        public virtual DriversLicense DriversLicense { get; set; }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(LastName))
            {
                return String.Format("{0} {1}.", Name, FirstName.First());
            }
            return String.Format("{0} {1}.{2}.", Name, FirstName.First(), LastName.First());
        }
    }
}
