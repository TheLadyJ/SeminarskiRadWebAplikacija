using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWorkC : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWorkC(AppDbContext context)
        {
            this.context = context;
            KlijentRepository = new KlijentRepository(context);
            RadnikRepository = new RadnikRepository(context);
            RezervacijaRepository = new RezervacijaRepository(context);
            StoRepository = new StoRepository(context);

        }

        public IKlijentRepository KlijentRepository { get; set; }
        public IRadnikRepository RadnikRepository { get; set; }
        public IRezervacijaRepository RezervacijaRepository { get; set; }
        public IStoRepository StoRepository { get; set; }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
