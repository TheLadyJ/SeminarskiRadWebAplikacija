using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

namespace NUnitTests
{
    public class StoUnitTest
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private AppDbContext context;
        private IDbContextTransaction transaction;
        private List<Proizvodjac> proizvodjaci;
        private List<Mesto> mesta;
        private List<Sto> stolovi;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=TestSeminarskiRadWebAplikacija; Trusted_Connection=True;");
            context = new AppDbContext(optionsBuilder.Options);
            UnitOfWork = new UnitOfWorkC(context);

            transaction = context.Database.BeginTransaction();

            LoadProizvodjaci();
            LoadMesta();
            LoadStolovi();
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                transaction.Rollback();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error rolling back transaction: " + ex.Message);
            }
            finally
            {
                transaction.Dispose();
                context.Dispose();
            }
        }

        [Test]
        public void CreateNewStoTest()
        {
            Sto sto = new Sto
            {
                Kapacitet = 8,
                CenaStola = 180.0,
                Proizvodjac = proizvodjaci[0],
                Mesto = mesta[1]
            };

            UnitOfWork.StoRepository.Add(sto);
            UnitOfWork.Save();

            Sto sacuvanSto = UnitOfWork.StoRepository.SearchBy(s => s.Kapacitet == sto.Kapacitet && s.CenaStola == sto.CenaStola && s.Proizvodjac == sto.Proizvodjac && s.Mesto == sto.Mesto).First();

            Assert.IsTrue(sacuvanSto != null);

            UnitOfWork.StoRepository.Delete(sto);
            UnitOfWork.Save();
        }

        [Test]
        public void UpdateStoTest()
        {
            Sto sto = UnitOfWork.StoRepository.SearchById(stolovi[0]);

            sto.Kapacitet = 7;
            sto.CenaStola = 170.0;
            sto.Proizvodjac = proizvodjaci[1];
            sto.Mesto = mesta[2];

            UnitOfWork.StoRepository.Update(sto);
            UnitOfWork.Save();

            Sto sacuvanSto = UnitOfWork.StoRepository.SearchById(stolovi[0]);


            Assert.IsTrue(sacuvanSto != null);
            Assert.IsTrue(sacuvanSto.Kapacitet == sto.Kapacitet);
            Assert.IsTrue(sacuvanSto.Proizvodjac == sto.Proizvodjac);
            Assert.IsTrue(sacuvanSto.Mesto == sto.Mesto);
            Assert.IsTrue(sacuvanSto.CenaStola == sto.CenaStola);
        }


        [Test]
        public void DeleteStoTest()
        {
            Sto sto = UnitOfWork.StoRepository.SearchById(stolovi[1]);

            UnitOfWork.StoRepository.Delete(sto);
            UnitOfWork.Save();

            Assert.Catch(() =>
            {
                Sto obrisanSto = UnitOfWork.StoRepository.SearchById(stolovi[1]);
            });
        }


        private void LoadProizvodjaci()
        {
            Proizvodjac p1 = new Proizvodjac
            {
                NazivProizvodjaca = "Proizvodjac 1",
                Telefon = "0110002225555",
                Email = "email1@gmail.com",
            };
            Proizvodjac p2 = new Proizvodjac
            {
                NazivProizvodjaca = "Proizvodjac 2",
                Telefon = "0110002224444",
                Email = "email2@gmail.com",
            };

            UnitOfWork.ProizvodjacRepository.Add(p1);
            UnitOfWork.ProizvodjacRepository.Add(p2);
            UnitOfWork.Save();

            proizvodjaci = UnitOfWork.ProizvodjacRepository.GetAll();
        }

        private void LoadMesta()
        {
            Mesto m1 = new Mesto
            {
                Adresa = "Adresa 1",
                PostanskiBroj = "11000",
                Grad = "Beograd"
            };

            Mesto m2 = new Mesto
            {
                Adresa = "Adresa 2",
                PostanskiBroj = "21000",
                Grad = "Novi Sad"
            };

            Mesto m3 = new Mesto
            {
                Adresa = "Adresa 3",
                PostanskiBroj = "24000",
                Grad = "Subotica"
            };

            UnitOfWork.MestoRepository.Add(m1);
            UnitOfWork.MestoRepository.Add(m2);
            UnitOfWork.MestoRepository.Add(m3);
            UnitOfWork.Save();

            mesta = UnitOfWork.MestoRepository.GetAll();
        }

        private void LoadStolovi()
        {
            Sto sto1 = new Sto
            {
                Kapacitet = 10,
                CenaStola = 200.0,
                Proizvodjac = proizvodjaci[0],
                Mesto = mesta[0]
            };

            Sto sto2 = new Sto
            {
                Kapacitet = 12,
                CenaStola = 220.0,
                Proizvodjac = proizvodjaci[1],
                Mesto = mesta[2]
            };

            UnitOfWork.StoRepository.Add(sto1);
            UnitOfWork.StoRepository.Add(sto2);
            UnitOfWork.Save();

            stolovi = UnitOfWork.StoRepository.GetAll();
        }

    }
}