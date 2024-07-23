using SFN_DATA.ENTITY;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_DATA.IDATA
{
    public interface ICompteData
    {
        string GenerateRandom(int size);
        List<EntityCompte> GetListCompte(int PageIndex = 0,int PageSize =10);
        EntityCompte GetCompteByNumCompte(string numCompte);
        Reponse CreateCompte(EntityCompte entityCompte);
        Reponse UpdateCompte(EntityCompte entityCompte);
        Reponse DeleteCompte(string numCompte);
    }
}
