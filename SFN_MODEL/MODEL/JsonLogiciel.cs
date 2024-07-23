using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_MODEL.MODEL
{
    public class JsonLogiciel
    {
        public Guid idLogiciel { get; set; }
        public string codeLogiciel { get; set; }
        public string? tokenLogiciel { get; set; }
        //public string? DescriptionLogiciel { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Veuillez entrer une valeur supérieure à {1}")]
        public int tempsValiderToken { get; set; }
    }
}
