using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResidentEvil.Logging
{
    public static class Logger
    {
        public static void OnEnemyDeathEvent(IEnemy enemy, DateTime dateTime)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Log($"{enemy} - health: ({enemy.Health}), damage: ({enemy.Damage}) died: {dateTime}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void OnPlayerDeathEvent(IPlayer player, IEnemy enemy, DateTime dateTime)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log($"{player} died by {enemy} on {dateTime}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void OnPlayerHitEvent(IPlayer player, IEnemy enemy, DateTime dateTime)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Log($"{player.Name} was hit by a(n) {enemy}:{dateTime}. Remaining health is {player.Health}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
