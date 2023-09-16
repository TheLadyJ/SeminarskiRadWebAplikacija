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
        public void Add(KeteringFirma entity)
        {
            context.Add(entity);
        }

        public void Delete(KeteringFirma entity)
        {
            context.Remove(entity);
        }

        public List<KeteringFirma> GetAll()
        {
            return context.KeteringFirme.ToList();

        }

        public List<KeteringFirma> SearchBy(Expression<Func<KeteringFirma, bool>> predicate)
        {
            return context.KeteringFirme.Where(predicate).ToList();

        }

        public KeteringFirma SearchById(KeteringFirma entity)
        {
            return context.KeteringFirme.Single(kf => kf.KeteringFirmaId == entity.KeteringFirmaId);

        }

        public KeteringFirma SearchByIntId(int id)
        {
            return context.KeteringFirme.Single(kf => kf.KeteringFirmaId == id);

        }

        public void Update(KeteringFirma entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
