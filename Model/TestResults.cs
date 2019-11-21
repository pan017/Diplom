using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model
{
    public class TestResults:Base.BaseObject
    {
        public TestPack TestPack { get; set; }
        public List<Lookups.ReactionTime> ReactionTimes { get; set; }

    }
}
