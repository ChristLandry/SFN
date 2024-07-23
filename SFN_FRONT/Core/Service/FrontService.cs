using SFN_FRONT.Core.BLL;
using SFN_MODEL.MODEL;

namespace SFN_FRONT.Core.Service
{
    public class FrontService: IFrontService
    {
        private IAPILinkBll _IAPILink;
        private ICompteBll _ICompteBll;
        private IAuditBll _IAuditBll;
        public FrontService(IAPILinkBll aPILink, ICompteBll iCompteBll, IAuditBll iAuditBll)
        {
            _IAPILink = aPILink;
            _ICompteBll = iCompteBll;
            _IAuditBll = iAuditBll;
        }

        public Reponse DeleteCompte(string numCompte)
        {
            return _ICompteBll.DeleteCompte(numCompte);  
        }

        public string GenerateRandom(int size)
        {
            return _ICompteBll.GenerateRandom(size);
        }

        public string GetBaseAdresse()
        {
            return _IAPILink.GetBaseAdresse();
        }

        public JsonCompte GetCompteByNumCompte(string numCompte)
        {
            return _ICompteBll.GetCompteByNumCompte(numCompte);
        }

        public IEnumerable<JsonAudit> GetListAudit(int PageIndex = 0, int PageSize = 10)
        {
            return _IAuditBll.GetListAudit(PageIndex,PageSize);
        }

        public IEnumerable<JsonCompte> GetListCompte(int PageIndex = 0, int PageSize = 10)
        {
            return _ICompteBll.GetListCompte(PageIndex, PageSize);
        }

        public string GetToken()
        {
            return _IAPILink.GetToken();
        }

        public Reponse SaveCompte(JsonCompte json)
        {
            return _ICompteBll.SaveCompte(json);
        }
    }
}
