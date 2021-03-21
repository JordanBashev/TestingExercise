using System.Collections.Generic;
using HeroesGame.Implementation.Hero;
using HeroesGame.Implementation.Monster;

namespace HeroesGame.Contract
{
    interface ICombatProcessor
    {
        BaseHero Hero { get; }

        List<string> Logger { get; set; }

        void Fight(IMonster monster);
    }
}
