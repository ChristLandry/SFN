using SFN_MODEL.MODEL;

namespace SFN_FRONT.Core.BLL
{
    public interface ICompteBll
    {
        string GenerateRandom(int size);
        IEnumerable<JsonCompte> GetListCompte(int PageIndex = 0, int PageSize = 10);
        JsonCompte GetCompteByNumCompte(string numCompte);
        //Reponse CreateCompte(JsonCompte json);
        Reponse SaveCompte(JsonCompte json);
        Reponse DeleteCompte(string numCompte);
    }
}
