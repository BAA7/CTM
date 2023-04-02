using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CTM.Models;

namespace CTM.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Models.Task> Tasks { get; set; } = null!;
        public DbSet<Qualification> Qualifications { get; set; } = null!;
        public DbSet<Language> Languages { get; set; } = null!;
        public DbSet<UserQualificationLink> UserQualificationLinks { get; set; } = null!;
        public DbSet<UserLanguageLink> UserLanguageLinks { get; set; } = null!;

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // DB filling on creating
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    name = "Иванов Иван Иванович",
                    eMail = "ivanovii@mail.ru",
                    password = "ivanovPassword",
                    //qualificationCodes = new List<int> { 0, 1, 2 },
                    //languagesKnown = new List<string> { "C", "C++" } 
                },
                new User
                {
                    Id = 2,
                    name = "Петров Петр Петрович",
                    eMail = "petrovpp@mail.ru",
                    password = "petrovPassword",
                    //qualificationCodes = new List<int> { 0, 1 },
                    //languagesKnown = new List<string> { "C", "C#" }
                },
                new User
                {
                    Id = 3,
                    name = "Максимов Максим Максимович",
                    eMail = "maksimovmm@mail.ru",
                    password = "maksimovPassword",
                    //qualificationCodes = new List<int> { 0, 2 },
                    //languagesKnown = new List<string> { "Java", "Python" }
                }
            );
            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 1,
                    name = "ОПК-2",
                    description= "Способен применять компьютерные/суперкомпьютерные методы"
                },
                new Qualification
                {
                    Id = 2,
                    name = "ОПК-3",
                    description = "Способен к разработке алгоритмических и программных решений в области системного и прикладного программирования"
                },
                new Qualification
                {
                    Id = 3,
                    name = "УК-1",
                    description = "Способен осуществлять поиск, критический анализ и синтез информации"
                }
            );
            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = 1,
                    name="C"
                },
                new Language
                {
                    Id = 2,
                    name = "C++"
                },
                new Language
                {
                    Id = 3,
                    name = "C#"
                },
                new Language
                {
                    Id = 4,
                    name = "Java"
                },
                new Language
                {
                    Id = 5,
                    name = "Python"
                }
                );
            modelBuilder.Entity<UserQualificationLink>().HasData(
                new UserQualificationLink
                {
                    Id = 1,
                    userId=1,
                    qualificationId=1
                },
                new UserQualificationLink
                {
                    Id = 2,
                    userId = 1,
                    qualificationId = 2
                },
                new UserQualificationLink
                {
                    Id = 3,
                    userId = 1,
                    qualificationId = 3
                },
                new UserQualificationLink
                {
                    Id = 4,
                    userId = 2,
                    qualificationId = 1
                },
                new UserQualificationLink
                {
                    Id = 5,
                    userId = 2,
                    qualificationId = 2
                },
                new UserQualificationLink
                {
                    Id = 6,
                    userId = 3,
                    qualificationId = 1
                },
                new UserQualificationLink
                {
                    Id = 7,
                    userId = 3,
                    qualificationId = 3
                }
                );
            modelBuilder.Entity<UserLanguageLink>().HasData(
                new UserLanguageLink
                {
                    Id=1,
                    userId=1,
                    languageId=1
                },
                new UserLanguageLink
                {
                    Id = 2,
                    userId = 1,
                    languageId = 2
                },
                new UserLanguageLink
                {
                    Id = 3,
                    userId = 2,
                    languageId = 1
                },
                new UserLanguageLink
                {
                    Id = 4,
                    userId = 2,
                    languageId = 3
                },
                new UserLanguageLink
                {
                    Id = 5,
                    userId = 3,
                    languageId = 4
                },
                new UserLanguageLink
                {
                    Id = 6,
                    userId = 3,
                    languageId = 5
                }
                );
        }
    }
}
