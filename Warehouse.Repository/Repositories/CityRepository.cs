using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;

namespace Warehouse.Repository.Repositories
{
    public class CityRepository : GenericRepository<Cities>, ICityRepository
    {
        public CityRepository(WarehouseContext context) : base(context)
        {
        }

        public async Task<Cities?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<Cities>> GetAllCitiesAsync() //provare a eleiminare il ToList la query verrà gestita da un'altra parte
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Cities?> GetCityByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task UpdateAsync(Cities entity)
        {
            // Verifica che l'entità esista già nel contesto
            var existingEntity = await _context.Cities.FindAsync(entity.CityID);

            if (existingEntity != null)
            {
                // Stacca l'entità già tracciata
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _dbSet.Update(entity);  // Aggiorna l'entità
            await _context.SaveChangesAsync();
        }
    }
}
