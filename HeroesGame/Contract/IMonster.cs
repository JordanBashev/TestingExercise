namespace HeroesGame.Contract
{
    public interface IMonster
    {
        int Level { get; set; }

        double Health { get; set; }

        double Damage();

        double Experience();

        int Armor();

        double Hit(IHero hero);

        double TakeHit(IWeapon weapon);

        bool IsDead();
    }
}
