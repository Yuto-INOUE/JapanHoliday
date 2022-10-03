using System;
using FluentAssertions;

namespace JapanHoliday.Test
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void Test_IsHoliday_ReturnsFalse()
		{
			JapanHoliday.IsHoliday(new DateTime(2020, 1, 14)).Should().BeFalse();
		}

		[TestMethod]
		public void Test_IsHoliday_ReturnsTrue()
		{
			JapanHoliday.IsHoliday(new DateTime(2020, 1, 13)).Should().BeTrue();
		}

		[TestMethod]
		public void Test_GetHolidayName_ReturnsValue()
		{
			JapanHoliday.GetHolidayName(new DateTime(2020, 1, 13)).Should().Be("¬l‚Ì“ú");
		}

		[TestMethod]
		public void Test_GetHolidayName_Throws()
		{
			var action = () => JapanHoliday.GetHolidayName(new DateTime(2020, 1, 14));
			action.Should().Throw<Exception>().WithMessage("The specified date \"2020-01-14\" is not holiday.");
		}

		[TestMethod]
		public void Test_TryGetHolidayName_ReturnsTrue()
		{
			var returns = JapanHoliday.TryGetHolidayName(new DateTime(2020, 1, 13), out var name);
			returns.Should().Be(true);
			name.Should().NotBeNull();

			name!.Should().Be("¬l‚Ì“ú");
		}

		[TestMethod]
		public void Test_TryGetHolidayName_ReturnsFalse()
		{
			var returns = JapanHoliday.TryGetHolidayName(new DateTime(2020, 1, 14), out var name);
			returns.Should().Be(false);
			name.Should().BeNull();
		}
	}
}