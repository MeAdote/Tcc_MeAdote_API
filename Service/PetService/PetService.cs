using AutoMapper;
using Tcc_MeAdote_API.Repositories.PetRepository;
using Tcc_MeAdote_API.Repositories.UserRepository;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly IUserRepository _userRepository;
    public PetService(IPetRepository petRepository, IUserRepository userRepository)
    {
        _petRepository = petRepository;
        _userRepository = userRepository;

    }

    public ReadPetDto GetPetById(int id)
    {
        var pet = _petRepository.GetPetById(id);
        var user = _userRepository.GetById(pet.UserId);

        var petDto = new ReadPetDto 
        {
            Id = pet.Id,
            Name = pet.Name,
            Race = pet.Race,
            Location = pet.Race,
            Description = pet.Description,
            PetPicture = pet.PetPicture,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        return petDto;
    }
}