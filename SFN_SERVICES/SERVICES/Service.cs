using SFN_BLL.IBLL;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_SERVICES.SERVICES
{
    public class Service: IService
    {
        private ICompteBll _ICompteBll;
        private IAuditBll _IAuditBll;
        private ITokenBll _ITokenBll;
        private ILogicielBll _ILogicielBll;

        public Service(ICompteBll iCompteBll, IAuditBll auditBll, ILogicielBll logicielBll, ITokenBll tokenBll)
        {
            _ICompteBll = iCompteBll;
            _IAuditBll = auditBll;
            _ITokenBll = tokenBll;
           _ILogicielBll = logicielBll;
        }

        public Reponse CreateCompte(JsonCompte json)
        {
            return _ICompteBll.CreateCompte(json);
        }

        public Reponse DeleteCompte(string numCompte)
        {
            return _ICompteBll.DeleteCompte(numCompte);
        }

        public string GenerateRandom(int size)
        {
            return _ICompteBll.GenerateRandom(size);
        }

        public List<JsonAudit> GetAllAudit(int PageIndex = 0, int PageSize = 10)
        {
            return _IAuditBll.GetAllAudit(PageIndex,PageSize) ;
        }

        public JsonCompte GetCompteByNumCompte(string numCompte)
        {
            return _ICompteBll.GetCompteByNumCompte(numCompte);
        }

        public List<JsonCompte> GetListCompte(int PageIndex = 0, int PageSize = 10)
        {
            return _ICompteBll.GetListCompte(PageIndex,PageSize);
        }

        public JsonLogiciel GetLogicielByCode(string code)
        {
            return _ILogicielBll.GetLogicielByCode(code);
        }

        public object GetToken(JsonLogiciel _JsonLogiciel)
        {
           return _ITokenBll.GetToken(_JsonLogiciel);
        }

        public Reponse UpdateCompte(JsonCompte json)
        {
            return _ICompteBll.UpdateCompte(json);
        }

        public Reponse UpdateLogiciel(JsonLogiciel json)
        {
            return _ILogicielBll.UpdateLogiciel(json);
        }
    }
}
