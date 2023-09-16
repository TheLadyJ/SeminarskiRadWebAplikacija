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
        public void Add(Proizvodjac entity)
        {
            context.Add(entity);
        }

        public void Delete(Proizvodjac entity)
        {
            context.Remove(entity);
        }

        public List<Proizvodjac> GetAll()
        {
            return context.Proizvodjaci.ToList();

        }

        public List<Proizvodjac> SearchBy(Expression<Func<Proizvodjac, bool>> predicate)
        {
            return context.Proizvodjaci.Where(predicate).ToList();
        }

        public Proizvodjac SearchById(Proizvodjac entity)
        {
            return context.Proizvodjaci.Single(p => p.ProizvodjacId == entity.ProizvodjacId);

        }

        public Proizvodjac SearchByIntId(int id)
        {
            return context.Proizvodjaci.Single(p => p.ProizvodjacId == id);

        }

        public void Update(Proizvodjac entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
