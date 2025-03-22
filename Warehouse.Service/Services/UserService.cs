using AutoMapper;
using Warehouse.Common.DTOs;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;
using Warehouse.Interfaces.IServices;
namespace Warehouse.Service.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DTOUser>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return _mapper.Map<IEnumerable<DTOUser>>(users);  // Mappiamo Users a DTOUser
    }

    public async Task<DTOUser> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return _mapper.Map<DTOUser>(user);  // Mappiamo Users a DTOUser
    }

    public async Task AddUserAsync(DTOUser userDTO)
    {
        var user = _mapper.Map<Users>(userDTO);  // Mappiamo DTOUser a Users
        await _userRepository.AddUserAsync(user);
    }

    public async Task UpdateUserAsync(DTOUser userDTO)
    {
        var user = _mapper.Map<Users>(userDTO);  // Mappiamo DTOUser a Users
        await _userRepository.UpdateUserAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);
    }
}
