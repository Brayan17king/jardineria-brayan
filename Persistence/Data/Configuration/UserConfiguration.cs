using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(80);
            builder.Property(x => x.RefreshToken);
            builder.Property(x => x.TokenCreated).HasColumnType("date");
            builder.Property(x => x.TokenExpires).HasColumnType("date");
            builder.HasMany(e => e.Rols).WithMany(c => c.Users).UsingEntity<UserRol>(
                y => y.HasOne(e => e.Rols).WithMany(e => e.UserRols).HasForeignKey(c => c.IdRolFk),
                y => y.HasOne(e => e.Users).WithMany(e => e.UserRols).HasForeignKey(c => c.IdUserFk),
                y => {
                    y.ToTable("userrol");
                    y.HasKey(z => new { z.IdUserFk, z.IdRolFk });
                }
            );
        }
    }
}