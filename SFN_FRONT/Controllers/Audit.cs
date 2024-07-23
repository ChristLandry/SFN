using Microsoft.AspNetCore.Mvc;
using SFN_FRONT.Core.Service;

namespace SFN_FRONT.Controllers
{
    public class Audit : Controller
    {
        private readonly ILogger<Audit> _logger;
        private IFrontService _Serv;
        public Audit(ILogger<Audit> logger, IFrontService frontService)
        {
            _logger = logger;
            _Serv = frontService;
        }
        public IActionResult Index(int pageIndex = 1)
        {
            try
            {
                ViewBag.PageIndex = pageIndex;
                if (pageIndex == null || pageIndex < 1)
                {
                    ViewBag.PageIndex = 1;
                    pageIndex = 1;
                }
                var pageSize = 10;
                return View(_Serv.GetListAudit(pageIndex, pageSize));
            }
            catch (Exception)
            {
                return View(_Serv.GetListAudit());
            }
        }
    }
}
