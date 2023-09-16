using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IKlijentRepository KlijentRepository { get; set; }
        public IRadnikRepository RadnikRepository { get; set; }
        public IRezervacijaRepository RezervacijaRepository { get; set; }
        public IStoRepository StoRepository { get; set; }
        public IProizvodjacRepository ProizvodjacRepository { get; set; }
        public IKeteringFirmaRepository KeteringFirmaRepository { get; set; }
        public IKeteringMeniRepository KeteringMeniRepository { get; set; }
        public ITipProslaveRepository TipProslaveRepository { get; set; }
        public IMestoRepository MestoRepository { get; set; }



        public void Save();
    }
}
