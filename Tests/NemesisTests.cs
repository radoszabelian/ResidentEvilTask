using NUnit.Framework;
using ResidentEvil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class NemesisTests
    {
        [Test]
        public void NemesisDoesRegenerateOnAttack()
        {
            const int NEMESIS_BASE_HEALTH = 50;

            var nemesis = new Nemesis(null, NEMESIS_BASE_HEALTH, 1);
            var player = new Player("", 100, 100, null);

            nemesis.Attack(player);

            Assert.AreEqual(NEMESIS_BASE_HEALTH + 1, nemesis.Health);
        }
    }
}
