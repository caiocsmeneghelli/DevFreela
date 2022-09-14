using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfigurations : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            // modelBuilder.Entity<ProjectComment>()
            //     .HasKey(reg => reg.Id);
            // Ao inves de utilizar o modelBuilder.Entity<T> como dentro de dbContext
            // usar apenas o builder
            builder
                .HasKey(reg => reg.Id);

            builder
                .HasOne(reg => reg.Project)
                .WithMany(reg => reg.Comments)
                .HasForeignKey(reg => reg.IdProject);

            builder
                .HasOne(reg => reg.User)
                .WithMany(reg => reg.Comments)
                .HasForeignKey(reg => reg.IdUser);

        }
    }
}