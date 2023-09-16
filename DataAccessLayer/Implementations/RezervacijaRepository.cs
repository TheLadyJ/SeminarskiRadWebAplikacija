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
    public class RezervacijaRepository : IRezervacijaRepository
    {
        private readonly AppDbContext context;

        public RezervacijaRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Rezervacija entity)
        {
            context.Add(entity);
        }

        public void Delete(Rezervacija entity)
        {
            context.Remove(entity);
        }

        public List<Rezervacija> GetAll()
        {
            return context.Rezervacije.Include(r => r.Klijent).Include(r => r.Radnik).Include(r => r.KeteringMeni).Include(r => r.Mesto).Include(r => r.TipProslave).ToList();
        }

        public List<Rezervacija> SearchBy(Expression<Func<Rezervacija, bool>> predicate)
        {
            return context.Rezervacije.Include(r => r.Klijent).Include(r => r.Radnik).Include(r => r.KeteringMeni).Include(r => r.Mesto).Include(r => r.TipProslave).Where(predicate).ToList();
        }

        public Rezervacija SearchById(Rezervacija entity)
        {
            return context.Rezervacije.Include(r => r.Klijent).Include(r => r.Radnik).Include(r => r.KeteringMeni).Include(r => r.Mesto).Include(r => r.TipProslave).Single(r => r.RezervacijaId == entity.RezervacijaId);
        }

        public Rezervacija SearchByIntId(int id)
        {
            return context.Rezervacije.Include(r => r.Klijent).Include(r => r.Radnik).Include(r => r.KeteringMeni).Include(r => r.Mesto).Include(r => r.TipProslave).Single(r => r.RezervacijaId == id);
        }

        public void Update(Rezervacija entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
