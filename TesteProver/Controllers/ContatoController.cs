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
    public class ContatoController : Controller
    {
        private readonly Servicos servicos;

        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
            servicos = new Servicos(_contatoRepository);
        }
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contato model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    servicos.SalvarContato(model);
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