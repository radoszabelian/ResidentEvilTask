using System;
using System.ComponentModel.DataAnnotations;

namespace ResidentEvil.BusinessLogic.FileHandling.DTOs
{
	public class StageJson
	{
		[Range(3, int.MaxValue, ErrorMessage = "The stage's width must be at least 3")]
		public int Width { get; set; }

		[Range(3, int.MaxValue, ErrorMessage = "The stage's height must be at least 3")]
		public int Height { get; set; }

		public bool HasBorders { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "The stage's enemy count must be at least 1")]
		public int EnemyCount { get; set; }
	}
}
