using HeroesGame.Constant;

namespace HeroesGame.Implementation.Weapon
{
    public class Bow : BaseWeapon
    {
        public override int ArmorPenetration()
        {
            return this.Level * WeaponConstants.BowArmorPenCoefficient;
        }
    }
}
