using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model.Base
{
    public class BaseLookup: BaseObject
    {
        public string Name { get; set; }
        public BaseLookup()
        {

        }
        public BaseLookup(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
