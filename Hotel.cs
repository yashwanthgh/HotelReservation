using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string? Name { get; set; }
        public int Rating { get; set; }
        public decimal WeekdayRateRegular { get; set; }
        public decimal WeekendRateRegular { get; set; }
        public Decimal TotalCost { get; set; }

        public Hotel(string name, int rating, Decimal weekdayRateRegular, Decimal weekendRateRegular)
        {
            Name = name;
            Rating = rating;
            WeekdayRateRegular = weekdayRateRegular;
            WeekendRateRegular = weekendRateRegular;
        }

    }
}
