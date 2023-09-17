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
    public class MestoRepository : IMestoRepository
    {
        private readonly AppDbContext context;

        public MestoRepository(AppDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Metoda za dodavanje novog mesta
        /// </summary>
        /// <param name="entity">Ketering meni koji treba da se doda</param>
        public void Add(Mesto entity)
        {
            context.Add(entity);
        }
        /// <summary>
        /// Metoda za brisanje mesta
        /// </summary>
        /// <param name="entity">Mesto koje treba da se obrise</param>
        public void Delete(Mesto entity)
        {
            context.Remove(entity);
        }
        /// <summary>
        /// Metoda za vracanje svih mesta
        /// </summary>
        public List<Mesto> GetAll()
        {
            return context.Mesta.ToList();

        }
        /// <summary>
        /// Metoda za pretragu mesta na osnovu izraza
        /// </summary>
        /// <param name="predicate">Izraz na osnovu koga se vrsi pretraga</param>
        /// <returns>Lista mesta koji zadovoljavaju prosledjeni izraz</returns>
        public List<Mesto> SearchBy(Expression<Func<Mesto, bool>> predicate)
        {
            return context.Mesta.Where(predicate).ToList();

        }
        /// <summary>
        /// Metoda za pretragu mesta na osnovu identifikatora prosledjenog mesta
        /// </summary>
        /// <param name="entity">Objekat Mesto na osnovu cijeg identifikatora se pretrazuje mesto</param>
        /// <returns>Tacno jedno mesto koje ima isti identifikator kao prosledjeno mesto</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Mesto SearchById(Mesto entity)
        {
            return context.Mesta.Single(m => m.MestoId == entity.MestoId);
        }
        /// <summary>
        /// Metoda za pretragu mesta na osnovu identifikatora
        /// </summary>
        /// <param name="id">Identifikator na osnovu kog se pretrazuje mesto</param>
        /// <returns>Tacno jedno mesto koje ima isti identifikator kao onaj prosledjen</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Mesto SearchByIntId(int id)
        {
            return context.Mesta.Single(m => m.MestoId == id);

        }
        /// <summary>
        /// Metoda za azuriranje mesta
        /// </summary>
        /// <param name="entity">Mesto koje treba azurirati sa novim podacima</param>
        public void Update(Mesto entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
