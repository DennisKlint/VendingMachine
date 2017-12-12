using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Snack : Goods
    {
        public Snack(int cost, string name) : base(cost, name)
        {

        }

        public override void ExaminItem()
        {
            Console.WriteLine("This is a " + name + ".");
            Console.WriteLine("Snacks are cheap, but rarely healthy.");
            
        }

        public override void UseItem()
        {
            Console.WriteLine("You eat your " + name + ", tastes great!");
        }
    }
}
