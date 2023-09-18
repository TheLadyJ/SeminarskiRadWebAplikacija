using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    [Authorize]

    public class StoloviController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public StoloviController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Sto> model = unitOfWork.StoRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            CreateStoViewModel model = new CreateStoViewModel();

            var proizvodjaci = unitOfWork.ProizvodjacRepository.GetAll();
            var mesta = unitOfWork.MestoRepository.GetAll();

            model.Proizvodjaci = proizvodjaci.Select(p => new SelectListItem(p.NazivProizvodjaca, p.ProizvodjacId.ToString())).ToList();
            model.Mesta = mesta.Select(m => new SelectListItem(m.ToString(), m.MestoId.ToString())).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateStoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Create();
            }

            Proizvodjac p = unitOfWork.ProizvodjacRepository.SearchByIntId(model.ProizvodjacId);
            Mesto m = unitOfWork.MestoRepository.SearchByIntId(model.MestoId);

            unitOfWork.StoRepository.Add(new Sto
            {
                Kapacitet = model.Kapacitet,
                CenaStola = model.CenaStola,
                Proizvodjac = p,
                Mesto = m,
            });

            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Sto sto = unitOfWork.StoRepository.SearchByIntId(id);
            CreateStoViewModel model = new CreateStoViewModel
            {
                Kapacitet = sto.Kapacitet,
                CenaStola = sto.CenaStola,
                ProizvodjacId = sto.ProizvodjacId,
                MestoId = sto.MestoId,
            };

            var proizvodjaci = unitOfWork.ProizvodjacRepository.GetAll();
            var mesta = unitOfWork.MestoRepository.GetAll();

            model.Proizvodjaci = proizvodjaci.Select(p => new SelectListItem(p.ToString(), p.ProizvodjacId.ToString())).ToList();
            model.Mesta = mesta.Select(m => new SelectListItem(m.ToString(), m.MestoId.ToString())).ToList();

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int id, [FromForm] CreateStoViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return Create();
            }

            Sto stoZaIzmenu = unitOfWork.StoRepository.SearchByIntId(id);

            stoZaIzmenu.Kapacitet = model.Kapacitet;
            stoZaIzmenu.CenaStola = model.CenaStola;
            stoZaIzmenu.ProizvodjacId = model.ProizvodjacId;
            stoZaIzmenu.MestoId = model.MestoId;

            unitOfWork.StoRepository.Update(stoZaIzmenu);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!unitOfWork.StoRepository.PossibleToDelete(id))
            {
                ModelState.AddModelError(string.Empty, "Ovaj sto je trenutno na listi rezervisanih stolova neke rezervacije i ne može biti obrisan.");
                return RedirectToAction("Index");
            }

            Sto model = unitOfWork.StoRepository.SearchByIntId(id);
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(int id, [FromForm] Sto model)
        {
            Sto stoZaBrisanje = unitOfWork.StoRepository.SearchByIntId(id);
            unitOfWork.StoRepository.Delete(stoZaBrisanje);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Sto model = unitOfWork.StoRepository.SearchByIntId(id);
            return View(model);
        }

    }
}
