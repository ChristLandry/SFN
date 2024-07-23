using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_DATA.ENTITY
{
    [Table("COMPTES")]
    public class EntityCompte
    {
        public string NumCompte { get; set; }
        public string NomAgence { get; set; }
        public string LibelleCompte { get; set; }
        public string TypeCompte { get; set; }
        public bool StatutCompte { get; set; }
        public string NumeroCarte { get; set; }
        public string Adresse { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; } = null;
    }
}
