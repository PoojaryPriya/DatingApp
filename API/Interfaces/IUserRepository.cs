using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUserClass user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUserClass>> GetUserAsync();
        Task<AppUserClass> GetUserByIdAsync(int id);
        Task<AppUserClass> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string username);
    }
}