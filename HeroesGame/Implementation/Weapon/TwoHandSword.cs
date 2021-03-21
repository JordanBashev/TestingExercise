using HeroesGame.Constant;

namespace HeroesGame.Implementation.Weapon
{
    public class TwoHandSword : BaseWeapon
    {
        public override int ArmorPenetration()
        {
            return this.Level * WeaponConstants.TwoHandSwordArmorPenCoefficient;
        }
    }
}
