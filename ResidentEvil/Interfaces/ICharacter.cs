namespace ResidentEvil.Interfaces
{
	public interface ICharacter: IDisplayable
	{
		int Health { get; }
		int Damage { get; }
	}
}
