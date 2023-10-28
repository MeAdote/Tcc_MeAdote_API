using System.ComponentModel.DataAnnotations;

namespace Tcc_MeAdote_API.Data.Dto;

public class CreatePetDto
{
    [Required(ErrorMessage = "Name is Required")]
    public string Name { get; set; }
    public string Race { get; set; }
    [Required(ErrorMessage = "Location is Required")]
    public string Location { get; set; }
    [Required(ErrorMessage = "Description is Required")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Age is Required")]
    public short Age { get; set; }
    [Required(ErrorMessage ="Pet Picture is required")]
    public string PetPicture { get; set; }
    [Required(ErrorMessage = "Pet Type is required")]
    public int PetTypeId { get; set; }
    public int UserId { get; set; }
    
    
}