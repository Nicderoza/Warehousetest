using Warehouse.Common.DTOs;

namespace Warehouse.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<DTOUser>> GetAllUsersAsync();
        Task<DTOUser> GetUserByIdAsync(int id);
        Task AddUserAsync(DTOUser user);
        Task UpdateUserAsync(DTOUser user);  // Questo è già sufficiente, non serve il metodo per Users
        Task DeleteUserAsync(int id);
    }
}
