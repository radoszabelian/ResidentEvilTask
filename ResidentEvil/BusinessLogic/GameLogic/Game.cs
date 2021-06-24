using ResidentEvil.BusinessLogic.GameLogic.Attack;
using ResidentEvil.BusinessLogic.GameLogic.Movement;
using ResidentEvil.BusinessLogic.Help;
using ResidentEvil.BusinessLogic.Mapping;
using ResidentEvil.Interfaces;
using ResidentEvil.Models.Enums;
using System.Linq;

namespace ResidentEvil.BusinessLogic.GameLogic
{
	internal class Game
	{
		private readonly MovementHandler _moveHandler;
		private readonly AttackHandler _attackHandler;

		private readonly Stage _stage;

		public IPlayer Player => _stage.Player;
		public IEnemy[] Enemies => _stage.Enemies;

		public int StageHeight => _stage.Height;
		public int StageWidth => _stage.Width;

		public Game(Stage stage)
		{
			_stage = stage;
			_moveHandler = new MovementHandler(stage);
			_attackHandler = new AttackHandler();
		}

		public void Play(Instruction instruction)
		{
			Move(instruction);
			Attack();
		}

		private bool Move(Instruction instruction)
		{
			if (instruction == Instruction.Quit)
			{
				return true;
			}

			var moveDirection = EnumMapper.MapInstructionToDirection(instruction);
			_moveHandler.MovePlayer(Player, moveDirection);
			_moveHandler.MoveEnemies(Enemies, Player.Position);

			return false;
		}

		private void Attack()
		{
			_attackHandler.Attack(Player, Enemies);
		}

		public bool IsOver() => IsWin() || !Helper.IsAlive(Player);

		public bool IsWin() => !Enemies.Any(Helper.IsAlive);
	}
}
