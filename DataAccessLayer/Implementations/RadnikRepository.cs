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

        public void Add(Radnik entity)
        {
            context.Add(entity);
        }

        public void Delete(Radnik entity)
        {
            context.Remove(entity);
        }

        public List<Radnik> GetAll()
        {
            return context.Radnici.ToList();
        }

        public List<Radnik> SearchBy(Expression<Func<Radnik, bool>> predicate)
        {
            return context.Radnici.Where(predicate).ToList();
        }

        public Radnik SearchById(Radnik entity)
        {
            return context.Radnici.Single(r => r.Id == entity.RadnikId);
        }

        public Radnik SearchByIntId(int id)
        {
            return context.Radnici.Single(r => r.Id == id);
        }

        public Radnik SearchByUsernamePassword(string username, string password)
        {
            return context.Radnici.SingleOrDefault(t => t.KorisnickoIme == username && t.Lozinka == password);
        }

        public void Update(Radnik entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
