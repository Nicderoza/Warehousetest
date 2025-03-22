using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Repository.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        public UserRepository(WarehouseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task AddUserAsync(Users user)
        {
            await AddAsync(user);
        }

        public async Task UpdateUserAsync(Users user)
        {
            await UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            // Troviamo l'utente per ID
            var user = await GetUserByIdAsync(id);

            // Se l'utente esiste, lo eliminiamo passando solo l'ID
            if (user != null)
            {
                await DeleteAsync(id); // Qui, passiamo solo l'ID
            }
        }
    }
}
