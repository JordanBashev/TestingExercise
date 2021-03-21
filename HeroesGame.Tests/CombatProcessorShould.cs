using System;
using System.Collections.Generic;
using System.Text;
using HeroesGame.Constant;
using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
using HeroesGame.Implementation.Monster;
using NUnit.Framework;

namespace HeroesGame.Tests
{
    public class CombatProcessorShould
    {
        private CombatProcessor _Cp;

        [SetUp]
        public void Setup()
        {
            _Cp = new CombatProcessor(new Hunter());
        }

        private void LevelUpHero(int levels)
        {
            for(int i = 0; i < levels; i++)
            {
                _Cp.Hero.GainExperience(HeroConstants.MaximumExperience);
            }
        }

        [Test]
        public void InitializeCorrectly()
        {
            //Assert
            Assert.That(_Cp.Hero, Is.Not.Null);
            Assert.That(_Cp.Logger, Is.Empty);
            Assert.That(_Cp.Logger, Is.Not.Null);
        }

        [Test]
        public void FightCorrectly_WeakerEnemy()
        {
            //Arrange
            IMonster monster = new MedusaTheGorgon(1);
            LevelUpHero(50);

            //Act
            _Cp.Fight(monster);
            var logger = _Cp.Logger;

            //Assert
            Assert.That(logger.Count, Is.EqualTo(2));
            Assert.That(logger, Does.Contain("The Hunter hits the MedusaTheGorgon dealing 510 damage to it.").And.Contains("The monster dies. (4 XP gained.)"));

        }

        [Test]
        public void FightCorrectlyAndRepeatedly_StrongEnemy()
        {
            //Arrange
            var monster = new MedusaTheGorgon(50);

            //Act
            _Cp.Fight(monster);
            var logger = _Cp.Logger;

            //Assert
            Assert.That(logger.Count, Is.EqualTo(12));
            Assert.That(logger, Does.Contain("The hero dies on level 1 after 4 fights."));
        }
    }
}
