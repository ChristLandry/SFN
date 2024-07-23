using SFN_DATA.ENTITY;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_BLL.IBLL
{
    public interface ICompteBll
    {
        string GenerateRandom(int size);
        List<JsonCompte> GetListCompte(int PageIndex = 0, int PageSize = 10);
        JsonCompte GetCompteByNumCompte(string numCompte);
        Reponse CreateCompte(JsonCompte json);
        Reponse UpdateCompte(JsonCompte json);
        Reponse DeleteCompte(string numCompte);
    }
}
