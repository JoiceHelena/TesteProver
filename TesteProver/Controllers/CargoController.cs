using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteProverDominio;
using TesteProverDominio.Entidades;
using System.Threading.Tasks;
using TesteProverService.Interface;

namespace TesteProver.Controllers
{
    public class CargoController : Controller
    {
        private readonly Servicos servicos;

        private readonly ICargoRepository _cargoRepository;

        public CargoController(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
            servicos = new Servicos(_cargoRepository);
        }


        // GET: Cargo
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(Cargo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    servicos.SalvarCargo(model);
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