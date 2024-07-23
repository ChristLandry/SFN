using SFN_MODEL.MODEL;
using System.Net.Http.Headers;
using System.Net.Http;

namespace SFN_FRONT.Core.BLL
{
    public class AuditBll: IAuditBll
    {
        private IAPILinkBll _IAPILinkBll;
        private HttpClient _httpClient;
        private string BaseAPIUrl;
        public AuditBll(IAPILinkBll aPILink)
        {
            _IAPILinkBll = aPILink;
            BaseAPIUrl = _IAPILinkBll.GetBaseAdresse();
        }
        public IEnumerable<JsonAudit> GetListAudit(int PageIndex = 0, int PageSize = 10)
        {
            try
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _IAPILinkBll.GetToken());
                string url = String.Format(BaseAPIUrl + "api/Audit?PageIndex={0}&PageSize={1}", PageIndex, PageSize);

                var response = _httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var ListJsonAudit = response.Content.ReadFromJsonAsync<IEnumerable<JsonAudit>>().Result;
                    return (IEnumerable<JsonAudit>)ListJsonAudit;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
