using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Globalization;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAppMVC.Models;

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

        public IActionResult Create()
        {
            string radnikIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int radnikId = Int32.Parse(radnikIdString);

            CreateRezervacijaViewModel model = new CreateRezervacijaViewModel();
            Radnik radnik = unitOfWork.RadnikRepository.SearchByIntId(radnikId);
            model.Radnici.Add(new SelectListItem(radnik.ToString(), radnik.RadnikId.ToString()));
            model.RadnikId = radnikId;

            List<Klijent> klijenti = unitOfWork.KlijentRepository.GetAll();
            List<Mesto> mesta = unitOfWork.MestoRepository.GetAll();
            List<KeteringFirma> keteringFirme = unitOfWork.KeteringFirmaRepository.GetAll();
            List<TipProslave> tipoviProslave = unitOfWork.TipProslaveRepository.GetAll();

            model.Klijenti = klijenti.Select(k => new SelectListItem(k.ToString(), k.KlijentId.ToString())).ToList();
            model.Mesta = mesta.Select(m => new SelectListItem(m.ToString(), m.MestoId.ToString())).ToList();
            model.KeteringFirme = keteringFirme.Select(kf => new SelectListItem(kf.ToString(), kf.KeteringFirmaId.ToString())).ToList();

            model.TipoviProslave = tipoviProslave.Select(tp => new SelectListItem(tp.NazivTipaProslave, tp.TipProslaveId.ToString())).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateRezervacijaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Create();
            }

            bool datumVremeOdValidno = DateTime.TryParseExact(model.DatumVremeOd, "dd.MM.yyyy. HH:mm", null, DateTimeStyles.None, out DateTime datumVremeOd);
            bool datumVremeDoValidno = DateTime.TryParseExact(model.DatumVremeDo, "dd.MM.yyyy. HH:mm", null, DateTimeStyles.None, out DateTime datumVremeDo);

            if (!datumVremeOdValidno)
            {
                ModelState.AddModelError(string.Empty, "Datum i vreme OD nije u validnom formatu.");
                if (!datumVremeDoValidno)
                {
                    ModelState.AddModelError(string.Empty, "Datum i vreme DO nije u validnom formatu.");
                }
                return Create();
            }

            Radnik r = unitOfWork.RadnikRepository.SearchByIntId(model.RadnikId);
            Klijent k = unitOfWork.KlijentRepository.SearchByIntId(model.KlijentId);
            Mesto m = unitOfWork.MestoRepository.SearchByIntId(model.MestoId);
            KeteringMeni km = unitOfWork.KeteringMeniRepository.SearchByIntId(model.KeteringMeniId);
            TipProslave tp = unitOfWork.TipProslaveRepository.SearchByIntId(model.TipProslaveId);

            Rezervacija rezZaKreiranje = new Rezervacija
            {
                DatumVremeOd = datumVremeOd,
                DatumVremeDo = datumVremeDo,
                TipProslave = tp,
                TipProslaveId = tp.TipProslaveId,
                UkupnaCena = model.UkupnaCena,
                Radnik = r,
                RadnikId = r.RadnikId,
                Klijent = k,
                KlijentId = k.KlijentId,
                Mesto = m,
                MestoId = m.MestoId,
                KeteringMeni = km,
                KeteringMeniId = km.KeteringMeniId
            };

            return RedirectToAction("Index", "Rezervacije");
        }

        [HttpPost]
        public IActionResult AddTable(int rbStola)
        {
            Sto sto = unitOfWork.StoRepository.SearchByIntId(rbStola);
            string p = sto.Proizvodjac.ToString();

            StoViewModel model = new StoViewModel
            {
                RbStola = sto.RbStola,
                CenaStola = sto.CenaStola,
                Kapacitet = sto.Kapacitet,
                Proizvodjac = p
            };

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return Json(model, options);
        }

        public IActionResult LoadKeteringMenijiList(int keteringFirmaId)
        {
            List<KeteringMeni> meniji = unitOfWork.KeteringMeniRepository.SearchBy(km => km.KeteringFirmaId == keteringFirmaId);

            List<SelectListItem> listaMenija = meniji.Select(m => new SelectListItem(m.ToString(), m.KeteringMeniId.ToString())).ToList();

            return Json(listaMenija);
        }

        public IActionResult LoadStoloviList(int mestoId)
        {
            List<Sto> stolovi = unitOfWork.StoRepository.SearchBy(s => s.MestoId == mestoId);

            List<SelectListItem> listaStolova = stolovi.Select(s => new SelectListItem(s.ToString(), s.RbStola.ToString())).ToList();

            return Json(listaStolova);
        }
    }
}
