using GymBookingApp.Api.Models;

namespace GymBookingApp.Api.Repositories;

public interface IMemberRepository
{
    Task<Member?> GetByIdAsync(int id);
    Task DeleteMemberAsync(int id);
    Task<IEnumerable<Member>> GetAllAsync();
    Task AddAsync(Member member);
}