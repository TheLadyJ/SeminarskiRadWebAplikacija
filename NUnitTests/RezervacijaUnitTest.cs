using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

namespace NUnitTests
{
    public class RezervacijaUnitTest
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private AppDbContext context;
        private IDbContextTransaction transaction;
        private List<Proizvodjac> proizvodjaci;
        private List<Mesto> mesta;
        private List<Sto> stolovi;
        private List<Klijent> klijenti;
        private List<Radnik> radnici;
        private List<KeteringFirma> keteringFirme;
        private List<KeteringMeni> keteringMeniji;
        private List<TipProslave> tipoviProslave;

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
            LoadKlijenti();
            LoadRadnici();
            LoadKeteringFirme();
            LoadKeteringMeniji();
            LoadTipoviProslave();
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
        public void CreateNewRezervacijaTest()
        {
            List<Sto> s = new List<Sto>
            {
                stolovi[0],
                stolovi[1]
            };

            Rezervacija rezervacija = new Rezervacija
            {
                Mesto = mesta[0],
                DatumVremeOd = new DateTime(2023, 5, 5, 15, 15, 0),
                DatumVremeDo = new DateTime(2023, 5, 5, 18, 15, 0),
                Klijent = klijenti[0],
                Radnik = radnici[0],
                TipProslave = tipoviProslave[0],
                UkupnaCena = 12000.0,
                KeteringMeni = keteringMeniji[0],
                Stolovi = s
            };

            UnitOfWork.RezervacijaRepository.Add(rezervacija);
            UnitOfWork.Save();

            Rezervacija sacuvanaRezervacija = UnitOfWork.RezervacijaRepository.SearchBy(r => r.DatumVremeOd == rezervacija.DatumVremeOd && r.DatumVremeDo == rezervacija.DatumVremeDo && r.Klijent == rezervacija.Klijent && r.Radnik == rezervacija.Radnik && r.TipProslave == rezervacija.TipProslave && r.UkupnaCena == rezervacija.UkupnaCena).First();


            Assert.IsTrue(sacuvanaRezervacija != null);

            UnitOfWork.RezervacijaRepository.Delete(sacuvanaRezervacija);
            UnitOfWork.Save();
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

            klijenti = UnitOfWork.KlijentRepository.GetAll();
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

            radnici = UnitOfWork.RadnikRepository.GetAll();
        }

        private void LoadKeteringFirme()
        {
            KeteringFirma kf1 = new KeteringFirma
            {
                NazivFirme = "Firma 1",
                Telefon = "0117778888",
                Email = "firma1@gmail.com"
            };

            KeteringFirma kf2 = new KeteringFirma
            {
                NazivFirme = "Firma 2",
                Telefon = "0117778887",
                Email = "firma2@gmail.com"
            };

            KeteringFirma kf3 = new KeteringFirma
            {
                NazivFirme = "Firma 3",
                Telefon = "0117778886",
                Email = "firma3@gmail.com"
            };

            UnitOfWork.KeteringFirmaRepository.Add(kf1);
            UnitOfWork.KeteringFirmaRepository.Add(kf2);
            UnitOfWork.KeteringFirmaRepository.Add(kf3);
            UnitOfWork.Save();


            keteringFirme = UnitOfWork.KeteringFirmaRepository.GetAll();
        }

        private void LoadKeteringMeniji()
        {
            KeteringMeni km1 = new KeteringMeni
            {
                KeteringFirma = keteringFirme[0],
                Predjelo = "Predjelo 1",
                GlavnoJelo = "Glavno jelo 1",
                Dezert = "Dezert 1",
                CenaHranePoOsobi = 500.0
            };

            KeteringMeni km2 = new KeteringMeni
            {
                KeteringFirma = keteringFirme[1],
                Predjelo = "Predjelo 2",
                GlavnoJelo = "Glavno jelo 2",
                Dezert = "Dezert 2",
                CenaHranePoOsobi = 550.0
            };

            KeteringMeni km3 = new KeteringMeni
            {
                KeteringFirma = keteringFirme[2],
                Predjelo = "Predjelo 3",
                GlavnoJelo = "Glavno jelo 3",
                Dezert = "Dezert 3",
                CenaHranePoOsobi = 600.0
            };

            UnitOfWork.KeteringMeniRepository.Add(km1);
            UnitOfWork.KeteringMeniRepository.Add(km2);
            UnitOfWork.KeteringMeniRepository.Add(km3);
            UnitOfWork.Save();

            keteringMeniji = UnitOfWork.KeteringMeniRepository.GetAll();
        }

        private void LoadTipoviProslave()
        {
            TipProslave tp1 = new TipProslave
            {
                NazivTipaProslave = "Privatna"
            };

            TipProslave tp2 = new TipProslave
            {
                NazivTipaProslave = "Korporativna"
            };

            UnitOfWork.TipProslaveRepository.Add(tp1);
            UnitOfWork.TipProslaveRepository.Add(tp2);
            UnitOfWork.Save();

            tipoviProslave = UnitOfWork.TipProslaveRepository.GetAll();
        }

    }
}