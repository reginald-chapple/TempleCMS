using TempleCMS.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Data.EntityConfigurations
{
    public class GroupValueConfiguration : IEntityTypeConfiguration<GroupValue>
    {
        public void Configure(EntityTypeBuilder<GroupValue> builder)
        {
            builder.HasKey(x => new { x.GroupId, x.ValueId });

            builder.HasOne(x => x.Group)
                .WithMany(a => a.Values)
                .HasForeignKey(x => x.GroupId)
                .IsRequired();

            builder.HasOne(x => x.Value)
                .WithMany(a => a.Groups)
                .HasForeignKey(x => x.ValueId)
                .IsRequired();
        }
    }
}