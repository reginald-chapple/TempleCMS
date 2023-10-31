using TempleCMS.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Data.EntityConfigurations
{
    public class UserPositionConfiguration : IEntityTypeConfiguration<UserPosition>
    {
        public void Configure(EntityTypeBuilder<UserPosition> builder)
        {
            builder.HasKey(x => new { x.PositionId, x.UserId });

            builder.HasOne(x => x.Position)
                .WithMany(a => a.Users)
                .HasForeignKey(x => x.PositionId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(a => a.Positions)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}