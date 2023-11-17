using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
{
    public void Configure(EntityTypeBuilder<Transmission> builder)
    {
        builder.ToTable("Transmissions").HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: t => t.Name, name: "UK_Transmissions_Name").IsUnique();

        builder.HasMany(t => t.Models);

        builder.HasQueryFilter(f => !f.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private Transmission[] getSeeds()
    {
        List<Transmission> transmissions = new();
        transmissions.Add(new Transmission
        {
            Id = Guid.NewGuid(),
            Name = "Otomatik",
            CreatedDate = DateTime.UtcNow
        });
        transmissions.Add(new Transmission
        {
            Id = Guid.NewGuid(),
            Name = "Manuel",
            CreatedDate = DateTime.UtcNow
        });

        return transmissions.ToArray();
    }
}
