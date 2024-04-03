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
