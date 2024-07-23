using SFN_MODEL.MODEL;

namespace SFN_FRONT.Core.BLL
{
    public interface IAuditBll
    {
        IEnumerable<JsonAudit> GetListAudit(int PageIndex = 0, int PageSize = 10);
    }
}
