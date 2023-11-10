using TempleCMS.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Data.EntityConfigurations
{
    public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.HasKey(x => new { x.GroupId, x.MemberId });

            builder.HasOne(x => x.Group)
                .WithMany(a => a.Members)
                .HasForeignKey(x => x.GroupId)
                .IsRequired();

            builder.HasOne(x => x.Member)
                .WithMany(a => a.Groups)
                .HasForeignKey(x => x.MemberId)
                .IsRequired();
        }
    }
}