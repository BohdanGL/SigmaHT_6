using System;

namespace SigmaHT_6_2
{
    class Visit
    {
        public string IPAddress { get; private set; }

        public TimeSpan Time { get; private set; }

        public DayOfWeek DayOfWeek { get; private set; }

        public Visit()
        {

        }
        public Visit(string ipAddress, TimeSpan time, DayOfWeek dayOfWeek)
        {
            IPAddress = ipAddress;
            Time = time;
            DayOfWeek = dayOfWeek;
        }

        public void Parse(string visit)
        {
            if (visit == String.Empty)
                throw new ArgumentException("String is empty");

            string[] values = visit.Split(' ');

            IPAddress = values[0];

            string[] timeValues = values[1].Split(':');
           
            int hours;
            if(!int.TryParse(timeValues[0], out hours))
                throw new ArgumentException("Bad input in hours");

            int minutes;
            if(!int.TryParse(timeValues[1], out minutes))
                throw new ArgumentException("Bad input in minutes");

            int seconds;
            if(!int.TryParse(timeValues[2], out seconds))
                throw new ArgumentException("Bad input in seconds");

            TimeSpan time = new TimeSpan(hours, minutes, seconds);

            Time = time;

            DayOfWeek dayOfWeek;
            if(!DayOfWeek.TryParse(values[2], out dayOfWeek))
                throw new ArgumentException("Bad input in day");

            DayOfWeek = dayOfWeek;
        }

    }
}
