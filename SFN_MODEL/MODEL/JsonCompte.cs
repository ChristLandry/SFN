using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_MODEL.MODEL
{
    public class JsonCompte
    {
        [Required(ErrorMessage = "Le numéro de compte est obligatoire")]
        [MaxLength(11, ErrorMessage = "Veuillez ne pas depasser 11 caractères pour le numéro de compte")]
        public string numCompte { get; set; }
        [Required(ErrorMessage = "Le nom d'agence est obligatoire")]
        public string nomAgence { get; set; }
        [Required(ErrorMessage = "Le libellé du compte est obligatoire")]
        public string libelleCompte { get; set; }
        [Required(ErrorMessage = "Le type de compte est obligatoire")]
        public string? typeCompte { get; set; } = null;
        public bool statutCompte { get; set; }
        [Required(ErrorMessage = "Le numero de la carte est obligatoire")]
        [MaxLength(16, ErrorMessage = "Veuillez ne pas depasser 16 caractères pour le numéro de la carte")]
        public string? numeroCarte { get; set; }
        [Required(ErrorMessage = "L'adresse est obligatoire")]
        public string adresse { get; set;}
        public DateTime dateCreation { get;set; }
        public DateTime? dateModification { get;set; } = null;
        public bool save { get; set; }
    }
}
