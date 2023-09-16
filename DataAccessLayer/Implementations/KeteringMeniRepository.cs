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
        public void Add(KeteringMeni entity)
        {
            context.Add(entity);
        }

        public void Delete(KeteringMeni entity)
        {
            context.Remove(entity);
        }

        public List<KeteringMeni> GetAll()
        {
            return context.KeteringMeniji.ToList();
        }

        public List<KeteringMeni> SearchBy(Expression<Func<KeteringMeni, bool>> predicate)
        {
            return context.KeteringMeniji.Where(predicate).ToList();
        }

        public KeteringMeni SearchById(KeteringMeni entity)
        {
            return context.KeteringMeniji.Single(km => km.KeteringMeniId == entity.KeteringMeniId);
        }

        public KeteringMeni SearchByIntId(int id)
        {
            return context.KeteringMeniji.Single(km => km.KeteringMeniId == id);
        }

        public void Update(KeteringMeni entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
