namespace ResidentEvil.Interfaces
{
	internal interface ICharacter: IDisplayable
	{
		int Health { get; }
		int Damage { get; }
	}
}
