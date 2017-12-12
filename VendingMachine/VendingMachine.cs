using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine
    {
        List<Goods> items = new List<Goods>();
        List<Goods> inventory = new List<Goods>();

        int money;
        int[] acceptableMoney = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        public VendingMachine()
        {
            AddItems();
            Menu();
        }

        private void Menu()
        {
            bool loop = true;
            while (loop == true)
            {
                Console.WriteLine("Welcome to the Vending Machine.");
                Console.WriteLine("You have " + this.money + " money");
                Console.WriteLine("Please Type 1-3 to do something: ");
                Console.WriteLine("1. Insert money." + Environment.NewLine +
                                  "2. Buy product." + Environment.NewLine +
                                  "3. Consume product." + Environment.NewLine +
                                  "4. Leave Vending Machine");

                string choise = Console.ReadLine();
                if (choise == "1")
                {
                    InsertMoney();
                }
                else if (choise == "2")
                {
                    DisplayProducts();
                }
                else if (choise == "3")
                {
                    if (inventory.Count > 0)
                    { 
                        ConsumeProduct();
                    }
                    else
                    {
                        Console.WriteLine("There's nothing in your inventory");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else if (choise == "4")
                {
                    Console.Clear();
                    if (money > 0)
                    {
                        Console.WriteLine("Before you leave, the vending machine returns " + this.money + " money");
                        Console.ReadKey();
                    }
                    return;
                }
                else { }
            }
        }

        private void ConsumeProduct()
        {
            Console.Clear();
            var i = 0;
            foreach(Goods g in inventory)
            {
                i++;
                Console.WriteLine(i + ". " + g.Name);
            }
            Console.WriteLine(Environment.NewLine + "Please enter a number to decide which product to consume");
            var choise = 0;
            while (choise == 0)
            {
                //Stop the user from inputing something silly
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error, incorect input, please try again");
                    choise = 0;
                }

                //Make sure item exist
                try
                {
                    inventory[choise - 1].UseItem();
                    inventory.Remove(inventory[choise-1]);
                }
                catch
                {
                    Console.WriteLine("This product does not exist, try again");
                    choise = 0;
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void DisplayProducts()
        {
            Console.Clear();
            var i = 0;
            foreach (Goods g in items)
            {
                i++;
                Console.WriteLine(i + ". " +g.Name + " " + g.Cost);
            }
            Console.WriteLine(Environment.NewLine + "Please provide the product number to inspect and buy product:");
            int choise = 0;
            while (choise == 0) {
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("An error occured, please try reentering a number");
                    choise = 0;
                }
                try
                {
                    items[choise-1].ExaminItem();
                    Console.WriteLine("Would you like to buy this item? Type Y/Yes");
                    string yes = Console.ReadLine();
                    if (yes == "Y" || yes == "y" || yes == "Yes" || yes == "yes")
                    {
                        BuyProduct(choise);
                        Console.Clear();
                    }

                }
                catch
                {
                    Console.WriteLine("That item does not exist, please try again");
                    choise = 0;
                }
            }
        }

        private void InsertMoney()
        {
            Console.Clear();
            Console.WriteLine("Please enter a sum of money, is have to be one of the following: " +
                "1, 5, 10, 20, 50, 100, 500, or 1000");


            var money = 0;
            //A loop that tells the user to enter a number
            while (money == 0)
            {
                //If user tries to break the program, set a stop to it here
                try
                {
                    money = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("An error occured, please try again");
                    money = 0;
                }

                if (acceptableMoney.Contains(money))
                {
                    //All good, the user entered an acceptable number
                }
                else
                {
                    Console.WriteLine("You entered an unacceptable number, please try again");
                    money = 0;
                }
            }
            this.money += money;
            Console.Clear();
        }

        private void BuyProduct(int choise)
        {
            if (items[choise-1].Cost <= this.money)
            {
                Console.WriteLine("You bought " + items[choise - 1].Name + "!");
                this.money -= items[choise - 1].Cost;
                var item = items[choise - 1];
                inventory.Add(item);
            }
            else
            {
                Console.WriteLine("You don't have enough money...");
            }
            Console.ReadKey();
        }

        private void AddItems()
        {
            items.Add(new Snack(5, "Chips snack"));
            items.Add(new Snack(3, "M&M snack"));
            items.Add(new Snack(4, "Skittles snack"));
            items.Add(new Snack(6, "Snicker snack"));
            items.Add(new Snack(5, "Twix snack"));
            items.Add(new Drink(7, "Water drink"));
            items.Add(new Drink(8, "Cola drink"));
            items.Add(new Drink(9, "Fanta drink"));
            items.Add(new Drink(11, "Sprite drink"));
            items.Add(new Drink(15, "Monster drink"));
            items.Add(new Sandwich(20, "Egg sandwich"));
            items.Add(new Sandwich(18, "Cheese sandwich"));
            items.Add(new Sandwich(35, "Chicken sandwich"));
            items.Add(new Sandwich(30, "Meatball sandwich"));
            items.Add(new Sandwich(40, "Ham sandwich"));
        }
    }
}
