using System;

namespace CodeWar
{
    public class TimeFormat
    {
        public static string GetReadableTime(int seconds)
            {
            var timeSpan = TimeSpan.FromSeconds(seconds);
            return timeSpan.ToString(@"hh\:mm\:ss");
//            var timeSpan = TimeSpan.FromMilliseconds(seconds);
//            // Converts the total miliseconds to the human readable time format
//            return timeSpan.ToString(@"hh\:mm\:ss\:fff");
            }
    }
}
