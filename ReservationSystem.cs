using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HotelReservationSystem
{
    public class ReservationSystem
    {
        private readonly List<Hotel> hotels = [];

        public ReservationSystem()
        {
            hotels.Add(new Hotel("LakeWood", 3, 110, 90, 80, 80));
            hotels.Add(new Hotel("BridgeWood", 4, 160, 60, 110, 50));
            hotels.Add(new Hotel("RidgeWood", 5, 220, 150, 100, 40));
        }

        public Hotel? CheapestHotelForGivenDate(DateTime from, DateTime to, bool isRewardCustomer)
        {
            decimal minCost = decimal.MaxValue;
            Hotel? cheapestHotel = null;

            foreach (Hotel hotel in hotels)
            {
                decimal totalCost = CalculateTotalCost(hotel, from, to, isRewardCustomer);
                if (totalCost < minCost)
                {
                    minCost = totalCost;
                    cheapestHotel = hotel;
                    cheapestHotel.TotalCost = totalCost;
                }
            }

            return cheapestHotel;
        }

        public List<Hotel> FindCheapestHotelsForGivenDate(DateTime from, DateTime to, bool isRewardCustomer)
        {
            decimal cheapestRate = decimal.MaxValue;
            List<Hotel> cheapestHotels = [];

            foreach (Hotel hotel in hotels)
            {
                decimal totalCost = CalculateTotalCost(hotel, from, to, isRewardCustomer);
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
                hotel.TotalCost = cheapestRate;
            }

            return cheapestHotels;
        }

        public Hotel? FindBestRatedHotelForGivenDateAndRewardStatus(DateTime from, DateTime to, bool isRewardCustomer)
        {
            int maxRating = 0;
            Hotel? bestRatedHotel = null;

            foreach (Hotel hotel in hotels)
            {
                decimal totalCost = CalculateTotalCost(hotel, from, to, isRewardCustomer);
                if (bestRatedHotel == null || hotel.Rating > maxRating || (hotel.Rating == maxRating && totalCost < bestRatedHotel.TotalCost))
                {
                    maxRating = hotel.Rating;
                    bestRatedHotel = hotel;
                    bestRatedHotel.TotalCost = totalCost;
                }
            }

            return bestRatedHotel;
        }

        public Hotel? CheapestBestRatedHotelForGivenDate(DateTime from, DateTime to, bool isRewardCustomer)
        {
            decimal minCost = decimal.MaxValue;
            Hotel? cheapestBestRatedHotel = null;

            foreach (Hotel hotel in hotels)
            {
                decimal totalCost = CalculateTotalCost(hotel, from, to, isRewardCustomer);
                if (totalCost < minCost || (totalCost == minCost && hotel.Rating > cheapestBestRatedHotel?.Rating))
                {
                    minCost = totalCost;
                    cheapestBestRatedHotel = hotel;
                    cheapestBestRatedHotel.TotalCost = totalCost;
                }
            }

            return cheapestBestRatedHotel;
        }

        private decimal CalculateTotalCost(Hotel hotel, DateTime from, DateTime to, bool isRewardCustomer)
        {
            decimal totalCost = 0;
            int weekendDays = 0;
            int weekDays = 0;
            decimal weekdayRate = isRewardCustomer ? hotel.WeekdayRateReward : hotel.WeekdayRateRegular;
            decimal weekendRate = isRewardCustomer ? hotel.WeekendRateReward : hotel.WeekendRateRegular;

            for (DateTime date = from; date <= to; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    weekendDays++;
                else
                    weekDays++;
            }

            totalCost = weekendDays * weekendRate + weekDays * weekdayRate;
            return totalCost;
        }

        public Hotel? FindCheapestBestRatedHotelForGivenDateRange(DateTime fromDate, DateTime toDate, bool isRewardCustomer)
        {
            ValidateDateRange(fromDate, toDate);
            ValidateCustomerType(isRewardCustomer);

            decimal minCost = decimal.MaxValue;
            Hotel? cheapestBestRatedHotel = null;

            foreach (Hotel hotel in hotels)
            {
                decimal totalCost = CalculateTotalCost(hotel, fromDate, toDate, isRewardCustomer);
                if (totalCost < minCost || (totalCost == minCost && hotel.Rating > cheapestBestRatedHotel?.Rating))
                {
                    minCost = totalCost;
                    cheapestBestRatedHotel = hotel;
                    cheapestBestRatedHotel.TotalCost = totalCost;
                }
            }

            return cheapestBestRatedHotel;
        }

        private void ValidateDateRange(DateTime fromDate, DateTime toDate)
        {
            if (fromDate >= toDate)
            {
                throw new ArgumentException("End date must be after start date.");
            }
        }

        private void ValidateCustomerType(bool isRewardCustomer)
        {
            if (isRewardCustomer != true && isRewardCustomer != false)
            {
                throw new ArgumentException("Invalid value for customer type. Please enter 'true' for reward customer or 'false' for regular customer.");
            }
        }

        public void ProperFormate(DateTime from, DateTime to)
        {
            string pattern = @"\d{2}\w{3}\d{4}"; 
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(from.ToString("ddMMMyyyy")) || !regex.IsMatch(to.ToString("ddMMMyyyy")))
            {
                throw new FormatException("Invalid format");
            }
        }

    }
}
