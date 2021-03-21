using HeroesGame.Constant;

namespace HeroesGame.Implementation.Monster
{
    public class MedusaTheGorgon : BaseMonster
    {
        public MedusaTheGorgon(int level) : base(level)
        {
        }

        public override double Damage()
        {
            return this.Level * MonsterConstants.MedusaDamagePerLevel;
        }

        public override double Experience()
        {
            return this.Level * MonsterConstants.MedusaXpPerLevel;
        }

        public override int Armor()
        {
            return this.Level * MonsterConstants.MedusaArmorPerLevel;
        }
    }
}
