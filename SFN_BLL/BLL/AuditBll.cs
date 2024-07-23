using SFN_BLL.IBLL;
using SFN_DATA.IDATA;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_BLL.BLL
{
    public class AuditBll : IAuditBll
    {
        private IAuditData _IAuditData;
        public AuditBll(IAuditData auditData) { _IAuditData = auditData; }
        public List<JsonAudit> GetAllAudit(int PageIndex = 0, int PageSize = 10)
        {
            var _list = _IAuditData.GetAllAudit(PageIndex, PageSize);
            var List = new List<JsonAudit>();

            foreach (var audit in _list)
            {
                List.Add(new()
                {
                    actionAudit = audit.ActionAudit,
                    dateCreationAudit = audit.DateCreationAudit,
                    fonctAuditer = audit.FonctAuditer,
                    idAudit = audit.IdAudit,
                    matriculeUser = audit.MatriculeUser,
                });
            }
            return List;
        }
    }
}
