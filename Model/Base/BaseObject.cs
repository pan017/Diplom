using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model.Base
{
    public class BaseObject
    {
        [Key]
        public Guid id { get; set; }
        public DateTime CreatonDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public BaseObject()
        {
            id = Guid.NewGuid();
            CreatonDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
