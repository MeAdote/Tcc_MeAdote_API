using Tcc_MeAdote_API.Data;
using Tcc_MeAdote_API.Entities.Pets;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Repositories.PetRepository
{
    public class PetRepository : IPetRepository
    {
        private readonly Context _context;
        public PetRepository(Context context)
        {
            _context = context;
        }
       public IEnumerable<Pet> GetPets()
        {
            return _context.Pet;
        }


    }
}
