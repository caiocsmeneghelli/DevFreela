using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            // Ao inves de utilizar o modelBuilder.Entity<T> como dentro de dbContext
            // usar apenas o builder
            builder
                .HasKey(reg => reg.Id);

            // Modelo abaixo para tratar um tipo de relacionamento N:1
            builder
                .HasMany(reg => reg.Skills)
                .WithOne()
                .HasForeignKey(reg => reg.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}