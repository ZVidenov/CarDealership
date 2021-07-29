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
        private RegisterLogin registerLogin;
        private bool isRunning;

        public Display(DealershipBusiness dealershipBusiness, RegisterLogin registerLogin)
        {
            this.dealershipBusiness = dealershipBusiness;
            this.registerLogin = registerLogin;
            this.isRunning = true;
        }

        public void LogInMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "Welcome! Please log in...");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit from the program");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Register();
                    break;
                case 2:
                    LogIn();
                    break;
                default:
                    this.isRunning = false;
                    break;
            }

            Console.ReadKey();
            Console.Clear();
            ShowMenu();
        }
        public void ShowMenu()
        {
            //var model = this.dealershipBusiness.GetModelByName("NowManyTest");
            //var car = this.dealershipBusiness.GetCarByName("NowManyTest");
            //var brand = this.dealershipBusiness.GetBrandByName("BMW");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("1. Find Car");
            Console.WriteLine("2. Add Car");
            Console.WriteLine("3. List Car Features");
            Console.WriteLine("4. Find Brand");
            Console.WriteLine("5. Exit");

        }
        public void Run()
        {
            while (isRunning)
            {
                LogInMenu();

                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        this.CarByName();
                        Console.ReadKey();
                        break;
                    case 2:
                        this.CreateCar();
                        break;
                    case 3:
                        this.ListFeatures();
                        Console.ReadKey();
                        break;
                    case 4:
                        this.ListBrandModels();
                        Console.ReadKey();
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
            Console.WriteLine("Car model:");
            string modelName = Console.ReadLine();
            Console.WriteLine("Car brand:");
            string brandName = Console.ReadLine();
            
            Brand brand = this.dealershipBusiness.GetBrandByName(brandName);
            while (brand == null)
            {
                Console.WriteLine("No such brand. Please re-enter the name of the brand:");
                brandName = Console.ReadLine();
                brand = this.dealershipBusiness.GetBrandByName(brandName);
            }

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
            this.dealershipBusiness.AddModelToBrand(model.Name, brand);
            
            model = this.dealershipBusiness.GetModelByName(modelName);
            Car car = new Car(name, price, type, stock);
            car.ModelId = model.Id;
            this.dealershipBusiness.CreateCar(car);
            car = this.dealershipBusiness.GetCarByName(car.Name);
            this.dealershipBusiness.CreateCarFeatures(carFeatures, car);
        }
        private void CarByName()
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
        private void ListBrandModels()
        {
            Console.WriteLine("Brand name:");
            string name = Console.ReadLine();
            Brand brand = this.dealershipBusiness.GetBrandByName(name);
            Console.WriteLine("Models we offer");
            foreach (Model model in brand.Models)
            {
                Console.WriteLine(model.Name);
            }
        }

        private void Register()
        {
            Console.WriteLine("Your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Your password");
            string password = Console.ReadLine();
            registerLogin.Register(name, password);
        }
        private void LogIn()
        {
            Console.WriteLine("Your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Your password");
            string password = Console.ReadLine();
            registerLogin.LogIn(name, password);
        }
    }
}
