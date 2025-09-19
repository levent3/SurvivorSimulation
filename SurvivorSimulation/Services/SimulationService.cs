using SurvivorSimulation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivorSimulation.Services
{
    public class SimulationService
    {
        private readonly BattleService _battleService;

        public SimulationService(BattleService battleService)
        {
            _battleService = battleService;
        }

        public void StartSimulation(Hero hero,int destination,List<Enemy> enemies)
        {

            Console.WriteLine($"Kahraman yolculuğa {hero.HP} HP ile başladı!");

            var sortedEnemies=enemies.OrderBy(e=>e.Position).ToList();
            int currentPosition = 0;    

            foreach(var enemy in sortedEnemies)
            {
                int distance=enemy.Position - currentPosition;
                int hpLossFromArmor = distance / 50; // Her 50 metrede 1 HP kaybı

                hero.TakeDamage(hpLossFromArmor);
                if (!hero.IsAlive())
                {
                    Console.WriteLine($"Ağır zırhın neden olduğu yavaşlıktan dolayı radyasyon yüzünden  kahraman dayanamadı ve {enemy.Position}. metreye varmadan öldü!");
                    return;
                }

                // Savaş başlar
                bool heroSurvived = _battleService.SimulateBattle(hero, enemy);
                if (!heroSurvived)
                {
                    Console.WriteLine($"Kahraman öldü! En son {enemy.Position}. metrede görüldü!!");
                    return;
                }


                currentPosition = enemy.Position;
            }

            // Son düşmandan hedefe kadar olan mesafe için de HP kaybı
            int finalDistance = destination - currentPosition;
            int finalHpLoss = finalDistance / 50;
            hero.TakeDamage(finalHpLoss);

            if (hero.IsAlive())
            {
                Console.WriteLine("Kahraman hayatta kaldı ve kaynaklara ulaştı!");
            }
            else
            {
                Console.WriteLine("Kahraman kaynaklara ulaşmaya çok yaklaşmıştı ama yorgunluktan dayanamadı!");
            }

        }

    }
}
