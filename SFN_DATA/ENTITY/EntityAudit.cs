using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_DATA.ENTITY
{
    [Table("AUDITS")]
    public class EntityAudit
    {
        public Guid IdAudit { get; set; }
        public string FonctAuditer { get; set; }
        public string ActionAudit { get; set; } = null!;
        public string MatriculeUser { get; set; }
        public DateTime DateCreationAudit { get; set; }
    }
}
