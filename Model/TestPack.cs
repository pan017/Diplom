using Diplom.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model
{
    public class TestPack:Base.BaseObject
    {

        public virtual Profile Profile { get; set; }
        public DateTime BeginTestDate { get; set; }
        public DateTime EndTestDate { get; set; }
        public virtual TestType TestType { get; set; }

    }
}
