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
        public DateTime BirthDate { get; set; }
        public string Telephone { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired();
            builder
                .Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired();

            builder.Property(x => x.BirthDate)
                .HasColumnName("birth_date")
                .IsRequired();

            builder
                .Property(x => x.Telephone)
                .HasColumnName("telephone")
                .IsRequired();
            builder
                .Property(x => x.ProfilePicture)
                .HasColumnName("profile_picture");
            builder
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at");
        }
    }
}
