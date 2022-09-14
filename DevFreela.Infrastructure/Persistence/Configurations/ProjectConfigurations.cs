using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(reg => reg.Id);

            // Modelo abaixo para tratar um tipo de relacionamento 1:N
            builder
                .HasOne(reg => reg.Freelancer)
                .WithMany(reg => reg.FreelanceProjects)
                .HasForeignKey(reg => reg.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(reg => reg.Client)
                .WithMany(reg => reg.OwnedProjects)
                .HasForeignKey(reg => reg.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}