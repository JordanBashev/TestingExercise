using HeroesGame.Constant;

namespace HeroesGame.Implementation.Monster
{
    public class GiantWorm : BaseMonster
    {
        public GiantWorm(int level) : base(level)
        {
        }

        public override double Damage()
        {
            return this.Level * MonsterConstants.GiantWormDamagePerLevel;
        }

        public override double Experience()
        {
            return this.Level * MonsterConstants.GiantWormXpPerLevel;
        }

        public override int Armor()
        {
            return this.Level * MonsterConstants.GiantWormArmorPerLevel;
        }
    }
}
