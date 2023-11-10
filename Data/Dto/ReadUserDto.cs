namespace Tcc_MeAdote_API.Data.Dto
{
    public class ReadUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string UserPicture { get; set; }
        public List<PetUserDto> PetUsersDto { get; set; }
    }




    public class PetUserDto
    {
        public string Name { get; set; }
        public string PetPicture { get; set; }
    }
}
