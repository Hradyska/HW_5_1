using HTTPClientFactoryPractice.Dtos;
using HTTPClientFactoryPractice.Dtos.Responses;

namespace HTTPClientFactoryPractice.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserResponse> CreateUserAsync(string name, string job);
        Task<List<UserDto>> GetListUsersAsync();
        Task<UserResponse> PutUserAsync(int id, string name, string job);
        Task<UserResponse> PatchUserAsync(int id, string name = null, string job = null);
        Task DeleteUserAsync(int id);
    }
}
