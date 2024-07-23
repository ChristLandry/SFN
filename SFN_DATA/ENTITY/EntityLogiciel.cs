using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_DATA.ENTITY
{
    [Table("LOGICIELS")]
    public class EntityLogiciel
    {
        public Guid IdLogiciel { get; set; }
        public string CodeLogiciel { get; set; }
        public string? TokenLogiciel { get; set; }
        public int TempsValiderToken { get; set; }
    }
}
