using TempleCMS.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Data.EntityConfigurations
{
    public class ClubMemberConfiguration : IEntityTypeConfiguration<ClubMember>
    {
        public void Configure(EntityTypeBuilder<ClubMember> builder)
        {
            builder.HasKey(x => new { x.ClubId, x.MemberId });

            builder.HasOne(x => x.Club)
                .WithMany(a => a.Members)
                .HasForeignKey(x => x.ClubId)
                .IsRequired();

            builder.HasOne(x => x.Member)
                .WithMany(a => a.Clubs)
                .HasForeignKey(x => x.MemberId)
                .IsRequired();
        }
    }
}