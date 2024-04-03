﻿using System;
using System.Collections.Generic;

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
            List<Hotel> cheapestHotels = new List<Hotel>();

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
    }
}
