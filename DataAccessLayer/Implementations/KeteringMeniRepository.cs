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
    public class KeteringMeniRepository : IKeteringMeniRepository
    {
        private readonly AppDbContext context;

        public KeteringMeniRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Metoda za dodavanje novog ketering menija
        /// </summary>
        /// <param name="entity">Ketering meni koji treba da se doda</param>
        public void Add(KeteringMeni entity)
        {
            context.Add(entity);
        }

        /// <summary>
        /// Metoda za brisanje ketering menija
        /// </summary>
        /// <param name="entity">Ketering meni koji treba da se obrise</param>
        public void Delete(KeteringMeni entity)
        {
            context.Remove(entity);
        }
        /// <summary>
        /// Metoda za vracanje svih ketering menija
        /// </summary>
        public List<KeteringMeni> GetAll()
        {
            return context.KeteringMeniji.ToList();
        }
        /// <summary>
        /// Metoda za pretragu ketering menija na osnovu izraza
        /// </summary>
        /// <param name="predicate">Izraz na osnovu koga se vrsi pretraga</param>
        /// <returns>Lista ketering menija koji zadovoljavaju prosledjeni izraz</returns>
        public List<KeteringMeni> SearchBy(Expression<Func<KeteringMeni, bool>> predicate)
        {
            return context.KeteringMeniji.Where(predicate).ToList();
        }
        /// <summary>
        /// Metoda za pretragu ketering menija na osnovu identifikatora prosledjenog ketering menija
        /// </summary>
        /// <param name="entity">Objekat KeteringMeni na osnovu cijeg identifikatora se pretrazuje ketering meni</param>
        /// <returns>Tacno jedan ketering meni koji ima isti identifikator kao prosledjen ketering meni</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public KeteringMeni SearchById(KeteringMeni entity)
        {
            return context.KeteringMeniji.Single(km => km.KeteringMeniId == entity.KeteringMeniId);
        }
        /// <summary>
        /// Metoda za pretragu ketering menija na osnovu identifikatora
        /// </summary>
        /// <param name="id">Identifikator na osnovu kog se pretrazuje ketering mani</param>
        /// <returns>Tacno jedan ketering meni koja ima isti identifikator kao onaj prosledjen</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public KeteringMeni SearchByIntId(int id)
        {
            return context.KeteringMeniji.Single(km => km.KeteringMeniId == id);
        }
        /// <summary>
        /// Metoda za azuriranje ketering menija
        /// </summary>
        /// <param name="entity">Ketering meni koji treba azurirati sa novim podacima</param>
        public void Update(KeteringMeni entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
