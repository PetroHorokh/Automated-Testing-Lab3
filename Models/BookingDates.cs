namespace Lab3.Models;

public class BookingDates
{
    public BookingDates(string checking, string checkout)
    {
        this.checkin = checking;
        this.checkout = checkout;
    }

    public string checkin { get; set; }
    public string checkout { get; set; }
}