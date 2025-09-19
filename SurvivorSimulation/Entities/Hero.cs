using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivorSimulation.Entities
{
    public class Hero : Character
    {
        public Hero(int hp, int attackPower) : base("Kahraman", hp, attackPower)
        {
        }
    }
}
