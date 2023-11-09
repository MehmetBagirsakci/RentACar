using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(b=>b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired(); //Id nin gelebilmesi için Core.Packages.Persistence'ın referansının buraya dahil edilmesi gerekir.
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);//DeletedDate tarihinde veri yoksa (global filtre). Soft delete olanları getirme
    }
}
//ToTable: nuget EntityFrameworkCore.SqlServer yada EntityFrameworkCore.InMemory den gelir