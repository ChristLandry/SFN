using SFN_DATA.ENTITY;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_BLL.IBLL
{
    public interface IAuditBll
    {
        List<JsonAudit> GetAllAudit(int PageIndex = 0, int PageSize = 10);
    }
}
