using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using option_one.Models;

namespace option_one.Data
{
    public partial class PromoCodesDBContext : DbContext
    {
        public PromoCodesDBContext()
        {
        }

        public PromoCodesDBContext(DbContextOptions<PromoCodesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            *//*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=SQLConnection");
            }*//*
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.ServiceDesc)
                    .HasColumnName("service_desc")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ServicePromocode)
                    .HasColumnName("service_promocode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceStatus)
                    .HasColumnName("service_status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceTitle)
                    .HasColumnName("service_title")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.userId);

                entity.Property(e => e.userId).HasColumnName("user_id");

                entity.Property(e => e.username)
                    .HasColumnName("user_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired(true);

                entity.Property(e => e.password)
                    .HasColumnName("password")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .IsRequired(true);
            });

            SeedUsers(modelBuilder);
            SeedServices(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private static void SeedUsers(ModelBuilder builder)
        {

            builder.Entity<User>().HasData(
                new User
                {
                    userId = 1,
                    username = "User1",
                    password = "Password1"
                }
            );

            builder.Entity<User>().HasData(
                new User
                {
                    userId = 2,
                    username = "User2",
                    password = "Password2"
                }
            );

            builder.Entity<User>().HasData(
                new User
                {
                    userId = 3,
                    username = "User3",
                    password = "Password3"
                }
            );
        }

        private static void SeedServices(ModelBuilder builder)
        {

            builder.Entity<Services>().HasData(
                new Services
                {
                    ServiceId = 1,
                    ServiceTitle = "Siteconstructor",
                    ServiceDesc = "Siteconstructor decription",
                    ServicePromocode = "SiteconstructorPromocode",
                    ServiceStatus = "Inactive"
                }
            );

            builder.Entity<Services>().HasData(
                new Services
                {
                    ServiceId = 2,
                    ServiceTitle = "Appvision.com",
                    ServiceDesc = "Appvision description",
                    ServicePromocode = "Appvisionpromocode",
                    ServiceStatus = "Inactive"
                }
            );

            builder.Entity<Services>().HasData(
                new Services
                {
                    ServiceId = 3,
                    ServiceTitle = "Analytics.com",
                    ServiceDesc = "Analytics decription",
                    ServicePromocode = "Analyticspromocode",
                    ServiceStatus = "Inactive"
                }
            );

            builder.Entity<Services>().HasData(
                new Services
                {
                    ServiceId = 4,
                    ServiceTitle = "Logotype",
                    ServiceDesc = "Logotype decription",
                    ServicePromocode = "Logotypepromocode",
                    ServiceStatus = "Inactive"
                }
            );
        }
    }
}
