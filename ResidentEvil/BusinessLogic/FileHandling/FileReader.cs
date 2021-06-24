using Newtonsoft.Json;
using ResidentEvil.BusinessLogic.FileHandling.DTOs;
using ResidentEvil.BusinessLogic.GameLogic;
using ResidentEvil.BusinessLogic.Validating;
using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace ResidentEvil.BusinessLogic.FileHandling
{
    internal class FileReader : IFileReader
    {
        private readonly string _fileName;
        private readonly IFactory _factory;

        public FileReader(string fileName, IFactory factory)
        {
            _fileName = fileName;
            _factory = factory;
        }

        public Stage DeserializeStage()
        {
            var text = File.ReadAllText(_fileName);
            var all = JsonConvert.DeserializeObject<AllJson>(text);

            var validator = new JsonValidator();
            validator.ValidateAll(all);

            var stage = CreateStage(all.Stage);
            SetUpStage(stage, all.Player, all.Enemies);

            return stage;
        }

        private Stage CreateStage(StageJson stageJson)
        {
            return new Stage(stageJson.EnemyCount, stageJson.HasBorders)
            {
                Height = stageJson.Height,
                Width = stageJson.Width
            };
        }

        private void SetUpStage(Stage stage, PlayerJson player, IEnumerable<EnemyJson> enemies)
        {
            SetUpPlayer(stage, player);
            SetUpEnemeis(stage, enemies);
        }

        private void SetUpPlayer(Stage stage, PlayerJson player)
        {
            var position = _factory.CreatePosition(player.Position.X, player.Position.Y);
            stage.Player = _factory.CreatePlayer(player.Name,
                                                 player.Health,
                                                 player.Damage,
                                                 position);
        }

        private void SetUpEnemeis(Stage stage, IEnumerable<EnemyJson> enemies)
        {
            foreach (var enemy in enemies)
            {
                var enemyModel = CreateEnemy(enemy);

                stage.AddEnemy(enemyModel);
            }
        }

        private IEnemy CreateEnemy(EnemyJson enemy)
        {
            var position = _factory.CreatePosition(enemy.Position.X, enemy.Position.Y);

            return enemy.Type.ToLower() switch
            {
                "biozombie" =>
                    _factory.CreateBioZombie(enemy.Health, enemy.Radiation.Value, position),
                "runningzombie" =>
                    _factory.CreateRunningZombie(enemy.Health, enemy.Stamina.Value, position),
                "tyrant" =>
                    _factory.CreateTyrant(enemy.Health, enemy.Damage.Value, position),
                "nemesis" =>
                    _factory.CreateNemesis(enemy.Health, enemy.Damage.Value, position),

                _ => throw new NotImplementedException($"This type of enemy ({enemy.Type}) has not yet been implemented!")
            };
        }
    }
}
