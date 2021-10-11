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
            int.TryParse(timeValues[0], out hours);

            int minutes;
            int.TryParse(timeValues[1], out minutes);

            int seconds;
            int.TryParse(timeValues[2], out seconds);

            TimeSpan time = new TimeSpan(hours, minutes, seconds);

            Time = time;

            DayOfWeek dayOfWeek;
            DayOfWeek.TryParse(values[2], out dayOfWeek);

            DayOfWeek = dayOfWeek;
        }

    }
}
