using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models;


public partial class MyDb : DbContext
{
    internal object sick_patients;

    public MyDb()
    {
    }

    public MyDb(DbContextOptions<MyDb> options)
        : base(options)
    {
    }

    public virtual DbSet<CoronaDetail> CoronaDetails { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<SickPatient> SickPatients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // => optionsBuilder.UseSqlServer(DBActions.GetConnectionString("ConsoleApp1"));
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\יהודית חובלני\\ConsoleApp1\\HMO.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoronaDetail>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Corona_D__AA2FFB85585594A8");

            entity.ToTable("Corona_Details");

            entity.Property(e => e.PersonId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("PersonID");
            entity.Property(e => e.GettingVaccinated1)
                .HasColumnType("datetime")
                .HasColumnName("Getting_vaccinated_1");
            entity.Property(e => e.GettingVaccinated2)
                .HasColumnType("datetime")
                .HasColumnName("Getting_vaccinated_2");
            entity.Property(e => e.GettingVaccinated3)
                .HasColumnType("datetime")
                .HasColumnName("Getting_vaccinated_3");
            entity.Property(e => e.GettingVaccinated4)
                .HasColumnType("datetime")
                .HasColumnName("Getting_vaccinated_4");
            entity.Property(e => e.VaccineManufacturer1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Vaccine_manufacturer_1");
            entity.Property(e => e.VaccineManufacturer2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Vaccine_manufacturer_2");
            entity.Property(e => e.VaccineManufacturer3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Vaccine_manufacturer_3");
            entity.Property(e => e.VaccineManufacturer4)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Vaccine_manufacturer_4");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Patients__AA2FFB858815A068");

            entity.Property(e => e.PersonId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("PersonID");
            entity.Property(e => e.CellPhone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Cell_phone");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("Date_of_birth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Home_phone");
            entity.Property(e => e.HouseNumber).HasColumnName("House_number");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("street");
        });

        modelBuilder.Entity<SickPatient>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__sick_pat__AA2FFB85D4E1F331");

            entity.ToTable("sick_patients");

            entity.Property(e => e.PersonId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("PersonID");
            entity.Property(e => e.PositiveResult)
                .HasColumnType("datetime")
                .HasColumnName("Positive_result");
            entity.Property(e => e.Recuperation)
                .HasColumnType("datetime")
                .HasColumnName("recuperation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
