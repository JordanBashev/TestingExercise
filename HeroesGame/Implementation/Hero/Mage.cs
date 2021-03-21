using HeroesGame.Constant;
using HeroesGame.Implementation.Weapon;

namespace HeroesGame.Implementation.Hero
{
    public class Mage : BaseHero
    {
        public Mage() : base(new Staff())
        {
        }

        protected override void LevelUp()
        {
            this.Level++;

            this.Armor += HeroConstants.MageArmorPerLevel;
            this.MaxHealth += HeroConstants.MageMaxHealthPerLevel;
            this.Health = this.MaxHealth;

            this.Weapon.LevelUp();
        }
    }
}
