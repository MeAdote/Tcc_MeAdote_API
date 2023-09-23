using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tcc_MeAdote_API.Entities.User
{
    public class UserAdress
    {
        public int Id { get; set; }
        public string StreetName { get; set; }             
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }


    public class UserAdressConfiguration : IEntityTypeConfiguration<UserAdress>
    {
        public void Configure(EntityTypeBuilder<UserAdress> builder)
        {
            builder.ToTable("user_adress");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StreetName)
                .HasColumnName("street_name")
                .IsRequired();

            builder.Property(x => x.City)
                .HasColumnName("city")
                .IsRequired();

            builder.Property(x => x.State)
            .HasColumnName("state")
            .IsRequired();
            
            builder.Property(x => x.PostalCode)
                .HasColumnName("postal_code")
                .IsRequired();

            builder
                .Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired();
                
        }
    }
}
