using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SFN_MODEL.MODEL;
using SFN_SERVICES.SERVICES;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SFN.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Compte : ControllerBase
    {
        readonly IService _IServ;
        public Compte(IService servive_Api)
        {
            _IServ = servive_Api;
        }

        [HttpGet]
        public async Task<IActionResult> GetListCompte(int PageIndex = 0, int PageSize = 10)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                return new JsonResult(_IServ.GetListCompte(PageIndex,PageSize));
            }
            catch (Exception ex)
            {
                return BadRequest("Une erreur s'est produite, message de retour " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GenerateRandom(int value)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                return new JsonResult(_IServ.GenerateRandom(value));
            }
            catch (Exception ex)
            {
                return BadRequest("Une erreur s'est produite, message de retour " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCompteByNumCompte(string numCompte)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                return new JsonResult(_IServ.GetCompteByNumCompte(numCompte));
            }
            catch (Exception ex)
            {
                return BadRequest("Une erreur s'est produite, message de retour " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JsonCompte json)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                return new JsonResult(_IServ.CreateCompte(json));
            }
            catch (Exception ex)
            {
                return BadRequest("Une erreur s'est produite, message de retour " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] JsonCompte json)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                return new JsonResult(_IServ.UpdateCompte(json));
            }
            catch (Exception ex)
            {
                return BadRequest("Une erreur s'est produite, message de retour " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string numCompte)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                return new JsonResult(_IServ.DeleteCompte(numCompte));
            }
            catch (Exception ex)
            {
                return BadRequest("Une erreur s'est produite, message de retour " + ex.Message);
            }
        }
    }
}
