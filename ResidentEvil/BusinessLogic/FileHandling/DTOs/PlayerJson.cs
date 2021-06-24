using System;
using System.ComponentModel.DataAnnotations;

namespace ResidentEvil.BusinessLogic.FileHandling.DTOs
{
	public class PlayerJson
	{
		private const string RequiredError = "The player's {0} is required!";
		private const string RangeError = "The player's {0} must be at least 1!";

		[Required(AllowEmptyStrings = false, ErrorMessage = RequiredError)]
		public string Name { get; set; }

		[Required(ErrorMessage = RequiredError)]
		public PositionJson Position { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = RangeError)]
		public int Health { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = RangeError)]
		public int Damage { get; set; }
	}
}
