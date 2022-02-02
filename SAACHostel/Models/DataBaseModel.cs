using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SAACHostel.Models
{
    internal class DataBaseModel : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Hostel> Hostels { get; set; } = null!;
        public DbSet<LogEntry> LogEntrys { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Faculty> Facultys { get; set; } = null!;
        public DbSet<Specialty> Specialtys { get; set; } = null!;
        public DbSet<PaymentAndPeriod> PaymentAndPeriods { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<User>().HasOne(u => u.Hostel).WithOne(p => p.User).HasForeignKey<Hostel>(p => p.User_ID);
            modelBuilder.Entity<User>().HasOne(u => u.LogEntry).WithOne(p => p.User).HasForeignKey<LogEntry>(p => p.User_ID);
            modelBuilder.Entity<User>().HasOne(u => u.Room).WithOne(p => p.User).HasForeignKey<Room>(p => p.User_ID);
            modelBuilder.Entity<User>().HasOne(u => u.Student).WithOne(p => p.User).HasForeignKey<Student>(p => p.User_ID);
            modelBuilder.Entity<User>().HasOne(u => u.Faculty).WithOne(p => p.User).HasForeignKey<Faculty>(p => p.User_ID);
            modelBuilder.Entity<User>().HasOne(u => u.Specialty).WithOne(p => p.User).HasForeignKey<Specialty>(p => p.User_ID);
            modelBuilder.Entity<Hostel>().HasOne(u => u.LogEntry).WithOne(p => p.Hostel).HasForeignKey<LogEntry>(p => p.Hostel_ID);
            modelBuilder.Entity<Room>().HasOne(u => u.LogEntry).WithOne(p => p.Room).HasForeignKey<LogEntry>(p => p.Room_ID);
            modelBuilder.Entity<Student>().HasOne(u => u.LogEntry).WithOne(p => p.Student).HasForeignKey<LogEntry>(p => p.Student_ID);
            modelBuilder.Entity<Faculty>().HasOne(u => u.Student).WithOne(p => p.Faculty).HasForeignKey<Student>(p => p.Faculty_ID);
            modelBuilder.Entity<Specialty>().HasOne(u => u.Student).WithOne(p => p.Specialty).HasForeignKey<Student>(p => p.Specialty_ID);*/
        }
        internal class User
        {
            public int ID { get; set; }
            public bool Active { get; set; }
            public DateTime Date_Create { get; set; }
            public byte[]? Photo { get; set; }
            public string? Login { get; set; }
            public string? Password { get; set; }
            public string? First_Name { get; set; }
            public string? Last_Name { get; set; }
            public string? Middle_Name { get; set; }
            public int Pasport_ID { get; set; }
            public string? Phone { get; set; }
            public string? Home_address { get; set; }
            public List<Hostel?> Hostel { get; set; } = new List<Hostel?>();
            public List<LogEntry?> LogEntry { get; set; } = new List<LogEntry?>();
            public List<Room?> Room { get; set; } = new List<Room?>();
            public List<Student?> Student { get; set; } = new List<Student?>();
            public List<Faculty?> Faculty { get; set; } = new List<Faculty?>();
            public List<Specialty?> Specialty { get; set; } = new List<Specialty?>();
        }
        internal class Hostel
        {
            public int ID { get; set; }
            public DateTime Date_Create { get; set; }
            public int Count_Room { get; set; }
            public string? Phone { get; set; }
            public string? Home_address { get; set; }
            public int UserID { get; set; }
            public User? User { get; set; }
            public List<Room?> Room { get; set; } = new List<Room?>();
        }
        internal class LogEntry
        {
            public int ID { get; set; }
            public DateTime Date_Create { get; set; }
            public DateTime Date_Ent { get; set; }
            public DateTime Date_Ext { get; set; }
            public int Pay { get; set; }
            public int Total_Paid { get; set; }
            public bool State { get; set; }
            public int UserID { get; set; }
            public int RoomID { get; set; }
            public int StudentID { get; set; }
            public int HostelID { get; set; }
            public int PaymentAndPeriodID { get; set; }
            public User? User { get; set; }
        }
        internal class Room
        {
            public int ID { get; set; }
            public DateTime Date_Create { get; set; }
            public int Capacity { get; set; }
            public int UserID { get; set; }
            public int HostelID { get; set; }
            public User? User { get; set; }
            public Hostel? Hostel { get; set; }

        }
        internal class Student
        {
            public int ID { get; set; }
            public DateTime Date_Create { get; set; }
            public byte[]? Photo { get; set; }
            public string? First_Name { get; set; }
            public string? Last_Name { get; set; }
            public string? Middle_Name { get; set; }
            public string? Group { get; set; }
            public int Passport_ID { get; set; }
            public string? Phone { get; set; }
            public string? Home_address { get; set; }
            public int UserID { get; set; }
            public int FacultyID { get; set; }
            public int SpecialtyID { get; set; }
            public User? User { get; set; }
            public Faculty? Faculty { get; set; }
            public Specialty? Specialty { get; set; }

        }
        internal class Faculty
        {
            public int ID { get; set; }
            public DateTime Date_Create { get; set; }
            public string? Full_Name { get; set; }
            public string? Short_Name { get; set; }
            public string? Full_Name_Decan { get; set; }
            public string? Phone_Decane { get; set; }
            public int UserID { get; set; }
            public User? User { get; set; }
            public List<Student?> Student { get; set; } = new List<Student?>();

        }
        internal class Specialty
        {
            public int ID { get; set; }
            public DateTime Date_Create { get; set; }
            public string? Full_Name { get; set; }
            public string? Short_Name { get; set; }
            public int UserID { get; set; }
            public User? User { get; set; }
            public List<Student?> Student { get; set; } = new List<Student?>();
        } 
        internal class PaymentAndPeriod
        {
            public int ID { get; set; }
            public string? Period { get; set; }
            public bool SelectedPeriod { get; set; }
        }
        internal class Payment
        {
            public int ID { get; set; }
            public int Amount { get; set; }
        }
    }
}
