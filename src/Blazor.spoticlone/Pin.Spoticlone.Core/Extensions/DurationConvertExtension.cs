using System;
using System.Text;

namespace Pin.Spoticlone.Core.Extensions
{
    public static class DurationConvertExtension
    {
        public static string ConvertToStringDuration(this int ms)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(ms);
            StringBuilder stringBuilder = new StringBuilder();

            if (timeSpan.Hours != 0)
            {
                stringBuilder.Append($"{timeSpan.Hours}:");
            }

            stringBuilder.Append($"{timeSpan.Minutes.ToString("00")}:");
            stringBuilder.Append(timeSpan.Seconds.ToString("00"));

            return stringBuilder.ToString();
        }
        public static string ConvertToStringDuration(this long ms)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(ms);
            StringBuilder stringBuilder = new StringBuilder();

            if (timeSpan.Days != 0)
            {
                stringBuilder.Append($"{timeSpan.Days} days, ");
            }

            if (timeSpan.Hours != 0)
            {
                stringBuilder.Append($"{timeSpan.Hours} hours, ");
            }

            stringBuilder.Append($"{timeSpan.Minutes.ToString("00")} minutes, ");
            stringBuilder.Append($"{timeSpan.Seconds.ToString("00")} seconds");

            return stringBuilder.ToString();
        }
    }
}