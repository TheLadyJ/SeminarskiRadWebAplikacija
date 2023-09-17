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
    public class TipProslaveRepository : ITipProslaveRepository
    {
        private readonly AppDbContext context;

        public TipProslaveRepository(AppDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Metoda za dodavanje novog tipa proslave
        /// </summary>
        /// <param name="entity">Tip proslave koji treba da se doda</param>
        public void Add(TipProslave entity)
        {
            context.Add(entity);
        }

        /// <summary>
        /// Metoda za brisanje tipa proslave
        /// </summary>
        /// <param name="entity">Tip proslave koji treba da se obrise</param>
        public void Delete(TipProslave entity)
        {
            context.Remove(entity);
        }
        /// <summary>
        /// Metoda za vracanje tipova proslave
        /// </summary>
        public List<TipProslave> GetAll()
        {
            return context.TipoviProslave.ToList();
        }

        /// <summary>
        /// Metoda za pretragu tipova proslave na osnovu izraza
        /// </summary>
        /// <param name="predicate">Izraz na osnovu koga se vrsi pretraga</param>
        /// <returns>Lista tipova proslave koji zadovoljavaju prosledjeni izraz</returns>
        public List<TipProslave> SearchBy(Expression<Func<TipProslave, bool>> predicate)
        {
            return context.TipoviProslave.Where(predicate).ToList();
        }

        /// <summary>
        /// Metoda za pretragu tipa proslave na osnovu identifikatora prosledjenog tipa proslave
        /// </summary>
        /// <param name="entity">Objekat TipProslave na osnovu cijeg identifikatora se pretrazuje tip proslave</param>
        /// <returns>Tacno jedan tip proslave koji ima isti identifikator kao prosledjen tip proslave</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public TipProslave SearchById(TipProslave entity)
        {
            return context.TipoviProslave.Single(tp => tp.TipProslaveId == entity.TipProslaveId);

        }
        /// <summary>
        /// Metoda za pretragu tipa proslave na osnovu identifikatora
        /// </summary>
        /// <param name="id">Identifikator na osnovu kog se pretrazuje tip proslave</param>
        /// <returns>Tacno jedan tip proslave koji ima isti identifikator kao onaj prosledjen</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public TipProslave SearchByIntId(int id)
        {
            return context.TipoviProslave.Single(tp => tp.TipProslaveId == id);
        }
        /// <summary>
        /// Metoda za azuriranje tipa proslave
        /// </summary>
        /// <param name="entity">Tip proslave koji treba azurirati sa novim podacima</param>
        public void Update(TipProslave entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
