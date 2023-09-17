using DataAccessLayer.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class RezervacijaRepository : IRezervacijaRepository
    {
        private readonly AppDbContext context;

        public RezervacijaRepository(AppDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Metoda za dodavanje nove rezervacije
        /// </summary>
        /// <param name="entity">Rezervacija koja treba da se doda</param>
        public void Add(Rezervacija entity)
        {
            context.Add(entity);
        }
        /// <summary>
        /// Metoda za brisanje rezervacije
        /// </summary>
        /// <param name="entity">Rezervacija koja treba da se obrise</param>
        public void Delete(Rezervacija entity)
        {
            context.Remove(entity);
        }
        /// <summary>
        /// Metoda za vracanje svih rezervacija
        /// </summary>
        public List<Rezervacija> GetAll()
        {
            return context.Rezervacije.Include(r => r.Klijent).Include(r => r.Radnik).Include(r => r.KeteringMeni).Include(r => r.Mesto).Include(r => r.TipProslave).ToList();
        }
        /// <summary>
        /// Metoda za pretragu rezervacije na osnovu izraza
        /// </summary>
        /// <param name="predicate">Izraz na osnovu koga se vrsi pretraga</param>
        /// <returns>Lista rezervacija koje zadovoljavaju prosledjeni izraz</returns>
        public List<Rezervacija> SearchBy(Expression<Func<Rezervacija, bool>> predicate)
        {
            return context.Rezervacije.Include(r => r.Klijent).Include(r => r.Radnik).Include(r => r.KeteringMeni).Include(r => r.Mesto).Include(r => r.TipProslave).Where(predicate).ToList();
        }
        /// <summary>
        /// Metoda za pretragu rezervacije firme na osnovu identifikatora prosledjene rezervacije
        /// </summary>
        /// <param name="entity">Objekat Rezervacija na osnovu cijeg identifikatora se pretrazuje rezervacija</param>
        /// <returns>Tacno jedna rezervacija koja ima isti identifikator kao prosledjena rezervacija</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Rezervacija SearchById(Rezervacija entity)
        {
            return context.Rezervacije.Include(r => r.Klijent).Include(r => r.Radnik).Include(r => r.KeteringMeni).Include(r => r.Mesto).Include(r => r.TipProslave).Single(r => r.RezervacijaId == entity.RezervacijaId);
        }
        /// <summary>
        /// Metoda za pretragu rezervacije na osnovu identifikatora
        /// </summary>
        /// <param name="id">Identifikator na osnovu kog se pretrazuje rezervacije</param>
        /// <returns>Tacno jedna ketering firma koja ima isti identifikator kao onaj prosledjen</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Rezervacija SearchByIntId(int id)
        {
            return context.Rezervacije.Include(r => r.Klijent).Include(r => r.Radnik).Include(r => r.KeteringMeni).Include(r => r.Mesto).Include(r => r.TipProslave).Single(r => r.RezervacijaId == id);
        }

        /// <summary>
        /// Metoda za azuriranje rezervacije
        /// </summary>
        /// <param name="entity">Rezervacija koju treba azurirati sa novim podacima</param>
        public void Update(Rezervacija entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
