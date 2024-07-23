using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFN_MODEL.MODEL;
using SFN_SERVICES.SERVICES;

namespace SFN.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Token : ControllerBase
    {
        readonly IService _IServ;
        public Token(IService servive_Api)
        {
            _IServ = servive_Api;
        }

        [HttpPost]
        public object GetTokenAsync([FromBody] JsonLogicielInfos value)
        {
            try
            {
                var Logiciel = _IServ.GetLogicielByCode(value.codeLogiciel);
                if (Logiciel != null && Logiciel.idLogiciel == value.password && Logiciel.codeLogiciel == value.codeLogiciel)
                {
                    return new JsonResult(_IServ.GetToken(Logiciel));
                }
                else
                {
                    return new JsonResult("Les informations du logiciel sont incorrectes ou logiciel inexistant, Veuillez contacter votre relation a la BNI");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erreur : " + ex.Message);
            }
        }
    }
}
