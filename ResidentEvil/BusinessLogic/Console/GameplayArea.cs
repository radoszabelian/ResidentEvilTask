using ResidentEvil.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ResidentEvil.BusinessLogic.Console
{
	internal class GameplayArea
	{
		public int FirstX { get; set; }
		public int FirstY { get; set; }
		public int LastX { get; set; }
		public int LastY { get; set; }

		public bool CanWrap { get; set; }

		public char PlayerChar { get; }
		public List<ICharacter> GameCharacters { get; }

		public GameplayArea(IEnumerable<ICharacter> characters, char playerChar)
		{
			GameCharacters = characters.ToList();
			PlayerChar = playerChar;
		}

		public void RemoveCharacters(IEnumerable<ICharacter> characters)
		{
			foreach (var character in characters)
			{
				GameCharacters.Remove(character);
			}
		}
	}
}
