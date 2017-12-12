using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Drink : Goods
    {
        public Drink(int cost, string name) : base(cost, name)
        {

        }

        public override void ExaminItem()
        {
            Console.WriteLine("This is a " + name +".");
            Console.WriteLine("Drinks are not to expensive, and goes well with either sandwiches or snacks.");
        }

        public override void UseItem()
        {
            Console.WriteLine("You drink your " + name + ", you feel refreshed!");
        }
    }
}
