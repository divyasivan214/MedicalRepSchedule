using MedicalRepSchedule.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepSchedule
{
    public class RepresentativeScheduleContext : DbContext
    {
        public RepresentativeScheduleContext()
        {
        }
        public RepresentativeScheduleContext(DbContextOptions<RepresentativeScheduleContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:scheduleserver.database.windows.net,1433;Initial Catalog=ScheduleDB;Persist Security Info=False;User ID=divya214;Password=Divya@214;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicinestockTable>().HasData(
            new MedicinestockTable
            {
                Name = "Dolo 650",
                ChemicalComposition = "Paracetamol,Acetaminophen",
                TargetAilment = "General",
                DateOfExpiry = DateTime.Parse("08-12-2022"),
                NumberOfTabletsInStock = 300
            },
            new MedicinestockTable
            {
                Name = "Orthoherb",
                ChemicalComposition = "Castor Plant,Adulsa,Neem,Guggul",
                TargetAilment = "Orthopaedics",
                DateOfExpiry = DateTime.Parse("05-11-2021"),
                NumberOfTabletsInStock = 190
            },
            new MedicinestockTable
            {
                Name = "Cholecalciferol",
                ChemicalComposition = "Ergocalciferol,Cholecalciferol,22-DiHydroergoCalciferol",
                TargetAilment = "Orthopaedics",
                DateOfExpiry = DateTime.Parse("10-11-2023"),
                NumberOfTabletsInStock = 200
            },
            new MedicinestockTable
            {
                Name = "Gaviscon",
                ChemicalComposition = "Magnesium,Oxide,Silicon,Sodium",
                TargetAilment = "General",
                DateOfExpiry = DateTime.Parse("02-08-2022"),
                NumberOfTabletsInStock = 150
            },
            new MedicinestockTable
            {
                Name = "Hilact",
                ChemicalComposition = "Pancreatin,Dimethicone,Polydimethylsiloxane",
                TargetAilment = "Gynaecology",
                DateOfExpiry = DateTime.Parse("11-06-2024"),
                NumberOfTabletsInStock = 400
            },
             new MedicinestockTable
             {
                 Name = "Cyclopam",
                 ChemicalComposition = "Dicyclomine,Hydrochloride,Paracetamol",
                 TargetAilment = "Gynaecology",
                 DateOfExpiry = DateTime.Parse("02-11-2025"),
                 NumberOfTabletsInStock = 500
             }
            );
            modelBuilder.Entity<DoctorData>().HasData(
            new DoctorData { DoctorId = 100, DoctorName = "D1", TreatingAilment = "Orthopaedics", DoctorContactNumber = "9884122113" },
            new DoctorData { DoctorId = 101, DoctorName = "D2", TreatingAilment = "General", DoctorContactNumber = "9876543210" },
            new DoctorData { DoctorId = 102, DoctorName = "D3", TreatingAilment = "General", DoctorContactNumber = "9876543211" },
            new DoctorData { DoctorId = 103, DoctorName = "D4", TreatingAilment = "Orthopaedics", DoctorContactNumber = "9876543212" },
            new DoctorData { DoctorId = 104, DoctorName = "D5", TreatingAilment = "Gynaecology", DoctorContactNumber = "9876543213" }
            );
        }
        public virtual DbSet<RepresentativeSchedule> RepresentativeSchedules { get; set; }
        public virtual DbSet<DoctorData> DoctorDatas { get; set; }
        public virtual DbSet<MedicinestockTable> MedicinestockTables { get; internal set; }
    }
}
