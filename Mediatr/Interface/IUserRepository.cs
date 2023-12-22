using Mediator.Domains;
using Mediatr.Domains;

namespace Mediator.Interface
{
    public interface IUserRepository
    {
        public Task<UserDetail> Register(UserDto request);
        public Task<string> Login(UserDto userDetail);
        public Task<List<UserDetail>> GetUserListAsync();
        public Task<UserDetail> GetUserByIdAsync(string Id);

        public Task<UserDetail> AddUserAsync(UserDetail userDetails);
        public Task<int> UpdateUserAsync(UserDetail userDetails);
        public Task<int> DeleteUserAsync(string Id);
    }
}
