using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_MODEL.MODEL
{
    public class JsonAudit
    {
        public Guid idAudit { get; set; }
        public string fonctAuditer { get; set; }
        public string actionAudit { get; set; } = null!;
        public string matriculeUser { get; set; }
        public DateTime dateCreationAudit { get; set; }
    }
}
