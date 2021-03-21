using HeroesGame.Constant;
using HeroesGame.Contract;

namespace HeroesGame.Implementation.Monster
{
    public abstract class BaseMonster : IMonster
    {
        protected BaseMonster(int level)
        {
            this.Level = level;
            this.Health = MonsterConstants.MaxHealthPerLevel * this.Level;
        }

        public int Level { get; set; }

        public double Health { get; set; }

        public abstract double Damage();

        public abstract double Experience();

        public abstract int Armor();


        /// <summary>
        /// Hits a hero lowering its health.
        /// </summary>
        /// <param name="hero">The hero that takes the hit.</param>
        /// <returns>The amount of damage done to the hero.</returns>
        public double Hit(IHero hero)
        {
            return hero.TakeHit(this.Damage());
        }

        /// <summary>
        /// Lowers a monster's health by the amount of damage a weapon has, also adding the armor penetration bonus and monster's armor into the equation.
        /// </summary>
        /// <param name="weapon">The weapon hitting the monster.</param>
        /// <returns>The amount of damage taken.</returns>
        public double TakeHit(IWeapon weapon)
        {
            int finalDamage = weapon.Damage + weapon.ArmorPenetration() - this.Armor();
            this.Health -= finalDamage;

            return finalDamage;
        }

        /// <summary>
        /// Checks whether monster is dead.
        /// </summary>
        /// <returns>True if the monster is dead and false if the monster is still alive.</returns>
        public bool IsDead()
        {
            return this.Health <= 0;
        }
    }
}
