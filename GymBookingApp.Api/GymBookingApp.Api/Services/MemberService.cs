using GymBookingApp.Api.Repositories;

namespace GymBookingApp.Api.Services
{
    public class MemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
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