using SurvivorSimulation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivorSimulation.Services
{
    public class BattleService
    {

        public bool SimulateBattle(Hero hero, Enemy enemy)
        {
            Console.WriteLine($"Kahraman {enemy.Position} metrede {enemy.Name} ile karşılaştı.");

            while (hero.IsAlive() && enemy.IsAlive())
            {
                int heroAttack = hero.AttackPower;
                int enemyAttack = enemy.AttackPower;

                hero.TakeDamage(enemyAttack);
                enemy.TakeDamage(heroAttack);             
            }
            if (hero.IsAlive())
            {

                //Kahraman Düşmanı Yendi 
                Console.WriteLine($"Kahraman {enemy.Name}'i {hero.HP} HP ile yendi.");
                return true; // Kahraman hayatta kaldı.
            }
            else
            {
                //Kahraman Yenildi
                Console.WriteLine($"Kahraman {enemy.Name} tarafından yenildi.");
                return false;
            }
        }
    }
}
