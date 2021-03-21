using HeroesGame.Constant;
using HeroesGame.Contract;

namespace HeroesGame.Implementation.Weapon
{
    public abstract class BaseWeapon : IWeapon
    {
        protected BaseWeapon()
        {
            this.Damage = WeaponConstants.InitialDamage;
            this.Level = WeaponConstants.InitialLevel;
        }

        /// <summary>
        /// Calculates and returns armor penetration value for each kind of weapon.
        /// </summary>
        /// <returns>An integer equal to the amount of armor penetration for given weapon.</returns>
        public abstract int ArmorPenetration();

        public int Damage { get; set; }

        public int Level { get; set; }

        /// <summary>
        /// On level up damage gets increased.
        /// </summary>
        public void LevelUp()
        {
            this.Level++;
            this.Damage += WeaponConstants.DamagePerLevel;
        }
    }
}
