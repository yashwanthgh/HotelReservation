using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class ReservationSystem
    {
        readonly List<Hotel> hotels = [];
        public ReservationSystem()
        {
            hotels.Add(new Hotel("LakeWood", 3, 110, 90));
            hotels.Add(new Hotel("BridgeWood", 4, 160, 60));
            hotels.Add(new Hotel("RidgeWood", 5, 220, 150));
        }

        public Hotel? CheepHotelsForGivenDate(DateTime from, DateTime to)
        {
            Decimal maxCost = Decimal.MaxValue;
            Hotel? cheapestHotel = null;
            foreach (Hotel hotel in hotels)
            {
                hotel.TotalCost = CalculateTotalCost(hotel, from, to);
                if (hotel.TotalCost < maxCost)
                {
                    maxCost = hotel.TotalCost;
                    cheapestHotel = hotel;
                }
            }
            return cheapestHotel;
        }

        public Hotel? FindCheapestHotelsForGivenDate(DateTime from, DateTime to)
        {
            decimal cheapestRate = decimal.MaxValue;
            List<Hotel> cheapestHotels = new List<Hotel>();

            foreach (Hotel hotel in hotels)
            {
                decimal totalCost = CalculateTotalCost(hotel, from, to);
                if (totalCost < cheapestRate)
                {
                    cheapestRate = totalCost;
                    cheapestHotels.Clear();
                    cheapestHotels.Add(hotel);
                }
                else if (totalCost == cheapestRate)
                {
                    cheapestHotels.Add(hotel);
                }
            }
            foreach (Hotel hotel in cheapestHotels)
            {
                return hotel;
            }
            return null;
        }

        public Hotel? FindCheapestBestRatedHotel(DateTime from, DateTime to)
        {
            decimal cheapestRate = decimal.MaxValue;
            Hotel? cheapestBestRatedHotel = null;
            foreach (Hotel hotel in hotels)
            {
                decimal totalCost = CalculateTotalCost(hotel, from, to);
                if (totalCost < cheapestRate || (totalCost == cheapestRate && hotel.Rating > cheapestBestRatedHotel?.Rating))
                {
                    cheapestRate = totalCost;
                    cheapestBestRatedHotel = hotel;
                }
            }
            return cheapestBestRatedHotel;

        }

        public Hotel? FindBestRatedHotelForGivenDate(DateTime from, DateTime to)
        {
            int maxRating = 0;
            Hotel? bestRatedHotel = null;

            foreach (Hotel hotel in hotels)
            {
                if (hotel.Rating > maxRating)
                {
                    maxRating = hotel.Rating;
                    bestRatedHotel = hotel;
                }
            }

            if (bestRatedHotel != null)
            {
                decimal totalCost = CalculateTotalCost(bestRatedHotel, from, to);
                bestRatedHotel.TotalCost = totalCost;
                return bestRatedHotel;
            }
            else
            {
                return null;
            }
        }
        private Decimal CalculateTotalCost(Hotel hotel, DateTime from, DateTime to)
        {
            decimal total = 0;
            int weekendDays = 0;
            int weekDays = 0;
            for (DateTime date = from; date <= to; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday) weekendDays++;
                else weekDays++;
            }

            total = weekendDays * hotel.WeekendRateRegular + weekDays * hotel.WeekdayRateRegular;
            return total;
        }


    }
}
