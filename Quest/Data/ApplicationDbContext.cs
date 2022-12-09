using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<QuestRoom> Quests { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<QuestRoom>().HasData(
        //            new QuestRoom { Id = 1, Name = "Insania 2.0", SubjectId = 1, Time = 60 },
        //            new QuestRoom { Id = 2, Name = "Ограбление по-мексикански", SubjectId = 2, Time = 75 },
        //            new QuestRoom { Id = 3, Name = "Подпольное казино", SubjectId = 3, Time = 90 },
        //            new QuestRoom { Id = 4, Name = "Чистый разум", SubjectId = 1, Time = 100 },
        //            new QuestRoom { Id = 5, Name = "Терминал", SubjectId = 4, Time = 65 });
        //    modelBuilder.Entity<Subject>().HasData(
        //        new Subject { Id = 1, Name = "Questmakers" },
        //        new Subject { Id = 2, Name = "Серьезные игры" },
        //        new Subject { Id = 3, Name = "Клаустрофобия" },
        //        new Subject { Id = 4, Name = "CityQuest" });

        //}
    }
}
