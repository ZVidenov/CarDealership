using CarDealership.Business;
using CarDealership.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Presentation
{
    public class Display
    {
        private DealershipBusiness dealershipBusiness;
        private bool isRunning;

        public Display(DealershipBusiness dealershipBusiness)
        {
            this.dealershipBusiness = dealershipBusiness;
            this.isRunning = true;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("1. Find Car");
            Console.WriteLine("2. Add Car");
            Console.WriteLine("3. Exit");
        }
        public void Run()
        {
            while (isRunning)
            {
                ShowMenu();

                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        this.GetByName();
                        Console.ReadKey();
                        break;
                    case 2:
                        this.CreateCar();
                        break;
                    default:
                        this.isRunning = false;
                        break;
                }

                Console.Clear();
            }
        }
        private void CreateCar()
        {
            Console.WriteLine("Car name:");
            string name = Console.ReadLine();
            Console.WriteLine("Car price:");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Car type:");
            string type = Console.ReadLine();
            Console.WriteLine("Car stock:");
            int stock = int.Parse(Console.ReadLine());
            //Console.WriteLine("Car Model:");
            //string model = Console.ReadLine();
            //Console.WriteLine("Car Brand:");
            //string brand = Console.ReadLine();
            //Features need a loop
            //Console.WriteLine("Car Features(separate with a blank space, write 'done' when ready  ):");
            //string command = null;
            //List<string> features=null;
            //while (command != "done")
            //{
            //    command = Console.ReadLine();
            //    features.Add(command);
            //}
            
            Car car = new Car(name, price, type, stock);
            this.dealershipBusiness.CreateCar(car);
        }
        private void GetByName()
        {
            Console.WriteLine("Car name:");
            string name = Console.ReadLine();

            Car car = this.dealershipBusiness.GetCarByName(name);
            Console.WriteLine("Currently in stock:");
            Console.WriteLine(car.Stock);
        }

    }
}
