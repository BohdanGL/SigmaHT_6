using System;

namespace SigmaHT_6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            VisitAccounting vistiAccounting = new VisitAccounting();

            vistiAccounting.GetDataFromFile();

            Console.WriteLine("Number of visits for every IP:\n");

            (string, int)[] visitCounts = vistiAccounting.GetVisitCountForIPs();

            for (int i = 0; i < visitCounts.Length; i++)
            {
                Console.WriteLine(visitCounts[i]);
            }

            Console.WriteLine("\nThe most popular day for every IP:\n");

            (string, DayOfWeek)[] visitPopularDay = vistiAccounting.GetMostPopularDayForIPs();

            for (int i = 0; i < visitCounts.Length; i++)
            {
                Console.WriteLine(visitPopularDay[i]);
            }

            Console.WriteLine("\nThe most popular hour for every IP:\n");

            (string, TimeSpan, TimeSpan)[] visitPopularHour = vistiAccounting.GetMostPopularHourForIPs();

            for (int i = 0; i < visitCounts.Length; i++)
            {
                Console.WriteLine(visitPopularHour[i]);
            }

            Console.WriteLine("\nThe most popular hour for site\n");

            Console.WriteLine(vistiAccounting.GetMostPopularHourForSite());
        }
    }
}
