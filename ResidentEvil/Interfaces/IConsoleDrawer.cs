namespace ResidentEvil.Interfaces
{
	public interface IConsoleDrawer
	{
		void CursorToLineStart();
		void DrawStage(IDisplayable player, ICharacter[] enemies);
		void UpdateCursorPosition();
	}
}