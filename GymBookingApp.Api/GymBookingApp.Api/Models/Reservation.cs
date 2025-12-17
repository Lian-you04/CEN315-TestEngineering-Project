namespace GymBookingApp.Api.Models;

public class Reservation
{
    public int Id { get; set; }
    public Member Member { get; set; } = new();
    public DateTime BookingDate { get; set; }
    public decimal FinalPrice { get; set; }
}