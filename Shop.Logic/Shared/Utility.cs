using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Logic.Shared
{
    public class Utility
    {
        public static string getIndianDateTime()
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            return indianTime.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }
        
    }
}
