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
        public DbSet<TaskQualificationLink> TaskQualificationLinks { get; set; } = null!;
        public DbSet<UserChiefLink> UserChiefLinks { get; set; } = null!;
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // DB filling on creating
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Models.Task>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Qualification>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Language>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserQualificationLink>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserLanguageLink>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TaskQualificationLink>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserChiefLink>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    name = "Иванов Иван Иванович",
                    eMail = "ivanovii@mail.ru",
                    password = "ivanovPassword",
                },
                new User
                {
                    Id = 2,
                    name = "Петров Петр Петрович",
                    eMail = "petrovpp@mail.ru",
                    password = "petrovPassword",
                },
                new User
                {
                    Id = 3,
                    name = "Максимов Максим Максимович",
                    eMail = "maksimovmm@mail.ru",
                    password = "maksimovPassword",
                }
            );
            modelBuilder.Entity<Models.Task>().HasData(
                new Models.Task
                {
                    Id = 1,
                    name = "Тестовое задание",
                    languageRequiredId = 4,
                    deadline = new DateTime(2025, 1, 1, 8, 0, 0),
                    performerId=2
                }
            );
            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 1,
                    name = "Компьютерные методы",
                    description= "Способен применять компьютерные/суперкомпьютерные методы"
                },
                new Qualification
                {
                    Id = 2,
                    name = "Алгоритмические решения",
                    description = "Способен к разработке алгоритмических и программных решений в области системного и прикладного программирования"
                },
                new Qualification
                {
                    Id = 3,
                    name = "Поиск, анализ, синтез информации",
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
                    userId = 1,
                    qualificationId = 1,
                },
                new UserQualificationLink
                {
                    Id = 2,
                    userId = 1,
                    qualificationId = 2,
                },
                new UserQualificationLink
                {
                    Id = 3,
                    userId = 1,
                    qualificationId = 3,
                },
                new UserQualificationLink
                {
                    Id = 4,
                    userId = 2,
                    qualificationId = 1,
                },
                new UserQualificationLink
                {
                    Id = 5,
                    userId = 2,
                    qualificationId = 2,
                },
                new UserQualificationLink
                {
                    Id = 6,
                    userId = 3,
                    qualificationId = 1,
                },
                new UserQualificationLink
                {
                    Id = 7,
                    userId = 3,
                    qualificationId = 3,
                }
                );
            modelBuilder.Entity<UserLanguageLink>().HasData(
                new UserLanguageLink
                {
                    Id = 1,
                    userId=1,
                    languageId=1,
                },
                new UserLanguageLink
                {
                    Id = 2,
                    userId = 1,
                    languageId = 2,
                },
                new UserLanguageLink
                {
                    Id = 3,
                    userId = 2,
                    languageId = 1,
                },
                new UserLanguageLink
                {
                    Id = 4,
                    userId = 2,
                    languageId = 3,
                },
                new UserLanguageLink
                {
                    Id = 5,
                    userId = 3,
                    languageId = 4,
                },
                new UserLanguageLink
                {
                    Id = 6,
                    userId = 3,
                    languageId = 5,
                }
                );
            modelBuilder.Entity<TaskQualificationLink>().HasData(
                new TaskQualificationLink
                {
                    Id = 1,
                    taskId = 1,
                    qualificationId = 1
                }
                );
            modelBuilder.Entity<UserChiefLink>().HasData(
                new UserChiefLink
                {
                    Id = 1,
                    userId = 1,
                    chiefId = 1
                },
                new UserChiefLink
                {
                    Id = 2,
                    userId = 2,
                    chiefId = 1
                },
                new UserChiefLink
                {
                    Id = 3,
                    userId = 3,
                    chiefId = 1
                }
                );
        }
    }
}
