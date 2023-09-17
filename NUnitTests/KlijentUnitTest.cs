using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

namespace NUnitTests
{
    public class KlijentUnitTest
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

            LoadKlijenti();
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
        public void CreateNewKlijentTest()
        {
            Klijent k = new Klijent
            {
                Ime = "Vanja",
                Prezime = "Vanjic",
                Telefon = "011777889",
                Email = "vanja@gmail.com"
            };

            UnitOfWork.KlijentRepository.Add(k);
            UnitOfWork.Save();

            Klijent sacuvanKlijent = UnitOfWork.KlijentRepository.SearchBy(k => k.Email == "vanja@gmail.com").First();

            Assert.IsTrue(sacuvanKlijent != null);

            UnitOfWork.KlijentRepository.Delete(sacuvanKlijent);
            UnitOfWork.Save();
        }

        [Test]
        public void UpdateKlijentTest()
        {
            Klijent k = UnitOfWork.KlijentRepository.SearchBy(k => k.Email == "tanja@gmail.com").First();

            k.Ime = "Igor";
            k.Prezime = "Igic";
            k.Telefon = "0612223334";
            k.Email = "igor@gmail.com";

            UnitOfWork.KlijentRepository.Update(k);
            UnitOfWork.Save();

            Klijent sacuvanKlijent = UnitOfWork.KlijentRepository.SearchBy(kl => kl.Ime == k.Ime && kl.Prezime == k.Prezime && kl.Telefon == k.Telefon && kl.Email == k.Email).First();

            Assert.IsTrue(sacuvanKlijent != null);
        }


        [Test]
        public void DeleteKlijentTest()
        {
            Klijent klijent = UnitOfWork.KlijentRepository.SearchBy(k => k.Email == "luka@gmail.com").First();

            UnitOfWork.KlijentRepository.Delete(klijent);
            UnitOfWork.Save();

            List<Klijent> klijenti = UnitOfWork.KlijentRepository.SearchBy(k => k.Email == "luka@gmail.com");
            Assert.IsTrue(klijenti.Count == 0);
        }

        private void LoadKlijenti()
        {
            Klijent k1 = new Klijent
            {
                Ime = "Tanja",
                Prezime = "Savic",
                Telefon = "0661112223",
                Email = "tanja@gmail.com"
            };

            Klijent k2 = new Klijent
            {
                Ime = "Luka",
                Prezime = "Lukic",
                Telefon = "0665554443",
                Email = "luka@gmail.com"
            };

            UnitOfWork.KlijentRepository.Add(k1);
            UnitOfWork.KlijentRepository.Add(k2);
            UnitOfWork.Save();

        }

    }
}