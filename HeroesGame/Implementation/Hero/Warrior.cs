using HeroesGame.Constant;
using HeroesGame.Implementation.Weapon;

namespace HeroesGame.Implementation.Hero
{
    public class Warrior : BaseHero
    {
        public Warrior() : base(new TwoHandSword())
        {
        }

        protected override void LevelUp()
        {
            this.Level++;

            this.Armor += HeroConstants.WarriorArmorPerLevel;
            this.MaxHealth += HeroConstants.WarriorMaxHealthPerLevel;
            this.Health = this.MaxHealth;

            this.Weapon.LevelUp();
        }
    }
}
