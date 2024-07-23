using Microsoft.AspNetCore.Mvc;
using SFN_FRONT.Models;
using SFN_MODEL.MODEL;
using System.Diagnostics;
using System.Text.Json;
using System.Text;
using SFN_FRONT.Core.Service;

namespace SFN_FRONT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFrontService _Serv;
        public HomeController(ILogger<HomeController> logger, IFrontService frontService)
        {
            _logger = logger;
            _Serv = frontService;
        }

        public IActionResult ListCompte(int pageIndex = 1)
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
                return View(_Serv.GetListCompte(pageIndex, pageSize));
            }
            catch (Exception)
            {
                return View(_Serv.GetListCompte());
            }
        }
        public IActionResult EditCompte(string? numCompte = "")
        {
            try
            {
                if (numCompte == "")
                    return View(new JsonCompte() { numCompte = _Serv.GenerateRandom(11), numeroCarte = _Serv.GenerateRandom(16) });
                else
                    //fonction pour recuperer le compte par le numéro de compte

                    return View(_Serv.GetCompteByNumCompte(numCompte));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(ListCompte));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCompte([Bind()] JsonCompte jsonCompte)
        {
            try
            {
                if (ModelState.IsValid && jsonCompte.typeCompte != null)
                {
                    //Appel de la foncion de MAJ ou création
                    var reponse = _Serv.SaveCompte(jsonCompte);
                    if (reponse.isSucces)
                    {
                        TempData["isSucces"] = reponse.isSucces;
                        TempData["msg"] = reponse.msg;
                        return RedirectToAction(nameof(ListCompte));
                    }
                    else
                    {
                        TempData["isSucces"] = reponse.isSucces;
                        TempData["msg"] = reponse.msg;
                        return View(jsonCompte);

                    }
                }
                return View(jsonCompte);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(ListCompte));
            }
        }

        public IActionResult Delete(string numCompte)
        {
            {
                if (numCompte != "")
                {
                    //var json = _Serv.GetCompteByNumCompte(numCompte);
                    var reponse = _Serv.DeleteCompte(numCompte);
                    TempData["isSucces"] = reponse.isSucces;
                    TempData["msg"] = reponse.msg;
                    return RedirectToAction(nameof(ListCompte));
                }

                // Traiter les données du formulaire

                return RedirectToAction(nameof(ListCompte));
            }
        }

       
    }
}
