using TempleCMS.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Data.EntityConfigurations
{
    public class ClubActivityConfiguration : IEntityTypeConfiguration<ClubActivity>
    {
        public void Configure(EntityTypeBuilder<ClubActivity> builder)
        {
            builder.HasKey(x => new { x.ClubId, x.ActivityId });

            builder.HasOne(x => x.Club)
                .WithMany(a => a.Activities)
                .HasForeignKey(x => x.ClubId)
                .IsRequired();

            builder.HasOne(x => x.Activity)
                .WithMany(a => a.Clubs)
                .HasForeignKey(x => x.ActivityId)
                .IsRequired();
        }
    }
}