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
            var model = this.dealershipBusiness.GetModelByName("Poredniq");
            var car = this.dealershipBusiness.GetCarByName("TestowiTest");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("1. Find Car");
            Console.WriteLine("2. Add Car");
            Console.WriteLine("3. List Car Features");
            Console.WriteLine("4. Exit");
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
                    case 3:
                        this.ListFeatures();
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
            Console.WriteLine("Car Model:");
            string modelName = Console.ReadLine();
            Console.WriteLine("Car Features (separate with a blank space, write 'done' when ready):");

            List<string> features=EnterFeatures().Distinct().ToList();
            List<Feature> carFeatures = new List<Feature>();
            foreach(string feature in features)
            {
                Feature feature1 = this.dealershipBusiness.GetFeatureByName(feature);
                if (feature1 != null)
                {
                    carFeatures.Add(feature1);
                }
                else
                {
                    feature1 = new Feature(feature);
                    this.dealershipBusiness.CreateFeature(feature1);
                    feature1 = this.dealershipBusiness.GetFeatureByName(feature);
                    carFeatures.Add(feature1);
                }
            }
            
            
            Model model = this.dealershipBusiness.GetModelByName(modelName);
            if (model == null)
            {
                model = new Model(modelName);
                this.dealershipBusiness.CreateModel(model);
            }
            model = this.dealershipBusiness.GetModelByName(modelName);

            Car car = new Car(name, price, type, stock);
            car.ModelId = model.Id;
            this.dealershipBusiness.CreateCar(car);
            car = this.dealershipBusiness.GetCarByName(car.Name);
            this.dealershipBusiness.CreateCarFeatures(carFeatures, car);
        }
        private void GetByName()
        {
            Console.WriteLine("Car name:");
            string name = Console.ReadLine();

            Car car = this.dealershipBusiness.GetCarByName(name);
            Console.WriteLine("Currently in stock:");
            Console.WriteLine(car.Stock);
        }
        private List<string> EnterFeatures()
        {
            
            string command = null;
            List<string> features = new List<string>();
            while (command != "done")
            {
                command = Console.ReadLine();
                if (command != "done")
                {
                    features.Add(command);
                }
            }
            return features;

        }
        private void ListFeatures()
        {
            Console.WriteLine("Car name:");
            string name = Console.ReadLine();
            Car car = this.dealershipBusiness.GetCarByName(name);
            List<Feature> features=this.dealershipBusiness.GetCarFeatures(car);
            foreach(Feature feature in features)
            {
                Console.WriteLine(feature.Name);
            }
        }
    }
}
