

using Tcc_MeAdote_API.Entities.Pets;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Repositories.PetRepository
{
    public interface IPetRepository
    {
        public Task<Pet> Add(Pet model);
        public IEnumerable<Pet> GetPets();
    }
}
