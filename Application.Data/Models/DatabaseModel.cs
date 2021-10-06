using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Data.Models;
using EFLogging;
using Microsoft.Extensions.Logging;
using SQLitePCL;

/**
 * 
 * name         :   DatabaseModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */


namespace Application.Data.Models
{
    /// <summary>
    /// The database model represents the database context and all the options associated with it
    /// </summary>
    public class DatabaseModel : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Junior> Junior { get; set; }
        public DbSet<Senior> Senior { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<HealthIssue> HealthIssues { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Kin> Kin { get; set; }

        public DatabaseModel() : base()
        {
        }

        public DatabaseModel(DbContextOptions<DatabaseModel> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                var lf = new LoggerFactory();
                lf.AddProvider(new MyLoggerProvider());
                optionsBuilder.UseLoggerFactory(lf);
                */

                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlite(
                    @"Data Source=D:\github\Application.Data\Data\Database.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Member
            modelBuilder.Entity<Member>()
                .HasKey(k => k.SRU);
            modelBuilder.Entity<Member>()
                .Property(m => m.SRU)
                .ValueGeneratedNever();

            modelBuilder.Entity<Member>()
                .Property(m => m.Type)
                .HasConversion<string>();


            modelBuilder.Entity<Member>()
                .HasOne(m => m.Address)
                .WithOne()
                .HasForeignKey<Member>(m => m.AddressId);

            //Player
            modelBuilder.Entity<Player>()
                .HasKey(k => k.SRU);


            modelBuilder.Entity<Player>()
                .HasOne(s => s.Member)
                .WithOne(m => m.Player)
                .HasForeignKey<Player>(m => m.SRU)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .Property(m => m.Position)
                .HasConversion<int>();

            modelBuilder.Entity<Player>()
                .HasOne(m => m.Doctor)
                .WithOne(m => m.Player)
                .HasForeignKey<Doctor>(m => m.PlayerSRU)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HealthIssue>()
                .HasOne(m => m.Player)
                .WithMany(m => m.HealthIssues)
                .HasForeignKey(m => m.PlayerSRU)
                .OnDelete(DeleteBehavior.Cascade);

            //Senior
            modelBuilder.Entity<Senior>()
                .HasKey(k => k.SRU);

            modelBuilder.Entity<Senior>()
                .HasOne(s => s.Player)
                .WithOne(m => m.Senior)
                .HasForeignKey<Senior>(m => m.SRU)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Senior>()
                .HasOne(s => s.Kin)
                .WithOne(m => m.Senior)
                .HasForeignKey<Kin>(m => m.SeniorSRU)
                .OnDelete(DeleteBehavior.Cascade);

            //Junior
            modelBuilder.Entity<Junior>()
                .HasKey(k => k.SRU);

            modelBuilder.Entity<Junior>()
                .HasOne(s => s.Player)
                .WithOne(m => m.Junior)
                .HasForeignKey<Junior>(m => m.SRU)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Junior>()
                .HasMany(m => m.Guardians)
                .WithOne(m => m.Junior)
                .HasForeignKey(m => m.JuniorId)
                .OnDelete(DeleteBehavior.Cascade);

            //Doctor
            modelBuilder.Entity<Doctor>()
                .HasOne(m => m.Address)
                .WithOne()
                .HasForeignKey<Doctor>(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            //Kin
            modelBuilder.Entity<Kin>()
                .HasOne(m => m.Address)
                .WithOne()
                .HasForeignKey<Kin>(m => m.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            //Guardian
            modelBuilder.Entity<Guardian>()
                .HasOne<Address>(m => m.Address)
                .WithOne()
                .HasForeignKey<Guardian>(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
            //Training
            modelBuilder.Entity<Training>()
                .HasMany(m => m.Activities)
                .WithOne(m => m.Training)
                .HasForeignKey(x => x.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Training>()
                .HasOne(m => m.Coach)
                .WithMany()
                .HasForeignKey(m => m.CoachSRU)
                .OnDelete(DeleteBehavior.Restrict);

            //Attendance
            modelBuilder.Entity<Attendance>()
                .HasKey(c => new {c.PlayerSRU, c.TrainingId});
            modelBuilder.Entity<Attendance>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<Attendance>()
                .HasOne(m => m.Player)
                .WithMany()
                .HasForeignKey(m => m.PlayerSRU)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Attendance>()
                .HasOne(m => m.Training)
                .WithMany()
                .HasForeignKey(m => m.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            //Profile
            modelBuilder.Entity<Profile>()
                .HasKey(c => new {c.PlayerSRU, c.SkillId});

            modelBuilder.Entity<Profile>()
                .HasIndex(x => x.SkillId).IsUnique(false);
            modelBuilder.Entity<Profile>()
                .HasIndex(x => x.PlayerSRU).IsUnique(false);

            modelBuilder.Entity<Profile>()
                .HasOne(m => m.Player)
                .WithOne()
                .HasForeignKey<Profile>(m => m.PlayerSRU)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profile>()
                .HasOne(m => m.Skill)
                .WithOne()
                .HasForeignKey<Profile>(m => m.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            //Skill
            modelBuilder.Entity<Skill>()
                .Property(m => m.Type)
                .HasConversion<int>();

            modelBuilder.Entity<Skill>()
                .HasOne(x => x.Parent)
                .WithMany()
                .HasForeignKey(x => x.ParentId)
                .IsRequired(false);

            //Game
            modelBuilder.Entity<Game>()
                .HasMany(m => m.Scores)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Game>()
                .Property(m => m.Location)
                .HasConversion<int>();

            modelBuilder.Entity<Game>()
                .Property(m => m.Result)
                .HasConversion<int>();

            //Scores
            modelBuilder.Entity<Scores>()
                .Property(m => m.Half)
                .HasConversion<int>();

            modelBuilder.Entity<Scores>()
                .Property(m => m.Team)
                .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }
    }
}