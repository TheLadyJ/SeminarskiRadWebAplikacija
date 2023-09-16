using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppDbContext : IdentityDbContext<Radnik, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Mesto> Mesta { get; set; }
        public DbSet<Sto> Stolovi { get; set; }
        public DbSet<Proizvodjac> Proizvodjaci { get; set; }
        public DbSet<KeteringFirma> KeteringFirme { get; set; }
        public DbSet<KeteringMeni> KeteringMeniji { get; set; }
        public DbSet<TipProslave> TipoviProslave { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
				Database=SeminarskiRadWebAplikacija; Trusted_Connection=True;")
                .LogTo(message => Debug.WriteLine(message))
                .EnableSensitiveDataLogging(true);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Sto>().HasKey(s => s.RbStola);
            builder.Entity<Sto>().HasOne(s => s.Mesto).WithMany(m => m.Stolovi).HasForeignKey(s => s.MestoId);
            builder.Entity<Sto>().HasOne(s => s.Proizvodjac).WithMany(p => p.Stolovi).HasForeignKey(s => s.ProizvodjacId);

            builder.Entity<Rezervacija>().HasMany(r => r.Stolovi).WithMany(s => s.Rezervacije);
            builder.Entity<Rezervacija>().HasOne(re => re.Radnik).WithMany(ra => ra.Rezervacije).HasForeignKey(re => re.RadnikId);
            builder.Entity<Rezervacija>().HasOne(re => re.Klijent).WithMany(k => k.Rezervacije).HasForeignKey(re => re.KlijentId);
            builder.Entity<Rezervacija>().HasOne(re => re.TipProslave).WithMany(t => t.Rezervacije).HasForeignKey(re => re.TipProslaveId);
            builder.Entity<Rezervacija>().HasOne(re => re.Mesto).WithMany(m => m.Rezervacije).HasForeignKey(re => re.MestoId);
            builder.Entity<Rezervacija>().HasOne(re => re.KeteringMeni).WithMany(km => km.Rezervacije).HasForeignKey(re => re.KeteringMeniId);

            builder.Entity<KeteringMeni>().HasOne(km => km.KeteringFirma).WithMany(kf => kf.Meniji).HasForeignKey(km => km.KeteringFirmaId);

        }
    }
}
