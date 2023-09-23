using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Tcc_MeAdote_API.Entities.User
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
    }


    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("user_login");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();
            builder
                .Property(x => x.Password)
                .HasColumnName("password")
                .IsRequired();

            builder.Property(x => x.Salt)
                .HasColumnName("salt")
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
