using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tcc_MeAdote_API.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }
        public string ProfilePicture { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired();
            builder
                .Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired();

            builder.Property(x => x.Age)
                .HasColumnName("age")
                .IsRequired();

            builder
                .Property(x => x.Telephone)
                .HasColumnName("telephone")
                .IsRequired();
            builder
                .Property(x => x.ProfilePicture)
                .HasColumnName("profile_picture");
        }
    }
}
