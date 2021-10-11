using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SigmaHT_6_2
{
    class VisitAccounting
    {
        private Visit[] visits;

        public void GetDataFromFile(string filePath =
            @"C:\Users\User\source\repos\SigmaHT_6\SigmaHT_6_2\Input.txt")
        {
            StreamReader streamReader = new StreamReader(filePath);

            string text = streamReader.ReadToEnd().Replace("\r", String.Empty);

            string[] visits = text.Split('\n');

            this.visits = new Visit[visits.Length];

            for (int i = 0; i < visits.Length; i++)
            {
                Visit visit = new Visit();

                visit.Parse(visits[i]);

                this.visits[i] = visit;
            }
        }

        public List<string> GetUniqueIPs()
        {
            List<string> uniqueIPs = new List<string>();

            for (int i = 0, k = 0; k < visits.Length; i++, k++)
            {
                uniqueIPs.Add(visits[k].IPAddress);

                for (int j = 0; j < i; j++)
                {
                    if (uniqueIPs[i] == uniqueIPs[j])
                    {
                        uniqueIPs.Remove(uniqueIPs[i]);
                        i--;
                        break;
                    }
                }
            }

            return uniqueIPs;
        }

        public (string,int)[] GetVisitCountForIPs()
        {
            List<string> uniqueIPs = GetUniqueIPs();

            (string, int)[] visitCounts = new (string, int)[uniqueIPs.Count];

            int count;

            for (int i = 0; i < uniqueIPs.Count; i++)
            {
                visitCounts[i] = (uniqueIPs[i], GetVisitCount(uniqueIPs[i]));
            }

            return visitCounts;
        }

        public (string,DayOfWeek)[] GetMostPopularDayForIPs()
        {
            List<string> uniqueIPs = GetUniqueIPs();

            (string, DayOfWeek)[] visitPopularDay = new (string, DayOfWeek)[uniqueIPs.Count];

            for (int i = 0; i < visitPopularDay.Length; i++)
            {
                visitPopularDay[i] = (uniqueIPs[i], (DayOfWeek)GetMostPopularDay(uniqueIPs[i]));
            }

            return visitPopularDay;
        }

        public (string,TimeSpan,TimeSpan)[] GetMostPopularHourForIPs()
        {
            List<string> uniqueIPs = GetUniqueIPs();

            (string, TimeSpan, TimeSpan)[] visitPopularHour = new (string, TimeSpan, TimeSpan)[uniqueIPs.Count];

            for (int i = 0; i < visitPopularHour.Length; i++)
            {
                visitPopularHour[i] = (uniqueIPs[i],
                    new TimeSpan(GetMostPopularHour(uniqueIPs[i]), 0, 0),
                    new TimeSpan(GetMostPopularHour(uniqueIPs[i]) + 1, 0, 0));
            }

            return visitPopularHour;
        }

        public (TimeSpan,TimeSpan) GetMostPopularHourForSite()
        { 
            return (new TimeSpan(GetMostPopularHour(String.Empty), 0, 0),
                    new TimeSpan(GetMostPopularHour(String.Empty) + 1, 0, 0));
        }

        public int GetVisitCount(string IP)
        {
            int count = 0;

            for (int i = 0; i < visits.Length; i++)
            {
                if (IP == visits[i].IPAddress)
                    count++;
            }

            return count;
        }

        public DayOfWeek GetMostPopularDay(string IP)
        {
            int[] dayOfWeek = new int[7];

            for (int i = 0; i < visits.Length; i++)
            {
                if(IP==visits[i].IPAddress)
                {
                    dayOfWeek[(int)visits[i].DayOfWeek]++;
                }
            }

            int index = Array.IndexOf(dayOfWeek, dayOfWeek.Max());

            return (DayOfWeek)index;
        }

        public int GetMostPopularHour(string IP)
        {
            int[] hours = new int[24];
            int hour;

            if (IP != String.Empty)
            {
                for (int i = 0; i < visits.Length; i++)
                {
                    if (IP == visits[i].IPAddress)
                    {
                        hours[visits[i].Time.Hours]++;
                    }
                }

                hour = Array.IndexOf(hours, hours.Max());

                return hour;
            }

            for (int i = 0; i < visits.Length; i++)
            {
                hours[visits[i].Time.Hours]++;
            }

            hour = Array.IndexOf(hours, hours.Max());

            return hour;
        }
    }
}
