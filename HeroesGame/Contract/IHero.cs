using HeroesGame.Implementation.Monster;
using HeroesGame.Implementation.Weapon;

namespace HeroesGame.Contract
{
    public interface IHero
    {
        IWeapon Weapon { get; }

        int Level { get; }

        int Armor { get; }

        double Experience { get; }

        double Health { get; }

        double MaxHealth { get; }

        double TakeHit(double damage);

        double Hit(IMonster monster);

        void GainExperience(double xp);
        void Heal();

        bool IsDead();
    }
}
