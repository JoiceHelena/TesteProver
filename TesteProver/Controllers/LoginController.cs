using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteProverDominio;
using TesteProverDominio.Entidades;
using TesteProverService.Interface;

namespace TesteProver.Controllers
{
    public class LoginController : Controller
    {
        private readonly Servicos servicos;
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            servicos = new Servicos(_loginRepository);
        }

        // GET: TelaLogin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Login model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    servicos.SalvarLogin(model);
                    return RedirectToAction("Index", "Contato");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(servicos.LoginSistema(model))
                    {
                        return RedirectToAction("Index","Contato");
                    }
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}