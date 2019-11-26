using Diplom.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model.Lookups
{
    public class CognitiveLoad : BaseLookup
    {
        public virtual CognetiveLoadType CognetiveLoadType { get; set; }
    }
}
