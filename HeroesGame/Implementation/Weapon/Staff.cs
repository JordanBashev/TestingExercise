using HeroesGame.Constant;

namespace HeroesGame.Implementation.Weapon
{
    public class Staff : BaseWeapon
    {
        public override int ArmorPenetration()
        {
            return this.Level * WeaponConstants.StaffArmorPenCoefficient;
        }
    }
}
