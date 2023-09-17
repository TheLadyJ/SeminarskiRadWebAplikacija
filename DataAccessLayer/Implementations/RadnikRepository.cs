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
    public class RadnikRepository : IRadnikRepository
    {
        private readonly AppDbContext context;

        public RadnikRepository(AppDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Metoda za dodavanje novog radnika
        /// </summary>
        /// <param name="entity">Radnik koji treba da se doda</param>
        public void Add(Radnik entity)
        {
            context.Add(entity);
        }
        /// <summary>
        /// Metoda za brisanje radnika
        /// </summary>
        /// <param name="entity">Radnik koji treba da se obrise</param>
        public void Delete(Radnik entity)
        {
            context.Remove(entity);
        }
        /// <summary>
        /// Metoda za vracanje svih radnika
        /// </summary>
        public List<Radnik> GetAll()
        {
            return context.Radnici.ToList();
        }
        /// <summary>
        /// Metoda za pretragu radnika na osnovu izraza
        /// </summary>
        /// <param name="predicate">Izraz na osnovu koga se vrsi pretraga</param>
        /// <returns>Lista radnika koji zadovoljavaju prosledjeni izraz</returns>
        public List<Radnik> SearchBy(Expression<Func<Radnik, bool>> predicate)
        {
            return context.Radnici.Where(predicate).ToList();
        }
        /// <summary>
        /// Metoda za pretragu radnika na osnovu identifikatora prosledjenog radnika
        /// </summary>
        /// <param name="entity">Objekat Radnik na osnovu cijeg identifikatora se pretrazuje radnik</param>
        /// <returns>Tacno jedan radnik koji ima isti identifikator kao prosledjen radnik</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Radnik SearchById(Radnik entity)
        {
            return context.Radnici.Single(r => r.Id == entity.RadnikId);
        }
        /// <summary>
        /// Metoda za pretragu radnika na osnovu identifikatora
        /// </summary>
        /// <param name="id">Identifikator na osnovu kog se pretrazuje radnik</param>
        /// <returns>Tacno jedan radnik koji ima isti identifikator kao onaj prosledjen</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Radnik SearchByIntId(int id)
        {
            return context.Radnici.Single(r => r.Id == id);
        }

        /// <summary>
        /// Metoda za pretragu radnika na osnovu korisnickog imena i lozinke
        /// </summary>
        /// <param name="username">Korisnicko ime radnika</param>
        /// <param name="password">Lozinka radnika</param>
        /// <returns>Radnik koji ima prosledjene korisnicko ime i lozinku. U slucaju da takav radnik ne postoji vraca se null</returns>
        public Radnik SearchByUsernamePassword(string username, string password)
        {
            return context.Radnici.SingleOrDefault(t => t.KorisnickoIme == username && t.Lozinka == password);
        }
        /// <summary>
        /// Metoda za azuriranje radnika
        /// </summary>
        /// <param name="entity">Radnik koji treba azurirati sa novim podacima</param>
        public void Update(Radnik entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
