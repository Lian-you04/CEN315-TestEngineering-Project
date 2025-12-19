using GymBookingApp.Api.Models;

namespace GymBookingApp.Api.Services;

public interface IMemberService
{
    Task<IEnumerable<Member>> GetAllMembersAsync();
    Task AddMemberAsync(Member member);
    Task<bool> RemoveMemberAsync(int id);
    Task<Member?> GetMemberByIdAsync(int id);
}