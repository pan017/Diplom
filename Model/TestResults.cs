using Diplom.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model
{
    public class TestResults:Base.BaseObject
    {
        public DateTime BeginTestDate { get; set; }
        public DateTime EndTestDate { get; set; }
        public virtual TestPack TestPack { get; set; }     
        public virtual TestStage TestStage { get; set; }
        public virtual List<ReactionTime> ReactionTimes { get; set; }

        public TestResults()
        {
            ReactionTimes = new List<ReactionTime>();
        }
    }
}
