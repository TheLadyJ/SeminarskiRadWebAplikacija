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
    public class StoRepository : IStoRepository
    {
        private readonly AppDbContext context;

        public StoRepository(AppDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Metoda za dodavanje novog stola
        /// </summary>
        /// <param name="entity">Sto koji treba da se doda</param>
        public void Add(Sto entity)
        {
            context.Add(entity);
        }
        /// <summary>
        /// Metoda za brisanje stola
        /// </summary>
        /// <param name="entity">Sto koji treba da se obrise</param>
        public void Delete(Sto entity)
        {
            context.Remove(entity);
        }
        /// <summary>
        /// Metoda za vracanje svih stolova
        /// </summary>
        public List<Sto> GetAll()
        {
            return context.Stolovi.Include(s => s.Proizvodjac).Include(s => s.Mesto).ToList();
        }

        /// <summary>
        /// Metoda za proveru da li postoji neka rezervacija u kojoj je upisan sto ciji je redni broj prosledjen zbog cega nije moguce obrisati sto
        /// </summary>
        /// <param name="RbStola">Redni broj stola (identifikator) na osnovu koga se vrsi provera o mogucnosti njegovog brisanja</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>true, ako je moguce obrisati sto</item>
        /// <item>false, ako nije moguce obrisati sto</item>
        /// </list>
        /// </returns>
        public bool PossibleToDelete(int RbStola)
        {
            if (context.Rezervacije.Any(r => r.Stolovi.Any(s => s.RbStola == RbStola)))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metoda za pretragu stolova na osnovu izraza
        /// </summary>
        /// <param name="predicate">Izraz na osnovu koga se vrsi pretraga</param>
        /// <returns>Lista stolova koji zadovoljavaju prosledjeni izraz</returns>
        public List<Sto> SearchBy(Expression<Func<Sto, bool>> predicate)
        {
            return context.Stolovi.Where(predicate).Include(s => s.Proizvodjac).Include(s => s.Mesto).ToList();
        }
        /// <summary>
        /// Metoda za pretragu stola na osnovu identifikatora prosledjenog stola
        /// </summary>
        /// <param name="entity">Objekat Sto na osnovu cijeg identifikatora se pretrazuje sto</param>
        /// <returns>Tacno jedan sto koji ima isti identifikator kao prosledjen sto</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Sto SearchById(Sto entity)
        {
            return context.Stolovi.Include(s => s.Proizvodjac).Include(s => s.Mesto).Single(s => s.RbStola == entity.RbStola);
        }
        /// <summary>
        /// Metoda za pretragu stola na osnovu identifikatora
        /// </summary>
        /// <param name="id">Identifikator na osnovu kog se pretrazuje sto</param>
        /// <returns>Tacno jedan sto koji ima isti identifikator kao onaj prosledjen</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Sto SearchByIntId(int rbStola)
        {
            return context.Stolovi.Include(s => s.Proizvodjac).Include(s => s.Mesto).Single(s => s.RbStola == rbStola);
        }
        /// <summary>
        /// Metoda za azuriranje stola
        /// </summary>
        /// <param name="entity">Sto koji treba azurirati sa novim podacima</param>
        public void Update(Sto entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
