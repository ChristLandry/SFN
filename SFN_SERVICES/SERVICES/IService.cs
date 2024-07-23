using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_SERVICES.SERVICES
{
    public interface IService
    {
        #region Token
        object GetToken(JsonLogiciel _JsonLogiciel);
        #endregion

        #region Audit
        List<JsonAudit> GetAllAudit(int PageIndex = 0, int PageSize = 10);
        #endregion

        #region Logiciel
        JsonLogiciel GetLogicielByCode(string code);
        Reponse UpdateLogiciel(JsonLogiciel json);
        #endregion

        #region Compte
        string GenerateRandom(int size);
        List<JsonCompte> GetListCompte(int PageIndex = 0, int PageSize = 10);
        JsonCompte GetCompteByNumCompte(string numCompte);
        Reponse CreateCompte(JsonCompte json);
        Reponse UpdateCompte(JsonCompte json);
        Reponse DeleteCompte(string numCompte);
        #endregion
    }
}
