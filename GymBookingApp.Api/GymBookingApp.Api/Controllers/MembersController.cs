using Microsoft.AspNetCore.Mvc;
using GymBookingApp.Api.Models;
using GymBookingApp.Api.Services;

namespace GymBookingApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MembersController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var members = await _memberService.GetAllMembersAsync();
        return Ok(members);
    }

  
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var member = await _memberService.GetMemberByIdAsync(id);
        if (member == null)
        {
            return NotFound($"{id} ID'li kullanıcı bulunamadı.");
        }
        return Ok(member);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Member? member)
    {
        if (member == null)
        {
            return BadRequest("Kullanıcı verisi boş olamaz.");
        }

        await _memberService.AddMemberAsync(member);

        
        return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
    }

   
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _memberService.RemoveMemberAsync(id);

        if (!success)
        {
            return NotFound($"{id} ID'li kullanıcı bulunamadı.");
        }

        return NoContent();
    }
}