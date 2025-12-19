using GymBookingApp.Api.Models;

namespace GymBookingApp.Api.Repositories;

public class MemberRepository : IMemberRepository
{
   
    private static readonly List<Member> _members = new()
    {
        new Member { Id = 1, Name = "Dahir", Type = MembershipType.Student }
    };

    public async Task<Member?> GetByIdAsync(int id)
    {
        var member = _members.FirstOrDefault(m => m.Id == id);
        return await Task.FromResult(member);
    }

    public async Task<IEnumerable<Member>> GetAllAsync()
    {
        
        return await Task.FromResult(_members.AsEnumerable());
    }

    public async Task AddAsync(Member member)
    {
        
        if (member != null)
        {
            _members.Add(member);
        }
        await Task.CompletedTask;
    }

    public async Task DeleteMemberAsync(int id)
    {
        var member = _members.FirstOrDefault(m => m.Id == id);
        if (member != null)
        {
            _members.Remove(member);
        }
        await Task.CompletedTask;
    }
}