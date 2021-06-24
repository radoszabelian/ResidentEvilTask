using System.ComponentModel.DataAnnotations;

namespace ResidentEvil.BusinessLogic.FileHandling.DTOs
{
	public class AllJson
	{
		private const string RequiredError = "The json file's {0} is required!";

		[Required(ErrorMessage = RequiredError)]
		public StageJson Stage { get; set; }

		[Required(ErrorMessage = RequiredError)]
		public PlayerJson Player { get; set; }
		
		[Required(ErrorMessage = RequiredError)]
		public EnemyJson[] Enemies { get; set; }
	}
}
