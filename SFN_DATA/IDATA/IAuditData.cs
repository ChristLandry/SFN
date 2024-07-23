using SFN_DATA.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_DATA.IDATA
{
    public interface IAuditData
    {
        List<EntityAudit> GetAllAudit(int PageIndex = 0, int PageSize = 10);
        void Post(object audit);
    }
}
