using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(reg => reg.Id);

            // Modelo abaixo para tratar um tipo de relacionamento 1:N
            modelBuilder.Entity<Project>()
                .HasOne(reg => reg.Freelancer)
                .WithMany(reg => reg.FreelanceProjects)
                .HasForeignKey(reg => reg.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(reg => reg.Client)
                .WithMany(reg => reg.OwnedProjects)
                .HasForeignKey(reg => reg.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
                .HasKey(reg => reg.Id);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(reg => reg.Project)
                .WithMany(reg => reg.Comments)
                .HasForeignKey(reg => reg.IdProject);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(reg => reg.User)
                .WithMany(reg => reg.Comments)
                .HasForeignKey(reg => reg.IdUser);

            modelBuilder.Entity<Skill>()
                .HasKey(reg => reg.Id);

            modelBuilder.Entity<User>()
                .HasKey(reg => reg.Id);

            // Modelo abaixo para tratar um tipo de relacionamento N:1
            modelBuilder.Entity<User>()
                .HasMany(reg => reg.Skills)
                .WithOne()
                .HasForeignKey(reg => reg.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSkill>()
                .HasKey(reg => reg.Id);
        }
    }
}