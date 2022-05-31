using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistEditor.CoreTypes
{
    public static class TimeSpanExtensions
    {
        public static string ToFriendlyText(this TimeSpan duration)
        {
            return $"{duration.Hours:00}:{duration.Minutes:00}:{duration.Seconds:00}";
        }
    }
}
