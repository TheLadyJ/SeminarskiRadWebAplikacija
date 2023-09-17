using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

namespace NUnitTests
{
    public class RadnikUnitTest
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private AppDbContext context;
        private IDbContextTransaction transaction;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=TestSeminarskiRadWebAplikacija; Trusted_Connection=True;");
            context = new AppDbContext(optionsBuilder.Options);
            UnitOfWork = new UnitOfWorkC(context);

            transaction = context.Database.BeginTransaction();

            LoadRadnici();
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
        public void CreateNewRadnikTest()
        {
            Radnik radnik = new Radnik
            {
                Ime = "Zika",
                Prezime = "Zikic",
                KorisnickoIme = "zika",
                Lozinka = "Zika123!"
            };

            UnitOfWork.RadnikRepository.Add(radnik);
            UnitOfWork.Save();

            Radnik sacuvanRadnik = UnitOfWork.RadnikRepository.SearchByUsernamePassword("zika", "Zika123!");

            Assert.IsTrue(sacuvanRadnik != null);

            UnitOfWork.RadnikRepository.Delete(sacuvanRadnik);
            UnitOfWork.Save();
        }

        [Test]
        public void UpdateRadnikTest()
        {
            Radnik radnik = UnitOfWork.RadnikRepository.SearchByUsernamePassword("pera", "Pera123!");

            radnik.Ime = "Zika";
            radnik.Prezime = "Zikic";
            radnik.KorisnickoIme = "zika";
            radnik.Lozinka = "Zika123!";

            UnitOfWork.RadnikRepository.Update(radnik);
            UnitOfWork.Save();

            Radnik sacuvanRadnik = UnitOfWork.RadnikRepository.SearchByUsernamePassword("zika", "Zika123!");
            Assert.IsTrue(sacuvanRadnik != null);
        }


        [Test]
        public void DeleteRadnikTest()
        {
            Radnik radnik = UnitOfWork.RadnikRepository.SearchByUsernamePassword("pera", "Pera123!");

            UnitOfWork.RadnikRepository.Delete(radnik);
            UnitOfWork.Save();

            Radnik obrisanRadnik = UnitOfWork.RadnikRepository.SearchByUsernamePassword("pera", "Pera123!");
            Assert.IsTrue(obrisanRadnik == null);
        }

        private void LoadRadnici()
        {
            Radnik radnik2 = new Radnik
            {
                Ime = "Vera",
                Prezime = "veric",
                KorisnickoIme = "vera",
                Lozinka = "Vera123!"
            };

            Radnik radnik3 = new Radnik
            {
                Ime = "Mika",
                Prezime = "mikic",
                KorisnickoIme = "mika",
                Lozinka = "Mika123!"
            };

            UnitOfWork.RadnikRepository.Add(radnik2);
            UnitOfWork.RadnikRepository.Add(radnik3);
            UnitOfWork.Save();

        }

    }
}