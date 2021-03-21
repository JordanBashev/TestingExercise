namespace HeroesGame.Contract
{
    public interface IWeapon
    {
        int ArmorPenetration();

        int Damage { get; set; }

        int Level { get; set; }

        void LevelUp();
    }
}
