using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Sandwich : Goods
    {
        public Sandwich(int cost, string name) : base(cost, name)
        {

        }

        public override void ExaminItem()
        {
            Console.WriteLine("This is a " + name + ".");
            Console.WriteLine("Sandwiches are more expensive, but they are also healthier than other products");
        }

        public override void UseItem()
        {
            Console.WriteLine("You eat your " + name + ", delicious!");
        }
    }
}
