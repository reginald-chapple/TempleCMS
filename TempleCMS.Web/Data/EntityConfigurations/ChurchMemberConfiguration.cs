using TempleCMS.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Data.EntityConfigurations
{
    public class ChurchMemberConfiguration : IEntityTypeConfiguration<ChurchMember>
    {
        public void Configure(EntityTypeBuilder<ChurchMember> builder)
        {

            builder.HasOne(x => x.Church)
                .WithMany(c => c.Members)
                .HasForeignKey(x => x.ChurchId)
                .IsRequired();
        }
    }
}