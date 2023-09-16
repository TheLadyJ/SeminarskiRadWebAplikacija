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
        public void Add(TipProslave entity)
        {
            context.Add(entity);
        }

        public void Delete(TipProslave entity)
        {
            context.Remove(entity);
        }
        public List<TipProslave> GetAll()
        {
            return context.TipoviProslave.ToList();
        }

        public List<TipProslave> SearchBy(Expression<Func<TipProslave, bool>> predicate)
        {
            return context.TipoviProslave.Where(predicate).ToList();
        }

        public TipProslave SearchById(TipProslave entity)
        {
            return context.TipoviProslave.Single(tp => tp.TipProslaveId == entity.TipProslaveId);

        }

        public TipProslave SearchByIntId(int id)
        {
            return context.TipoviProslave.Single(tp => tp.TipProslaveId == id);
        }

        public void Update(TipProslave entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
