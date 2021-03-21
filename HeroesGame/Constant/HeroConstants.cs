namespace HeroesGame.Constant
{
    public static class HeroConstants
    {
        // Initial values
        public const int InitialLevel = 1;
        public const int InitialExperience = 0;
        public const int InitialMaxHealth = 100;
        public const int InitialArmor = 0;

        // Maximum values
        public const int MaximumExperience = 100;

        //Per level
        public const int HealPerLevel = 4;

        //Warrior - per level
        public const int WarriorArmorPerLevel = 8;
        public const int WarriorMaxHealthPerLevel = 40;

        //Hunter - per level
        public const int HunterArmorPerLevel = 4;
        public const int HunterMaxHealthPerLevel = 20;

        //Mage - per level
        public const int MageArmorPerLevel = 2;
        public const int MageMaxHealthPerLevel = 10;
    }
}
