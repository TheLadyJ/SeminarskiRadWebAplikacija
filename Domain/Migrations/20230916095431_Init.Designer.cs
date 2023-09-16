﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230916095431_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.KeteringFirma", b =>
                {
                    b.Property<int>("KeteringFirmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KeteringFirmaId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivFirme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KeteringFirmaId");

                    b.ToTable("KeteringFirme");
                });

            modelBuilder.Entity("Domain.KeteringMeni", b =>
                {
                    b.Property<int>("KeteringMeniId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KeteringMeniId"), 1L, 1);

                    b.Property<double>("CenaHranePoOsobi")
                        .HasColumnType("float");

                    b.Property<string>("Dezert")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GlavnoJelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KeteringFirmaId")
                        .HasColumnType("int");

                    b.Property<string>("Predjelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KeteringMeniId");

                    b.HasIndex("KeteringFirmaId");

                    b.ToTable("KeteringMeniji");
                });

            modelBuilder.Entity("Domain.Klijent", b =>
                {
                    b.Property<int>("KlijentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlijentId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlijentId");

                    b.ToTable("Klijenti");
                });

            modelBuilder.Entity("Domain.Mesto", b =>
                {
                    b.Property<int>("MestoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MestoId"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MestoId");

                    b.ToTable("Mesta");
                });

            modelBuilder.Entity("Domain.Proizvodjac", b =>
                {
                    b.Property<int>("ProizvodjacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProizvodjacId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivProizvodjaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProizvodjacId");

                    b.ToTable("Proizvodjaci");
                });

            modelBuilder.Entity("Domain.Radnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RadnikId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RezervacijaId"), 1L, 1);

                    b.Property<DateTime>("DatumVremeDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumVremeOd")
                        .HasColumnType("datetime2");

                    b.Property<int>("KeteringMeniId")
                        .HasColumnType("int");

                    b.Property<int>("KlijentId")
                        .HasColumnType("int");

                    b.Property<int>("MestoId")
                        .HasColumnType("int");

                    b.Property<int>("RadnikId")
                        .HasColumnType("int");

                    b.Property<int>("TipProslaveId")
                        .HasColumnType("int");

                    b.Property<double>("UkupnaCena")
                        .HasColumnType("float");

                    b.HasKey("RezervacijaId");

                    b.HasIndex("KeteringMeniId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("MestoId");

                    b.HasIndex("RadnikId");

                    b.HasIndex("TipProslaveId");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("Domain.Sto", b =>
                {
                    b.Property<int>("RbStola")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RbStola"), 1L, 1);

                    b.Property<double>("CenaStola")
                        .HasColumnType("float");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.Property<int>("MestoId")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodjacId")
                        .HasColumnType("int");

                    b.HasKey("RbStola");

                    b.HasIndex("MestoId");

                    b.HasIndex("ProizvodjacId");

                    b.ToTable("Stolovi");
                });

            modelBuilder.Entity("Domain.TipProslave", b =>
                {
                    b.Property<int>("TipProslaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipProslaveId"), 1L, 1);

                    b.Property<string>("NazivTipaProslave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipProslaveId");

                    b.ToTable("TipoviProslave");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RezervacijaSto", b =>
                {
                    b.Property<int>("RezervacijeRezervacijaId")
                        .HasColumnType("int");

                    b.Property<int>("StoloviRbStola")
                        .HasColumnType("int");

                    b.HasKey("RezervacijeRezervacijaId", "StoloviRbStola");

                    b.HasIndex("StoloviRbStola");

                    b.ToTable("RezervacijaSto");
                });

            modelBuilder.Entity("Domain.KeteringMeni", b =>
                {
                    b.HasOne("Domain.KeteringFirma", "KeteringFirma")
                        .WithMany("Meniji")
                        .HasForeignKey("KeteringFirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KeteringFirma");
                });

            modelBuilder.Entity("Domain.Rezervacija", b =>
                {
                    b.HasOne("Domain.KeteringMeni", "KeteringMeni")
                        .WithMany("Rezervacije")
                        .HasForeignKey("KeteringMeniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Klijent", "Klijent")
                        .WithMany("Rezervacije")
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Mesto", "Mesto")
                        .WithMany("Rezervacije")
                        .HasForeignKey("MestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Radnik", "Radnik")
                        .WithMany("Rezervacije")
                        .HasForeignKey("RadnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TipProslave", "TipProslave")
                        .WithMany("Rezervacije")
                        .HasForeignKey("TipProslaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KeteringMeni");

                    b.Navigation("Klijent");

                    b.Navigation("Mesto");

                    b.Navigation("Radnik");

                    b.Navigation("TipProslave");
                });

            modelBuilder.Entity("Domain.Sto", b =>
                {
                    b.HasOne("Domain.Mesto", "Mesto")
                        .WithMany("Stolovi")
                        .HasForeignKey("MestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Proizvodjac", "Proizvodjac")
                        .WithMany("Stolovi")
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesto");

                    b.Navigation("Proizvodjac");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Radnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Radnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Radnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Radnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RezervacijaSto", b =>
                {
                    b.HasOne("Domain.Rezervacija", null)
                        .WithMany()
                        .HasForeignKey("RezervacijeRezervacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Sto", null)
                        .WithMany()
                        .HasForeignKey("StoloviRbStola")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.KeteringFirma", b =>
                {
                    b.Navigation("Meniji");
                });

            modelBuilder.Entity("Domain.KeteringMeni", b =>
                {
                    b.Navigation("Rezervacije");
                });

            modelBuilder.Entity("Domain.Klijent", b =>
                {
                    b.Navigation("Rezervacije");
                });

            modelBuilder.Entity("Domain.Mesto", b =>
                {
                    b.Navigation("Rezervacije");

                    b.Navigation("Stolovi");
                });

            modelBuilder.Entity("Domain.Proizvodjac", b =>
                {
                    b.Navigation("Stolovi");
                });

            modelBuilder.Entity("Domain.Radnik", b =>
                {
                    b.Navigation("Rezervacije");
                });

            modelBuilder.Entity("Domain.TipProslave", b =>
                {
                    b.Navigation("Rezervacije");
                });
#pragma warning restore 612, 618
        }
    }
}
