using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class KlijentiController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public KlijentiController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Klijent> model = unitOfWork.KlijentRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateKlijentViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return Create();
            }

            unitOfWork.KlijentRepository.Add(new Klijent
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
                Email = model.Email,
                Telefon = model.Telefon
            });
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Klijent model = unitOfWork.KlijentRepository.SearchByIntId(id);
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(int id, [FromForm] Klijent model)
        {
            Klijent klijentZaBrisanje = unitOfWork.KlijentRepository.SearchByIntId(id);
            unitOfWork.KlijentRepository.Delete(klijentZaBrisanje);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Klijent klijent = unitOfWork.KlijentRepository.SearchByIntId(id);
            CreateKlijentViewModel model = new CreateKlijentViewModel
            {
                Ime = klijent.Ime,
                Prezime = klijent.Prezime,
                Email = klijent.Email,
                Telefon = klijent.Telefon
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int id, [FromForm] CreateKlijentViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return Create();
            }

            Klijent klijentZaIzmenu = unitOfWork.KlijentRepository.SearchByIntId(id);

            klijentZaIzmenu.Ime = model.Ime;
            klijentZaIzmenu.Prezime = model.Prezime;
            klijentZaIzmenu.Telefon = model.Prezime;
            klijentZaIzmenu.Email = model.Email;

            unitOfWork.KlijentRepository.Update(klijentZaIzmenu);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
