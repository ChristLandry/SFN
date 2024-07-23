using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFN_SERVICES.SERVICES;

namespace SFN.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Audit : ControllerBase
    {
        readonly IService _IServ;
        public Audit(IService servive_Api)
        {
            _IServ = servive_Api;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAudits(int PageIndex = 0, int PageSize = 10)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                return new JsonResult(_IServ.GetAllAudit(PageIndex, PageSize));
            }
            catch (Exception ex)
            {
                return BadRequest("Une erreur s'est produite, message de retour " + ex.Message);
            }
        }
    }
}
