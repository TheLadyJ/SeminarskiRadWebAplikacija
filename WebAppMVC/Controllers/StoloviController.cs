using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
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
            List<Sto> model = unitOfWork.StoRepository.GetAll();
            return View(model);
        }
    }
}
