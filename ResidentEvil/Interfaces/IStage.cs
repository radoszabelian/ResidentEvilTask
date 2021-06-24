namespace ResidentEvil.Interfaces
{
	internal interface IStage: IStageApperance
	{
		public IPlayer Player { get; }
		public IEnemy[] Enemies { get; }
	}
}
