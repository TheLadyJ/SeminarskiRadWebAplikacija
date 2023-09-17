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
    public class ProizvodjacRepository : IProizvodjacRepository
    {
        private readonly AppDbContext context;

        public ProizvodjacRepository(AppDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Metoda za dodavanje novog proizvodjaca
        /// </summary>
        /// <param name="entity">Proizvodjac koji treba da se doda</param>
        public void Add(Proizvodjac entity)
        {
            context.Add(entity);
        }
        /// <summary>
        /// Metoda za brisanje proizvodjaca
        /// </summary>
        /// <param name="entity">Proizvodjac koji treba da se obrise</param>
        public void Delete(Proizvodjac entity)
        {
            context.Remove(entity);
        }
        /// <summary>
        /// Metoda za vracanje svih proizvodjaca
        /// </summary>
        public List<Proizvodjac> GetAll()
        {
            return context.Proizvodjaci.ToList();

        }
        /// <summary>
        /// Metoda za pretragu proizvodjaca na osnovu izraza
        /// </summary>
        /// <param name="predicate">Izraz na osnovu koga se vrsi pretraga</param>
        /// <returns>Lista proizvodjaca koji zadovoljavaju prosledjeni izraz</returns>
        public List<Proizvodjac> SearchBy(Expression<Func<Proizvodjac, bool>> predicate)
        {
            return context.Proizvodjaci.Where(predicate).ToList();
        }
        /// <summary>
        /// Metoda za pretragu proizvodjaca na osnovu identifikatora prosledjenog proizvodjaca
        /// </summary>
        /// <param name="entity">Objekat Proizvodjac na osnovu cijeg identifikatora se pretrazuje proizvodjac</param>
        /// <returns>Tacno jedan proizvodjac koji ima isti identifikator kao prosledjen proizvodjac</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Proizvodjac SearchById(Proizvodjac entity)
        {
            return context.Proizvodjaci.Single(p => p.ProizvodjacId == entity.ProizvodjacId);

        }
        /// <summary>
        /// Metoda za pretragu proizvodjaca na osnovu identifikatora
        /// </summary>
        /// <param name="id">Identifikator na osnovu kog se pretrazuje proizvodjac</param>
        /// <returns>Tacno jedan proizvodjac koji ima isti identifikator kao onaj prosledjen</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Proizvodjac SearchByIntId(int id)
        {
            return context.Proizvodjaci.Single(p => p.ProizvodjacId == id);

        }
        /// <summary>
        /// Metoda za azuriranje proizvodjaca
        /// </summary>
        /// <param name="entity">Proizvodjac koji treba azurirati sa novim podacima</param>
        public void Update(Proizvodjac entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
