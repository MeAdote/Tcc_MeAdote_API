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

        public async Task<Pet> Add(Pet model)
        {
            
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Pet.Add(model);
                

                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                transaction.Rollback();
                throw;
            }
            return model;
        }

        public IEnumerable<Pet> GetPets()
        {
            return _context.Pet;
        }
    }
}
