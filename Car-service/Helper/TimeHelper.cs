using Car_service.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Helper
{
    public class TimeHelper
    {
        public static DateTime GetDateTime()
        {
            var dtTime = DateTime.UtcNow;
            dtTime.AddHours(TimeConstants.UTC);
            return dtTime;
        }
    }
}
