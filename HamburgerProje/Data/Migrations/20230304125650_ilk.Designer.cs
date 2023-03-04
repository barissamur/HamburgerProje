﻿// <auto-generated />
using HamburgerProje.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HamburgerProje.Data.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20230304125650_ilk")]
    partial class ilk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EkstraMenu", b =>
                {
                    b.Property<int>("EkstralarId")
                        .HasColumnType("int");

                    b.Property<int>("MenulerId")
                        .HasColumnType("int");

                    b.HasKey("EkstralarId", "MenulerId");

                    b.HasIndex("MenulerId");

                    b.ToTable("EkstraMenu");
                });

            modelBuilder.Entity("EkstraSiparis", b =>
                {
                    b.Property<int>("EkstralarId")
                        .HasColumnType("int");

                    b.Property<int>("SiparislerId")
                        .HasColumnType("int");

                    b.HasKey("EkstralarId", "SiparislerId");

                    b.HasIndex("SiparislerId");

                    b.ToTable("EkstraSiparis");
                });

            modelBuilder.Entity("HamburgerMenu", b =>
                {
                    b.Property<int>("HamburgerlerId")
                        .HasColumnType("int");

                    b.Property<int>("MenulerId")
                        .HasColumnType("int");

                    b.HasKey("HamburgerlerId", "MenulerId");

                    b.HasIndex("MenulerId");

                    b.ToTable("HamburgerMenu");
                });

            modelBuilder.Entity("HamburgerProje.Data.Ekstra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ekstralar");
                });

            modelBuilder.Entity("HamburgerProje.Data.Hamburger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hamburgerler");
                });

            modelBuilder.Entity("HamburgerProje.Data.Icecek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Icecekler");
                });

            modelBuilder.Entity("HamburgerProje.Data.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menuler");
                });

            modelBuilder.Entity("HamburgerProje.Data.Siparis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Toplam")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Siparisler");
                });

            modelBuilder.Entity("HamburgerProje.Data.Sos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Soslar");
                });

            modelBuilder.Entity("HamburgerSiparis", b =>
                {
                    b.Property<int>("HamburgerlerId")
                        .HasColumnType("int");

                    b.Property<int>("SiparislerId")
                        .HasColumnType("int");

                    b.HasKey("HamburgerlerId", "SiparislerId");

                    b.HasIndex("SiparislerId");

                    b.ToTable("HamburgerSiparis");
                });

            modelBuilder.Entity("IcecekMenu", b =>
                {
                    b.Property<int>("IceceklerId")
                        .HasColumnType("int");

                    b.Property<int>("MenulerId")
                        .HasColumnType("int");

                    b.HasKey("IceceklerId", "MenulerId");

                    b.HasIndex("MenulerId");

                    b.ToTable("IcecekMenu");
                });

            modelBuilder.Entity("IcecekSiparis", b =>
                {
                    b.Property<int>("IceceklerId")
                        .HasColumnType("int");

                    b.Property<int>("SiparislerId")
                        .HasColumnType("int");

                    b.HasKey("IceceklerId", "SiparislerId");

                    b.HasIndex("SiparislerId");

                    b.ToTable("IcecekSiparis");
                });

            modelBuilder.Entity("MenuSiparis", b =>
                {
                    b.Property<int>("MenulerId")
                        .HasColumnType("int");

                    b.Property<int>("SiparislerId")
                        .HasColumnType("int");

                    b.HasKey("MenulerId", "SiparislerId");

                    b.HasIndex("SiparislerId");

                    b.ToTable("MenuSiparis");
                });

            modelBuilder.Entity("MenuSos", b =>
                {
                    b.Property<int>("MenulerId")
                        .HasColumnType("int");

                    b.Property<int>("SoslarId")
                        .HasColumnType("int");

                    b.HasKey("MenulerId", "SoslarId");

                    b.HasIndex("SoslarId");

                    b.ToTable("MenuSos");
                });

            modelBuilder.Entity("SiparisSos", b =>
                {
                    b.Property<int>("SiparislerId")
                        .HasColumnType("int");

                    b.Property<int>("SoslarId")
                        .HasColumnType("int");

                    b.HasKey("SiparislerId", "SoslarId");

                    b.HasIndex("SoslarId");

                    b.ToTable("SiparisSos");
                });

            modelBuilder.Entity("EkstraMenu", b =>
                {
                    b.HasOne("HamburgerProje.Data.Ekstra", null)
                        .WithMany()
                        .HasForeignKey("EkstralarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerProje.Data.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenulerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EkstraSiparis", b =>
                {
                    b.HasOne("HamburgerProje.Data.Ekstra", null)
                        .WithMany()
                        .HasForeignKey("EkstralarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerProje.Data.Siparis", null)
                        .WithMany()
                        .HasForeignKey("SiparislerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HamburgerMenu", b =>
                {
                    b.HasOne("HamburgerProje.Data.Hamburger", null)
                        .WithMany()
                        .HasForeignKey("HamburgerlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerProje.Data.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenulerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HamburgerSiparis", b =>
                {
                    b.HasOne("HamburgerProje.Data.Hamburger", null)
                        .WithMany()
                        .HasForeignKey("HamburgerlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerProje.Data.Siparis", null)
                        .WithMany()
                        .HasForeignKey("SiparislerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IcecekMenu", b =>
                {
                    b.HasOne("HamburgerProje.Data.Icecek", null)
                        .WithMany()
                        .HasForeignKey("IceceklerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerProje.Data.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenulerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IcecekSiparis", b =>
                {
                    b.HasOne("HamburgerProje.Data.Icecek", null)
                        .WithMany()
                        .HasForeignKey("IceceklerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerProje.Data.Siparis", null)
                        .WithMany()
                        .HasForeignKey("SiparislerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MenuSiparis", b =>
                {
                    b.HasOne("HamburgerProje.Data.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenulerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerProje.Data.Siparis", null)
                        .WithMany()
                        .HasForeignKey("SiparislerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MenuSos", b =>
                {
                    b.HasOne("HamburgerProje.Data.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenulerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerProje.Data.Sos", null)
                        .WithMany()
                        .HasForeignKey("SoslarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SiparisSos", b =>
                {
                    b.HasOne("HamburgerProje.Data.Siparis", null)
                        .WithMany()
                        .HasForeignKey("SiparislerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerProje.Data.Sos", null)
                        .WithMany()
                        .HasForeignKey("SoslarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}