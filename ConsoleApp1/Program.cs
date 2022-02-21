using System;
using System.Collections.Generic;
using System.Linq;

namespace RemainingDays
{
    public static class Program
    {
        static void Main(string[] args)
        {
            DateTime end = new(2022, 6, 3);

            List<DateTime> datesToExclude = new List<DateTime>()
            {
                new DateTime(2022,4,5),
                new DateTime(2022,4,6),
                new DateTime(2022,6,2)
            };

            Console.WriteLine($"{ GetSchoolDays(DateTime.Now, end, datesToExclude)} days remaining :D");
        }

        public static int GetSchoolDays(DateTime current, DateTime end, List<DateTime> datesToExclude)
        {
            bool isWorkingDay(int days)
            {
                DateTime currentDate = current.AddDays(days);
                bool isNonWorkingDay =
                    currentDate.DayOfWeek == DayOfWeek.Saturday ||
                    currentDate.DayOfWeek == DayOfWeek.Sunday ||
                    currentDate.DayOfWeek == DayOfWeek.Friday ||
                    datesToExclude.Exists(Dates => Dates.Date.Equals(currentDate.Date));

                return !isNonWorkingDay;
            }

            return Enumerable.Range(0, (end - current).Days).Count(isWorkingDay);
        }
    }
}

