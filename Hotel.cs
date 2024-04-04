using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string Name { get; }
        public int Rating { get; }
        public decimal WeekdayRateRegular { get; }
        public decimal WeekendRateRegular { get; }
        public decimal WeekdayRateReward { get; }
        public decimal WeekendRateReward { get; }
        public decimal TotalCost { get; set; }

        public Hotel(string name, int rating, decimal weekdayRateRegular, decimal weekendRateRegular, decimal weekdayRateReward, decimal weekendRateReward)
        {
            Name = name;
            Rating = rating;
            WeekdayRateRegular = weekdayRateRegular;
            WeekendRateRegular = weekendRateRegular;
            WeekdayRateReward = weekdayRateReward;
            WeekendRateReward = weekendRateReward;
        }
    }
}
