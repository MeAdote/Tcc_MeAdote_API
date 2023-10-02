using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tcc_MeAdote_API.Entities.Pets
{
    public class PetType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PetTypeConfiguration : IEntityTypeConfiguration<PetType>
    {
        public void Configure(EntityTypeBuilder<PetType> builder)
        {
            builder.ToTable("pet_type");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();
        }
    }
}
