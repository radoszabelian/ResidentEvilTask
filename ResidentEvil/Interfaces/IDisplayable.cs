namespace ResidentEvil.Interfaces
{
	internal interface IDisplayable
	{
		char DisplayChar { get; }
		IPosition Position { get; }
	}
}
