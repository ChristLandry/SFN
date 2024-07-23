using SFN_MODEL.MODEL;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace SFN_FRONT.Core.BLL
{
    public class CompteBll : ICompteBll
    {
        private IAPILinkBll _IAPILinkBll;
        private HttpClient _httpClient;
        private string BaseAPIUrl;
        public CompteBll(IAPILinkBll aPILink)
        {
            _IAPILinkBll = aPILink;
            BaseAPIUrl = _IAPILinkBll.GetBaseAdresse();
        }
        //public Reponse CreateCompte(JsonCompte json)
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public Reponse DeleteCompte(string numCompte)
        {
            try
            {
                _httpClient = new();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _IAPILinkBll.GetToken());
                string url = String.Format(BaseAPIUrl + "api/Compte/Delete?numCompte={0}", numCompte);
                var response = _httpClient.DeleteAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadFromJsonAsync<Reponse>().Result;
                }
                else
                {
                    return new() { isSucces = false, msg = response.ToString() };
                }
            }
            catch (Exception ex)
            {

                return new() { isSucces = false, msg = ex.Message };
            }
        }

        public string GenerateRandom(int size)
        {
            try
            {
                _httpClient = new();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _IAPILinkBll.GetToken());
                string url = String.Format(BaseAPIUrl + "api/Compte/GenerateRandom?value={0}", size);

                var response = _httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var generate = response.Content.ReadFromJsonAsync<string>().Result;
                    return generate;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {

                return  ex.Message ;
            }
        }

        public JsonCompte GetCompteByNumCompte(string numCompte)
        {
            try
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _IAPILinkBll.GetToken());
                string url = String.Format(BaseAPIUrl + "api/Compte/GetCompteByNumCompte?numCompte={0}", numCompte);

                var response = _httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var users = response.Content.ReadFromJsonAsync<JsonCompte>().Result;
                    return users;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null ;
            }
        }

        public IEnumerable<JsonCompte> GetListCompte(int PageIndex = 0, int PageSize = 10)
        {
            try
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _IAPILinkBll.GetToken());
                string url = String.Format(BaseAPIUrl + "api/Compte/GetListCompte?PageIndex={0}&PageSize={1}", PageIndex,PageSize);

                var response = _httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var users = response.Content.ReadFromJsonAsync<IEnumerable<JsonCompte>>().Result;
                    return (IEnumerable<JsonCompte>)users;
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

        public Reponse SaveCompte(JsonCompte json)
        {
            try
            {
                _httpClient = new();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _IAPILinkBll.GetToken());
                var content = new StringContent(JsonSerializer.Serialize(json), Encoding.UTF8, "application/json");
                if (!json.save)
                {
                    //Appel de la foncion de creation
                    string url = String.Format(BaseAPIUrl + "api/Compte/Post");

                    var response = _httpClient.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadFromJsonAsync<Reponse>().Result;
                    }
                    else
                    {
                        return new() { isSucces = false, msg = response.Content.ToString() };
                    }
                }
                else
                {
                    string url = String.Format(BaseAPIUrl + "api/Compte/Put");

                    var response = _httpClient.PutAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadFromJsonAsync<Reponse>().Result;
                    }
                    else
                    {
                        return new() { isSucces = false, msg = response.Content.ToString() };
                    }
                }
            }
            catch (Exception ex)
            {
                return new() { isSucces = false, msg = ex.Message };
            }
        }
    }
}
