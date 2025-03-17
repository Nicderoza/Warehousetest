using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IRepositories;

public interface IUserRepository : IGenericRepository<Users>
{
    Task AddUserAsync(Users user);
    Task DeleteUserAsync(int id);
    Task<IEnumerable<Users>> GetAllUsersAsync();
    Task<Users> GetUserByIdAsync(int id);
    Task UpdateUserAsync(Users user);
}
