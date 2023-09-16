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
        public void Add(Sto entity)
        {
            context.Add(entity);
        }

        public void Delete(Sto entity)
        {
            context.Remove(entity);
        }

        public List<Sto> GetAll()
        {
            return context.Stolovi.ToList();
        }

        public List<Sto> SearchBy(Expression<Func<Sto, bool>> predicate)
        {
            return context.Stolovi.Where(predicate).ToList();
        }

        public Sto SearchById(Sto entity)
        {
            return context.Stolovi.Single(s => s.RbStola == entity.RbStola);
        }

        public Sto SearchByIntId(int rbStola)
        {
            return context.Stolovi.Single(s => s.RbStola == rbStola);
        }

        public void Update(Sto entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
