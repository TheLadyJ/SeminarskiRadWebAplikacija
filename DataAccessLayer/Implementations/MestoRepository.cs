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
        public void Add(Mesto entity)
        {
            context.Add(entity);
        }

        public void Delete(Mesto entity)
        {
            context.Remove(entity);
        }

        public List<Mesto> GetAll()
        {
            return context.Mesta.ToList();

        }

        public List<Mesto> SearchBy(Expression<Func<Mesto, bool>> predicate)
        {
            return context.Mesta.Where(predicate).ToList();

        }

        public Mesto SearchById(Mesto entity)
        {
            return context.Mesta.Single(m => m.MestoId == entity.MestoId);
        }

        public Mesto SearchByIntId(int id)
        {
            return context.Mesta.Single(m => m.MestoId == id);

        }

        public void Update(Mesto entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
