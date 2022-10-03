using System;
using System.Collections.Generic;
using JapanHoliday.Properties;
using Newtonsoft.Json;

namespace JapanHoliday
{
	public static class JapanHoliday
	{
		public static bool IsHoliday(DateTime date) => Holidays.GetInstance().IsHoliday(date);

		public static string GetHolidayName(DateTime date) =>
			Holidays.GetInstance().IsHoliday(date)
				? Holidays.GetInstance().GetHolidayName(date)
				: throw new Exception($"The specified date \"{date:yyyy-MM-dd}\" is not holiday.");

		public static bool TryGetHolidayName(DateTime date, out string name)
		{
			if (!IsHoliday(date))
			{
				name = null;
				return false;
			}

			name = GetHolidayName(date);
			return true;
		}
	}
}

internal class Holidays
{
	private static Holidays s_instance;
	private Dictionary<string, string> _dic;

	private Holidays(Dictionary<string, string> dictionary)
	{
		_dic = dictionary;
	}

	public static Holidays GetInstance() => s_instance ?? (s_instance = LoadFromJson());

	public bool IsHoliday(DateTime date) => _dic.ContainsKey(date.Format());

	public string GetHolidayName(DateTime date) => _dic[date.Format()];

	private static Holidays LoadFromJson() => 
		new Holidays(JsonConvert.DeserializeObject<Dictionary<string, string>>(Resources.Holidays));
}

internal static class DateTimeExtensions
{
	public static string Format(this DateTime date) => date.ToString("yyyy/MM/dd");
}
