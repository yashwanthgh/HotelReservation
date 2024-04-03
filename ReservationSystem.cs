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

        public ReservationSystem(string name, int rating, Decimal weekDay, Decimal weekendDay)
        {
            hotels.Add(new Hotel(name, rating, weekDay, weekendDay));
        }
    }
}
