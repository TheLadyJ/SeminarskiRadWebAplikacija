using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class RezervacijeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public RezervacijeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Rezervacija> model = unitOfWork.RezervacijaRepository.GetAll();
            return View(model);
        }
    }
}
