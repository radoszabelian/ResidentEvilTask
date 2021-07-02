using NUnit.Framework;
using ResidentEvil.Entities;
using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class EnemyTests
    {
        private class EnemyImplementation : Enemy
        {
            public EnemyImplementation(IPosition pos, int health) : base(pos, health)
            {
            }

            public override int Damage => 100;

            public override char DisplayChar => 'x';
        }

        [Test]
        public void ObjectCreatedWithGivenArguments()
        {
            //Arrange
            Position pos = new Position(0, 0);
            int health = 100;

            //Act
            var Sut = new EnemyImplementation(pos, health);

            //Assert
            Assert.AreEqual(Sut.Position, pos);
            Assert.AreEqual(Sut.Health, health);
        }

        [Test]
        public void DamageIsRemovedWhenPlayerAlive()
        {
            //Arrange
            const int PLAYER_DAMAGE = 88;
            const int ENEMY_HEALTH = 100;
            const int ENEMY_REMAINING_LIFE = ENEMY_HEALTH - PLAYER_DAMAGE;

            var Sut = new EnemyImplementation(null, ENEMY_HEALTH);
            var player = new Player("", 100, PLAYER_DAMAGE, null);

            //Act
            Sut.TakeDamage(player);

            //Assert
            Assert.AreEqual(ENEMY_REMAINING_LIFE, Sut.Health);
        }

        [Test]
        public void DamageNotFallsBelowZeroOnDeath()
        {
            const int PLAYER_DAMAGE = 120;
            const int ENEMY_HEALTH = 100;
            const int ENEMY_REMAINING_LIFE = 0;

            var Sut = new EnemyImplementation(null, ENEMY_HEALTH);
            var player = new Player("", 100, PLAYER_DAMAGE, null);

            //Act
            Sut.TakeDamage(player);

            //Assert
            Assert.AreEqual(ENEMY_REMAINING_LIFE, Sut.Health);
        }

        [Test]
        public void DeathEventIsCalledOnDeath()
        {
            //Arrange
            //Act
            //Assert
        }

        [Test]
        public void ToStringMethodIsFormedCorrectly()
        {
            int health = 100;
            var Sut = new EnemyImplementation(null, health);
            var expectedResult = $"Tests.EnemyTests+EnemyImplementation - health: ({health}), damage: (100)";

            //Act
            var result = Sut.ToString();

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
