using System.ComponentModel.DataAnnotations;
using Tcc_MeAdote_API.Entities;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Data.Dto
{
    public class CreateUserDto
    {
        public UserDto User { get; set; }
        public UserAdressDto UserAdress { get; set; }
        public UserLoginDto UserLogin { get; set; }
    }


    public class UserDto
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Telephone is required")]
        [Phone(ErrorMessage = "Invalid Telephone Number")]
        public string Telephone { get; set; }
        public string ProfilePicture { get; set; }
    }

    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(7, ErrorMessage = "Password must have at least 8 characters")]
        public string Password { get; set; }
    }


    public class UserAdressDto
    {
        [Required(ErrorMessage = "StreetName is Required")]
        public string StreetName { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }
        [Required(ErrorMessage = "PostalCode is Required")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "PostalCode format 00000-000")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; }
    }
}
