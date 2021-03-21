using System.Collections.Generic;
using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
using HeroesGame.Implementation.Monster;

namespace HeroesGame
{
    public class CombatProcessor : ICombatProcessor
    {
        private int Fights { get; set; }
        private int HealsUsed { get; set; }

        public CombatProcessor(BaseHero hero)
        {
            this.Logger = new List<string>();
            this.Hero = hero;
            this.Fights = 0;
        }

        public BaseHero Hero { get; }

        public List<string> Logger { get; set; }

        /// <summary>
        /// The fighting process itself. Starts with the hero taking the first hit.
        /// </summary>
        /// <param name="monster">The monster that our player fights against.</param>
        public void Fight(IMonster monster)
        {
            this.Fights++;

            double damageDone = this.Hero.Hit(monster);
            this.Logger.Add($"The {this.Hero.GetType().Name} hits the {monster.GetType().Name} dealing {damageDone} damage to it.");

            if (monster.IsDead())
            {
                this.Hero.GainExperience(monster.Experience());
                this.Logger.Add($"The monster dies. ({monster.Experience()} XP gained.)");
                return;
            }

            double monsterDamageDone = monster.Hit(this.Hero);
            this.Logger.Add($"The {monster.GetType().Name} hits the {this.Hero.GetType().Name} dealing {monsterDamageDone} damage to it.");

            if (this.Hero.IsDead())
            {
                this.Hero.Heal();
                this.HealsUsed++;

                if (this.HealsUsed > 3)
                {
                    this.Logger.Add($"The hero dies on level {this.Hero.Level} after {this.Fights} fights.");
                    return;
                }

                this.Logger.Add($"The hero has taken fatal damage. Luckily he has managed to heal just before he dies.");
            }

            this.Fight(monster);
        }
    }
}
