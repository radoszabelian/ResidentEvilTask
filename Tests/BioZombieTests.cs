using NUnit.Framework;
using ResidentEvil.Entities;
using ResidentEvil.Interfaces;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ArgumentsAreSetWithCorrectValues()
        {
            //Arrange
            IPosition pos = new Position(0, 0);
            int health = 100;
            float radiation = 1;

            //Act
            BioZombie zombie = new BioZombie(pos, health, radiation);


            //Assert
            Assert.AreEqual(pos.X, zombie.Position.X);
            Assert.AreEqual(pos.Y, zombie.Position.Y);
            Assert.AreEqual(health, zombie.Health);
            Assert.AreEqual(radiation, zombie.Radiation);
        }

        [Test]
        public void RadiationIsDefaultValueWhenGivenInvalidValue()
        {
            //Arrange
            float radiation = 55;

            //Act
            BioZombie zombie = new BioZombie(null, 0, radiation);

            //Assert
            Assert.AreEqual(default(int), zombie.Radiation);
        }

        [Test]
        public void DamageIsCalculatedCorrectly()
        {
            //Arrange
            float radiation = 0.5f;
            float expectedDamage = radiation * 10;

            //Act
            BioZombie zombie = new BioZombie(null, 100, radiation);

            //Assert
            Assert.AreEqual(expectedDamage, zombie.Damage);
        }
    }
}