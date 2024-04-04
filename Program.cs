using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ReservationSystem reservationSystem = new();

            try
            {
                DateTime from = DateTime.Parse("10452020");
                DateTime to = DateTime.Parse("12Sep2020");
                bool isRewarded = false;


                Hotel? cheapestHotel = reservationSystem.CheapestHotelForGivenDate(from, to, isRewarded);
                Console.WriteLine($"Cheapest Hotel is: {cheapestHotel?.Name}, Rate is: {cheapestHotel?.TotalCost}");

                List<Hotel> findCheapestHotelsForGivenDate = reservationSystem.FindCheapestHotelsForGivenDate(from, to, isRewarded);
                foreach (Hotel hotel in findCheapestHotelsForGivenDate)
                {
                    Console.WriteLine($"Cheapest Hotel is: {hotel?.Name}, Rate is: {hotel?.TotalCost}");
                }

                Hotel? cheapestBestRatedHotel = reservationSystem.CheapestBestRatedHotelForGivenDate(from, to, isRewarded);
                Console.WriteLine($"Cheapest Best Rated Hotel: {cheapestBestRatedHotel?.Name}, Rating: {cheapestBestRatedHotel?.Rating}, Total Rates: ${cheapestBestRatedHotel?.TotalCost}");

                Hotel? findBestRatedHotelForGivenDate = reservationSystem.FindBestRatedHotelForGivenDateAndRewardStatus(from, to, isRewarded);
                Console.WriteLine($"Best Rated Hotel is: {findBestRatedHotelForGivenDate?.Name}, Total Rate: {findBestRatedHotelForGivenDate?.TotalCost}");

                reservationSystem.ProperFormate(from, to);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date type format.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}

