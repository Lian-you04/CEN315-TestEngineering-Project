using GymBookingApp.Api.Repositories;
using GymBookingApp.Api.Models;

namespace GymBookingApp.Api.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _memberRepository.GetAllAsync();
        }

       
        public async Task<Member?> GetMemberByIdAsync(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }

        public async Task AddMemberAsync(Member member)
        {
       
            if (member != null)
            {
                await _memberRepository.AddAsync(member);
            }
        }

        public async Task<bool> RemoveMemberAsync(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);

            if (member == null)
            {
                return false; 
            }

            await _memberRepository.DeleteMemberAsync(id);
            return true;
        }
    }
}