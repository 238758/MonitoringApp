using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM4017Library.Helpers;

public static class DateTimeHelpers
{
    /// <summary>
    /// Convert time from utc to norwegian time
    /// </summary>
    /// <param name="utcTime"></param>
    /// <returns></returns>
    public static DateTime? UtcTime2Local(DateTime? utcTime)
    {
        if (utcTime != null)
        {
            // converts to time of machine running code, in this case server
            //return TimeZoneInfo.ConvertTimeFromUtc(utcTime.Value, TimeZoneInfo.Local);
            
            // convert to norwegian time
            return utcTime.Value.AddHours(2);

            // Convert DateTime to user's time zone with server-side Blazor. JSInterop
            // https://www.meziantou.net/convert-datetime-to-user-s-time-zone-with-server-side-blazor.htm

        }
        else
        {
            return null;
        }
    }

    public static string? DateTimePrintFormatter(DateTime? time)
    {
        if (time != null)
        {
            // convert to norwegian time
            return time.Value.ToString("dd-MM-yy HH:mm:ss");
        }
        else
        {
            return null;
        }
    }

}


