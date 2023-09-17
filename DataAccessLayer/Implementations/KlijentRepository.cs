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
    public class KlijentRepository : IKlijentRepository
    {
        private readonly AppDbContext context;

        public KlijentRepository(AppDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Metoda za dodavanje novog klijenta
        /// </summary>
        /// <param name="entity">Klijent koji treba da se doda</param>
        public void Add(Klijent entity)
        {
            context.Add(entity);
        }
        /// <summary>
        /// Metoda za brisanje klijenta
        /// </summary>
        /// <param name="entity">Klijent koji treba da se obrise</param>
        public void Delete(Klijent entity)
        {
            context.Remove(entity);
        }
        /// <summary>
        /// Metoda za vracanje svih klijenata
        /// </summary>
        public List<Klijent> GetAll()
        {
            return context.Klijenti.ToList();
        }
        /// <summary>
        /// Metoda za pretragu klijenata na osnovu izraza
        /// </summary>
        /// <param name="predicate">Izraz na osnovu koga se vrsi pretraga</param>
        /// <returns>Lista klijenata koji zadovoljavaju prosledjeni izraz</returns>
        public List<Klijent> SearchBy(Expression<Func<Klijent, bool>> predicate)
        {
            return context.Klijenti.Where(predicate).ToList();
        }
        /// <summary>
        /// Metoda za pretragu klijenta na osnovu identifikatora prosledjenog klijenta
        /// </summary>
        /// <param name="entity">Objekat Klijent na osnovu cijeg identifikatora se pretrazuje klijent</param>
        /// <returns>Tacno jedan klijent koji ima isti identifikator kao prosledjen klijent</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Klijent SearchById(Klijent entity)
        {
            return context.Klijenti.Single(k => k.KlijentId == entity.KlijentId);
        }
        /// <summary>
        /// Metoda za pretragu klijenta na osnovu identifikatora
        /// </summary>
        /// <param name="id">Identifikator na osnovu kog se pretrazuje klijent</param>
        /// <returns>Tacno jedan klijent koji ima isti identifikator kao onaj prosledjen</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Klijent SearchByIntId(int id)
        {
            return context.Klijenti.Single(k => k.KlijentId == id);
        }
        /// <summary>
        /// Metoda za azuriranje klijenta
        /// </summary>
        /// <param name="entity">Klijent koji treba azurirati sa novim podacima</param>
        public void Update(Klijent entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
