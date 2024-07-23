using SFN_MODEL.MODEL;

namespace SFN_FRONT.Core.Service
{
    public interface IFrontService
    {
        #region Audit
        IEnumerable<JsonAudit> GetListAudit(int PageIndex = 0, int PageSize = 10);
        #endregion
        #region APILink
        string GetToken();
        string GetBaseAdresse();
        #endregion

        #region Compte
        string GenerateRandom(int size);
        IEnumerable<JsonCompte> GetListCompte(int PageIndex = 0, int PageSize = 10);
        JsonCompte GetCompteByNumCompte(string numCompte);
        //Reponse CreateCompte(JsonCompte json);
        Reponse SaveCompte(JsonCompte json);
        Reponse DeleteCompte(string numCompte);
        #endregion
    }
}
