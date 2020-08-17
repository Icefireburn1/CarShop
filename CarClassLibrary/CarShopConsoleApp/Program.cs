using CarClassLibrary;
using CarShopGUI;
using System;

namespace CarShopConsoleApp
{
    class Program
    {
        static Store CarStore = new Store();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the car store. First you must create some cars and put them into the store" +
                "inventory. Then you may add cars to the cart. Finally, you may checkout, which will calculate your total bill.");
            int action = chooseAction();
            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        // You chose add a car
                        Console.WriteLine("You chose to add a new car to the store");

                        String carMake = "";
                        String carModel = "";
                        String carColor = "";
                        int carYear = -1;
                        Decimal carPrice = 0;

                        // Input
                        Console.Write("What is the car make? Ford, GM, Toyota etc ");
                        carMake = Console.ReadLine();

                        Console.Write("What is the car model? Corvette, Focus, Ranger ");
                        carModel = Console.ReadLine();

                        Console.Write("What is the color of the car? Blue, Yellow, Red etc ");
                        carColor = Console.ReadLine();

                        // Error catching
                        try
                        {
                            Console.Write("What year was the car made? Only numbers please ");
                            carYear = int.Parse(Console.ReadLine());

                            Console.Write("What is the car price? Only numbers please ");
                            carPrice = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Write("Error: input was invalid. Was it a number? ");
                        }



                        // Create our car
                        Car newCar = new Car();
                        newCar.Make = carMake;
                        newCar.Model = carModel;
                        newCar.Price = carPrice;
                        CarStore.CarList.Add(newCar);
                        printStoreInventory(CarStore);
                        break;

                    case 2:
                        // You chose buy a car
                        printStoreInventory(CarStore);

                        int choice = 0;
                        Console.Write("Which car would you like to add to the car? (number) ");
                        
                        //Input
                        // Error catching
                        try
                        {
                            choice = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Write("Error: input was invalid. Was it a number? ");
                        }
                        
                        if (choice < 0 || choice > CarStore.CarList.Count)
                        {
                            Console.Write("Error: There was no car with that number. ");
                            break;
                        }
                        CarStore.ShoppingList.Add(CarStore.CarList[choice]);

                        printShoppingCart(CarStore);

                        break;

                    case 3:
                        // Checkout
                        printShoppingCart(CarStore);
                        Console.WriteLine("Your total cost is ${0}", CarStore.checkout());

                        break;

                    default:
                        break;
                }
                action = chooseAction();
            }
        }

        public static void printShoppingCart(Store carStore)
        {
            Console.WriteLine("These are the cars in your shopping cart:");
            int i = 0;
            foreach(var c in carStore.ShoppingList)
            {
                Console.WriteLine(String.Format("Car # = {0} {1}", i, c.Display));
                i++;
            }
        }

        public static void printStoreInventory(Store carStore)
        {
            Console.WriteLine("These are the cars in the store inventory:");
            int i = 0;
            foreach(var c in carStore.CarList)
            {
                Console.WriteLine(String.Format("Car # = {0} {1} ", i, c.Display));
            }
        }

        public static int chooseAction()
        {
            int choice = 0;
            Console.Write("Choose an action (0) quit (1) add a car (2) add item to cart (3) checkout ");
            choice = int.Parse( Console.ReadLine() );
            return choice;
        }
    }
}
