using HeroesGame.Constant;
using HeroesGame.Implementation.Weapon;

namespace HeroesGame.Implementation.Hero
{
    public class Hunter : BaseHero
    {
        public Hunter() : base(new Bow())
        {
        }

        protected override void LevelUp()
        {
            this.Level++;

            this.Armor += HeroConstants.HunterArmorPerLevel;
            this.MaxHealth += HeroConstants.HunterMaxHealthPerLevel;
            this.Health = this.MaxHealth;

            this.Weapon.LevelUp();
        }
    }
}
