using HeroesGame.Constant;
using HeroesGame.Contract;
using HeroesGame.Implementation.Monster;
using System;

namespace HeroesGame.Implementation.Hero
{
    public abstract class BaseHero : IHero
    {
        /// <summary>
        /// On level up the armor and max health are increased correspondently. Hero's weapon level ups as he level ups.
        /// </summary>
        protected abstract void LevelUp();
        protected BaseHero(IWeapon weapon)
        {
            this.Level = HeroConstants.InitialLevel;
            this.Experience = HeroConstants.InitialExperience;
            this.MaxHealth = HeroConstants.InitialMaxHealth;
            this.Health = HeroConstants.InitialMaxHealth;
            this.Armor = HeroConstants.InitialArmor;
            this.Weapon = weapon;
        }

        public IWeapon Weapon { get; }

        public int Level { get; protected set; }

        public int Armor { get; protected set; }

        public double Experience { get; protected set; }

        public double Health { get; protected set; }

        public double MaxHealth { get; protected set; }

        /// <summary>
        /// Lowers a hero's Health by the amount of damage a monster does on hit where 1 armor blocks 1 incoming damage. If armor is 0 armorPenetration is added as additional damage.
        /// </summary>
        /// <param name="damage">The amount of damage a monster does on hit.</param>
        /// <returns>The damage taken after armor is taken into consideration.</returns>
        public double TakeHit(double damage)
        {
            if(damage < 0)
            {
                throw new ArgumentException("You are going to brazil");
            }
            else
            {
                double finalDamage = damage - this.Armor;
                this.Health = this.Health - finalDamage;

                return finalDamage;
            }

        }

        /// <summary>
        /// Hits a monster lowering its health taking into consideration armor penetration and monster armor.
        /// </summary>
        /// <param name="monster">The monster taking the hit.</param>
        /// <returns>The amount of damage done to the monster.</returns>
        public double Hit(IMonster monster)
        {
            return monster.TakeHit(this.Weapon);
        }

        /// <summary>
        /// Adds to the hero's experience the amount gained by killing a monster.
        /// </summary>
        /// <param name="xp">The amount of experience gained by killing a monster.</param>
        public void GainExperience(double xp)
        {
            this.Experience += xp;

            if (this.Experience >= HeroConstants.MaximumExperience)
            {
                this.Experience = this.Experience % HeroConstants.MaximumExperience;
                this.LevelUp();
            }
        }

        /// <summary>
        /// Heals for certain amount based on the hero's level.
        /// </summary>
        public void Heal()
        {
            double healValue = this.Health + this.Level * HeroConstants.HealPerLevel;
            this.Health = healValue >= this.MaxHealth ? this.MaxHealth : healValue;
        }

        /// <summary>
        /// Checks whether hero is dead.
        /// </summary>
        /// <returns>True if the hero is dead and false if the hero is still alive.</returns>
        public bool IsDead()
        {
            return this.Health <= 0;
        }
    }
}
