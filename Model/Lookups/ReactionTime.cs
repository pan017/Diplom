using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model.Lookups
{
    public class ReactionTime: Base.BaseObject
    {
        public decimal BeginReactionTime { get; set; }
        public decimal EndReactionTime { get; set; }
    }
}
