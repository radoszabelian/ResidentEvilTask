namespace ResidentEvil.Interfaces
{
	internal interface IConsoleDrawer
	{
		void CursorToLineStart();
		void DrawStage(IDisplayable player, ICharacter[] enemies);
		void UpdateCursorPosition();
	}
}