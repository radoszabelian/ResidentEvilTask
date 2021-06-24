using System;
using System.ComponentModel.DataAnnotations;

namespace ResidentEvil.BusinessLogic.FileHandling.DTOs
{
	public class EnemyJson
	{
		private const string RequiredError = "The enemy's {0} is required!";
		private const string RangeError = "The enemy's {0} must be at least 1!";
		private const string RegexError = "The enemy's type must be one of these: runningZombie, bioZombie, nemesis, tyrant!";

		[RegularExpression("([Rr]unningZombie|[Bb]ioZombie|[Nn]emesis|[Tt]yrant)", ErrorMessage = RegexError)]
		public string Type { get; set; }

		[Required(ErrorMessage = RequiredError)]
		public PositionJson Position { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = RangeError)]
		public int Health { get; set; }

		[CustomValidation(typeof(EnemyJson), "ValidateDamage", ErrorMessage = "The nemesis' or tyrant's damage must be at least 1!")]
		public int? Damage { get; set; }

		[CustomValidation(typeof(EnemyJson), "ValidateStamina", ErrorMessage = "The running zombie's stamina must be at least 1!")]
		public int? Stamina { get; set; }

		[CustomValidation(typeof(EnemyJson), "ValidateRadiation", ErrorMessage = "The bio zombie's radiation must be at least 1!")]
		public float? Radiation { get; set; }

		public static ValidationResult ValidateDamage(EnemyJson enemy)
		{
			if (!(enemy.Type.Equals("nemesis", StringComparison.InvariantCultureIgnoreCase)
				|| enemy.Type.Equals("tyrant", StringComparison.InvariantCultureIgnoreCase)))
				return ValidationResult.Success;

			if (enemy.Damage.HasValue && enemy.Damage > 0)
				return ValidationResult.Success;

			return new ValidationResult($"The {enemy.Type}'s damage must be at least 1!");
		}

		public static ValidationResult ValidateStamina(EnemyJson enemy)
		{
			if (!enemy.Type.Equals("runningzombie", StringComparison.InvariantCultureIgnoreCase))
				return ValidationResult.Success;


			if (enemy.Stamina.HasValue && enemy.Stamina > 0)
				return ValidationResult.Success;

			return new ValidationResult($"The {enemy.Type}'s stamina must be at least 1!");
		}

		public static ValidationResult ValidateRadiation(EnemyJson enemy)
		{
			if (!enemy.Type.Equals("biozombie", StringComparison.InvariantCultureIgnoreCase))
				return ValidationResult.Success;

			if (enemy.Radiation.HasValue && enemy.Radiation > 0)
				return ValidationResult.Success;

			return new ValidationResult($"The {enemy.Type}'s radiation must be at least 1!");
		}
	}
}
