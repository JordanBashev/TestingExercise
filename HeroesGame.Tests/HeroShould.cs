using HeroesGame.Constant;
using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesGame.Tests
{
    public class HeroShould
    {
        
        private Mock<Mage> _hero;

        [SetUp]
        public void Setup()
        {
            this._hero = new Mock<Mage>();
            this._hero.Protected()
                .Setup("LevelUp")
                .CallBase();
        }


        [Test]
        public void HeroCorrectInitialValues()
        {

            //Assert
            Assert.That(_hero.Object.Level, Is.EqualTo(HeroConstants.InitialLevel));
            Assert.That(_hero.Object.Armor, Is.EqualTo(HeroConstants.InitialArmor));
            Assert.That(_hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(_hero.Object.MaxHealth, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(_hero.Object.Experience, Is.EqualTo(HeroConstants.InitialExperience));
            Assert.That(_hero.Object.Weapon, Is.Not.Null);
        }

        [Test]
        public void TakeHitCorrectly()
        {
            //Act
            int damage = 50;
            _hero.Object.TakeHit(damage);

            //Assert
            Assert.That(_hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        [Test]
        public void ThrowsArgumentExecptionForNegativeTakeHitValuer()
        {
            //Act
            int damage = -50;

            //Assert
            Assert.Throws<ArgumentException>(() => _hero.Object.TakeHit(damage), "You are going to brazil");
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void TakeHitCorrectly_TestCase(int damage)
        {
            //Act
            _hero.Object.TakeHit(damage);

            //Assert
            Assert.That(_hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(-20)]
        [TestCase(-30)]
        public void ThrowsArgumentExecptionForNegativeTakeHitValuer_TestCase(int damage)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => _hero.Object.TakeHit(damage), "You are going to brazil");
        }

        [Test]
        public void GainsExperianceCorrectly([Range(25,500,25)] double xp)
        {
            //Act
            _hero.Object.GainExperience(xp);

            //Assert
            if(xp >= HeroConstants.MaximumExperience)
            {
                var expectedXp = (HeroConstants.MaximumExperience + xp) % HeroConstants.MaximumExperience;
                Assert.That(_hero.Object.Experience, Is.EqualTo(expectedXp));
                Assert.That(_hero.Object.Level, Is.EqualTo(HeroConstants.InitialLevel + 1));
            }
            else
            {
                Assert.That(_hero.Object.Experience, Is.EqualTo(HeroConstants.InitialExperience + xp));
            }
        }

        private void LevelUp(int levels)
        {
            for(int i = 0; i < levels; i++)
            {
                _hero.Object.GainExperience(HeroConstants.MaximumExperience);
            }
        }

        [Test]
        public void HeroHealsCorrectly([Range(5,25,1)]int level, [Range(25,500,25)]int damage)
        {
            //Act
            //LevelUp
            this.LevelUp(level);
            //Take Damage
            double TotalDamage = HeroConstants.InitialMaxHealth + damage;
            TotalDamage = _hero.Object.TakeHit(damage);
            _hero.Object.Heal();

            //Assert
            var HealValue = _hero.Object.Level * HeroConstants.HealPerLevel;
            var ExpectedHealth = (_hero.Object.MaxHealth - TotalDamage) + HealValue;

            if (ExpectedHealth > _hero.Object.MaxHealth)
                ExpectedHealth = _hero.Object.MaxHealth;

            Assert.That(_hero.Object.Health, Is.EqualTo(ExpectedHealth));
        }

        [Test]
        public void NotBeBornDead()
        {
            //Act
            _hero.Object.IsDead();

            //Assert
            Assert.That(_hero.Object.IsDead, Is.Not.True);
        }

        [Test]
        public void BeDeadWhenCriticallyHit([Range(50,150,25)]double damage)
        {
            //Act
            var damageTaken = _hero.Object.TakeHit(damage);


            //Assert
            if(damageTaken >= _hero.Object.MaxHealth)
            {
                Assert.That(_hero.Object.IsDead);
            }
            else
            {
                Assert.That(_hero.Object.IsDead, Is.False);
            }
        }
    }
}
