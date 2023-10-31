using TempleCMS.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Data.EntityConfigurations
{
    public class EventUserConfiguration : IEntityTypeConfiguration<EventUser>
    {
        public void Configure(EntityTypeBuilder<EventUser> builder)
        {
            builder.HasKey(x => new { x.EventId, x.UserId });

            builder.HasOne(x => x.Event)
                .WithMany(a => a.Users)
                .HasForeignKey(x => x.EventId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(a => a.Events)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}