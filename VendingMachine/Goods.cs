using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Goods
    {
        protected int cost;
        protected string name;

        //Constructor
        public Goods(int cost, string name)
        {
            this.cost = cost;
            this.name = name;
        }

        //Properties
        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        //When an item is bought, check if the user can afford it
        public void BuyItem(int money)
        {
            if (money >= cost)
            {
                Console.WriteLine("You bought " + name);
            }
        }

        //These are the abstract methods we will use in all items
        public abstract void ExaminItem();
        public abstract void UseItem();

    }
}
