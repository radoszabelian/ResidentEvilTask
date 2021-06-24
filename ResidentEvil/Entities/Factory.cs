using ResidentEvil.Interfaces;
using ResidentEvil.Logging;

namespace ResidentEvil.Entities
{
    public class Factory : IFactory
    {
        public IEnemy CreateBioZombie(int health, float radaiation, IPosition position)
        {
            BioZombie bioZombie = new BioZombie(position, health, radaiation);
            bioZombie.DeathEvent += Logger.OnEnemyDeathEvent;

            return bioZombie;
        }

        public IBoss CreateNemesis(int health, int damage, IPosition position)
        {
            var nemesis = new Nemesis(position, health, damage);
            nemesis.DeathEvent += Logger.OnEnemyDeathEvent;

            return nemesis;
        }

        public IPlayer CreatePlayer(string name, int health, int damage, IPosition position)
        {
            var player = new Player(name, health, damage, position);
            player.DeathEvent += Logger.OnPlayerDeathEvent;
            player.HitEvent += Logger.OnPlayerHitEvent;

            return player;
        }

        public IPosition CreatePosition(int x, int y)
        {
            return new Position(x, y);
        }

        public IEnemy CreateRunningZombie(int health, int stamina, IPosition position)
        {
            var runningZombie = new RunningZombie(position, health, stamina);
            runningZombie.DeathEvent += Logger.OnEnemyDeathEvent;

            return runningZombie;
        }

        public IBoss CreateTyrant(int health, int damage, IPosition position)
        {
            var tyrant = new Tyrant(position, health, damage);
            tyrant.DeathEvent += Logger.OnEnemyDeathEvent;

            return tyrant;
        }
    }
}
