namespace WolfpackBackendAssessment.Infrastructure.Persistance.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Domain.Models.Packs;

    using static Domain.Models.ModelConstants;

    public class PackConfiguration : IEntityTypeConfiguration<Pack>
	{
		public void Configure(EntityTypeBuilder<Pack> builder)
		{
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .HasMany(x => x.Wolves)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("_wolves");
        }
	}
}
