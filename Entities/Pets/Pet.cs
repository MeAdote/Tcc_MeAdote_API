using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcc_MeAdote_API.Entities.Pets;

namespace Tcc_MeAdote_API.Entities.Pets
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Age { get; set; }
        public string PetPicture { get; set; }
        public PetType PetType { get; set; }
        public int PetTypeId { get; set; }
        public User.User User  { get; set; }
        public int UserId { get; set; }
    }

    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pet");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(x => x.Age)
                .HasColumnName("age");

            builder.Property(x => x.Race)
                .HasColumnName("race")
                .IsRequired();

            builder.Property(x => x.Location)
                .HasColumnName("location")
                .IsRequired();
            

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property<int>(x => x.PetTypeId)
                .HasColumnName("pet_type_id")
                .IsRequired();

            builder.HasOne(x => x.PetType)
                .WithMany()
                .HasForeignKey(x => x.PetTypeId)
                .IsRequired();

            builder
                .Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.PetPicture)
                .HasColumnName("picture_pet")
                .IsRequired();

        }
    }
}