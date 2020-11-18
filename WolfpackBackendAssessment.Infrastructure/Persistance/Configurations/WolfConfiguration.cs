namespace WolfpackBackendAssessment.Infrastructure.Persistance.Configurations
{
    using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Domain.Models.Wolves;

    using static Domain.Models.ModelConstants;

    public class WolfConfiguration : IEntityTypeConfiguration<Wolf>
    {
        public void Configure(EntityTypeBuilder<Wolf> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .OwnsOne(x => x.Location, o =>
                {
                    o.WithOwner();

                    o.Property(op => op.Latitude);
                    o.Property(op => op.Longitude);
                });

            builder
                .OwnsOne(x => x.Gender, o =>
                {
                    o.WithOwner();

                    o.Property(tr => tr.Value);
                });
        }
    }
}
