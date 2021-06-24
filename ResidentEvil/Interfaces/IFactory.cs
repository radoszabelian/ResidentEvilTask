namespace ResidentEvil.Interfaces
{
	internal interface IFactory
	{
		IPlayer CreatePlayer(string name, int health, int damage, IPosition position);
		IEnemy CreateRunningZombie(int health, int stamina, IPosition position);
		IEnemy CreateBioZombie(int health, float radaiation, IPosition position);
		IBoss CreateNemesis(int health, int damage, IPosition position);
		IBoss CreateTyrant(int health, int damage, IPosition position);
		IPosition CreatePosition(int x, int y);
	}
}
