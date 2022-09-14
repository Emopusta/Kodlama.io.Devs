using Core.Security.Entities;
using KodlamaioDevs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// add-migration name
// update-database
namespace KodlamaioDevs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Description).HasColumnName("Description");
                a.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Description).HasColumnName("Description");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                a.Property(p => p.UserId).HasColumnName("UserId");
                
            });


            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1
                ,"Python", "Pythooon"), new(2, "C#", "Test 2 Description") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            Technology[] technologyEntitySeeds = { new(1, "Django", 1, "Web framework"), new(2, ".Net", 2, ".NEEEEEET") };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);

            User[] userEntitySeeds = { new(1, "Emre", "Duman", "Emopusta@hotmail.com", Encoding.ASCII.GetBytes("asdasd"), Encoding.ASCII.GetBytes("asdasd"), false, 0) };
            modelBuilder.Entity<User>().HasData(userEntitySeeds);

            OperationClaim[] operationClaimEntitySeeds = { new(1, "user"), new(2, "admin") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimEntitySeeds);

            UserOperationClaim[] userOperationClaimEntitySeeds = { new(1, 1, 2) };
            modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaimEntitySeeds);
        }
    }
}
