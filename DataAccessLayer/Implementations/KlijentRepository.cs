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

        public void Add(Klijent entity)
        {
            context.Add(entity);
        }

        public void Delete(Klijent entity)
        {
            context.Remove(entity);
        }

        public List<Klijent> GetAll()
        {
            return context.Klijenti.ToList();
        }

        public List<Klijent> SearchBy(Expression<Func<Klijent, bool>> predicate)
        {
            return context.Klijenti.Where(predicate).ToList();
        }

        public Klijent SearchById(Klijent entity)
        {
            return context.Klijenti.Single(k => k.KlijentId == entity.KlijentId);
        }

        public Klijent SearchByIntId(int id)
        {
            return context.Klijenti.Single(k => k.KlijentId == id);
        }

        public void Update(Klijent entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
