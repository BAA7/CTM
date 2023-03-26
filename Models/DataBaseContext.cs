using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CTM.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<Qualification> Qualifications { get; set; } = null!;

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // DB filling on creating
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 0,
                    name = "Иванов Иван Иванович",
                    eMail = "ivanovii@mail.ru",
                    password = "ivanovPassword",
                    qualificationCodes = new int[] { 0, 1 },
                    languagesKnown = new string[] { "C", "C++" } 
                },
                new User
                {
                    Id = 1,
                    name = "Петров Петр Петрович",
                    eMail = "petrovpp@mail.ru",
                    password = "petrovPassword",
                    qualificationCodes = new int[] { 0, 1 },
                    languagesKnown = new string[] { "C", "C#" }
                },
                new User
                {
                    Id = 2,
                    name = "Максимов Максим Максимович",
                    eMail = "maksimovmm@mail.ru",
                    password = "maksimovPassword",
                    qualificationCodes = new int[] { 0, 1 },
                    languagesKnown = new string[] { "Java", "Python" }
                }
            );
        }
    }
}
