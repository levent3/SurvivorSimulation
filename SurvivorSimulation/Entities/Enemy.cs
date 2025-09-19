using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivorSimulation.Entities
{
    public class Enemy : Character
    {

        public int Position { get; set; }
        public Enemy(string name, int hp, int attackPower, int position) : base(name, hp, attackPower)
        {
            Position = position;
        }
    }
}
