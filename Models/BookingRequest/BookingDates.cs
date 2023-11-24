namespace Lab3.Models.BookingRequest;

public class BookingDates
{
    public BookingDates(string checking, string checkout)
    {
        checkin = checking;
        this.checkout = checkout;
    }

    public string checkin { get; set; }
    public string checkout { get; set; }
}