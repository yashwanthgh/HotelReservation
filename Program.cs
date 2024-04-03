using HotelReservationSystem;

internal class Program
{
    public static void Main(string[] args)
    {
        ReservationSystem reservationSystem = new();
        DateTime from = DateTime.Parse("10Sep2020");
        DateTime to = DateTime.Parse("11Sep2020");
        Hotel? hotel = reservationSystem.CheepHotelsForGivenDate(from, to);
        Console.WriteLine($"Hotel is: {hotel?.Name} Rate is: {hotel?.TotalCost}");
        Hotel? findCheapestHotelsForGivenDate = reservationSystem.CheepHotelsForGivenDate(from, to);
        Console.WriteLine($"Hotel is: {findCheapestHotelsForGivenDate?.Name} Rate is: {findCheapestHotelsForGivenDate?.TotalCost} ");
    }
}