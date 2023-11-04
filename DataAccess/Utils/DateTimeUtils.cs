using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
	public class DateTimeUtils
	{
		public static DateTime ConvertUnixTimeToUtcDateTime(long unixTime)
		{
			DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTime);
			DateTime utcDateTime = dateTimeOffset.UtcDateTime;
			return utcDateTime;
		}
	}
}
