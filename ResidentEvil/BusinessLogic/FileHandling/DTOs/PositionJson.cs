using System.ComponentModel.DataAnnotations;

namespace ResidentEvil.BusinessLogic.FileHandling.DTOs
{
	public class PositionJson
	{
		private const string RangeError = "The position's {0} must be at least 1!";

		[Range(0, int.MaxValue, ErrorMessage = RangeError)]
		public int X { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = RangeError)]
		public int Y { get; set; }
	}
}
