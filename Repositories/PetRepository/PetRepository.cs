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

        public Pet Add(Pet model)
        {
            try
            {
                _context.Pet.Add(model);
                _context.SaveChanges();

                return model;
            }
            catch (Exception e)
            {

                throw new Exception($"Error: {e.Message}, {e.InnerException}");
            }
        }

        public Pet GetPetById(int id)
        {
            var pet = _context.Pet.FirstOrDefault(p => p.Id == id);

            return pet;
        }

        public IEnumerable<Pet> GetPets()
        {
            return _context.Pet;
        }
    }
}
