namespace GymBookingApp.Api.Models;

public enum MembershipType
{
    Standard,
    Premium,
    Student
}

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public MembershipType Type { get; set; }
}