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
    public class KeteringFirmaRepository : IKeteringFirmaRepository
    {
        private readonly AppDbContext context;

        public KeteringFirmaRepository(AppDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Metoda za dodavanje nove ketering firme
        /// </summary>
        /// <param name="entity">Ketering firma koja treba da se doda</param>
        public void Add(KeteringFirma entity)
        {
            context.Add(entity);
        }
        /// <summary>
        /// Metoda za brisanje ketering firme
        /// </summary>
        /// <param name="entity">Ketering firma koja treba da se obrise</param>
        public void Delete(KeteringFirma entity)
        {
            context.Remove(entity);
        }
        /// <summary>
        /// Metoda za vracanje svih ketering firmi
        /// </summary>
        public List<KeteringFirma> GetAll()
        {
            return context.KeteringFirme.ToList();

        }

        /// <summary>
        /// Metoda za pretragu ketering firme na osnovu izraza
        /// </summary>
        /// <param name="predicate">Izraz na osnovu koga se vrsi pretraga</param>
        /// <returns>Lista ketering firmi koje zadovoljavaju prosledjeni izraz</returns>
        public List<KeteringFirma> SearchBy(Expression<Func<KeteringFirma, bool>> predicate)
        {
            return context.KeteringFirme.Where(predicate).ToList();

        }

        /// <summary>
        /// Metoda za pretragu ketering firme na osnovu identifikatora prosledjene ketering firme
        /// </summary>
        /// <param name="entity">Objekat KeteringFirma na osnovu cijeg identifikatora se pretrazuje ketering firma</param>
        /// <returns>Tacno jedna ketering firma koja ima isti identifikator kao prosledjena ketering firma</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public KeteringFirma SearchById(KeteringFirma entity)
        {
            return context.KeteringFirme.Single(kf => kf.KeteringFirmaId == entity.KeteringFirmaId);

        }
        /// <summary>
        /// Metoda za pretragu ketering firme na osnovu identifikatora
        /// </summary>
        /// <param name="id">Identifikator na osnovu kog se pretrazuje ketering firma</param>
        /// <returns>Tacno jedna ketering firma koja ima isti identifikator kao onaj prosledjen</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public KeteringFirma SearchByIntId(int id)
        {
            return context.KeteringFirme.Single(kf => kf.KeteringFirmaId == id);

        }

        /// <summary>
        /// Metoda za azuriranje ketering firme
        /// </summary>
        /// <param name="entity">Ketering firma koju treba azurirati sa novim podacima</param>
        public void Update(KeteringFirma entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
