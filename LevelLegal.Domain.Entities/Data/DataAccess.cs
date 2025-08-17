using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using LevelLegal.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LevelLegal.Domain.Entities.Data
{
    public class DataAccess : DbContext
    {

        public DataAccess(DbContextOptions<DataAccess> options)
            : base (options) { }

        public DbSet<Matter> Matters { get; set; } = default!;
        public DbSet<Evidence> Evidences { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            try
            {
                base.OnModelCreating(builder);

                builder.Entity<Matter>()
                    .HasKey(e => e.Id);

                builder.Entity<Matter>()
                    .Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                builder.Entity<Evidence>()
                    .HasKey(e => e.Id);

                builder.Entity<Evidence>()
                    .HasOne(b => b.Matter)
                    .WithMany(a => a.Evidences)
                    .HasForeignKey(b => b.MatterId);

                // Seed
                var initMatters = new List<Matter> {
                    new Matter { Id = 100, Name = "Up vs Down" },
                    new Matter { Id = 101, Name = "In vs Out" },
                    new Matter { Id = 102, Name = "EF Core vs Dapper" },
                    new Matter { Id = 103, Name = "Dark Mode vs Light Mode" }
                };

                var initEvidences = new List<Evidence> {
                    new Evidence
                    {
                        Id = 1,
                        MatterId = 100,
                        Description = "Dell XPS Laptop",
                        SerialNumber = "DG56GSR"
                    },
                    new Evidence
                    {
                        Id = 2,
                        MatterId = 100,
                        Description = "San Disk Flash Drive",
                        SerialNumber = "43255323GS445344"
                    },
                    new Evidence
                    {
                        Id = 3,
                        MatterId = 100,
                        Description = "ASUS Zenbook 14 Laptop",
                        SerialNumber = "GBSFFDW8434-3323"
                    },
                    new Evidence
                    {
                        Id = 4,
                        MatterId = 101,
                        Description = "Kingston 256GB Flash Drive",
                        SerialNumber = "KD43243KT67655"
                    },
                    new Evidence
                    {
                        Id = 5,
                        MatterId = 102,
                        Description = "iPhone 15",
                        SerialNumber = "GT453223FSTR52"
                    },
                    new Evidence
                    {
                        Id = 6,
                        MatterId = 102,
                        Description = "Samsung NVMe M2 Internal Drive",
                        SerialNumber = "SE5324GYTF65556"
                    },
                    new Evidence
                    {
                        Id = 7,
                        MatterId = 102,
                        Description = "Samsung Fold Cell Phone",
                        SerialNumber = "FSYGD645DFSWWSFFDTSAA"
                    },
                    new Evidence
                    {
                        Id = 8,
                        MatterId = 103,
                        Description = "Lacie External 1TB Drive",
                        SerialNumber = "AD34222432-321321"
                    }
                };

                builder.Entity<Matter>().HasData(initMatters);
                builder.Entity<Evidence>().HasData(initEvidences);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
