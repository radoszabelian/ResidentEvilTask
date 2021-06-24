namespace ResidentEvil.Interfaces
{
	public interface IStage: IStageApperance
	{
		public IPlayer Player { get; }
		public IEnemy[] Enemies { get; }
	}
}
