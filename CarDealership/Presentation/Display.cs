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
        private Sales sales;
        private bool isRunning;

        public Display(DealershipBusiness dealershipBusiness, RegisterLogin registerLogin, Sales sales)
        {
            this.dealershipBusiness = dealershipBusiness;
            this.registerLogin = registerLogin;
            this.sales = sales;
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
            
        }
        public void ShowAdminMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "ADMIN MENU");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("1. Check stock of a specific car");
            Console.WriteLine("2. Add Car");
            Console.WriteLine("3. List Car Features");
            Console.WriteLine("4. List Brand Models");
            Console.WriteLine("5. Exit");

        }

        public void ShowSalesmanMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "EMPLOYEE MENU");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("1. Check stock of a specific car");
            Console.WriteLine("2. List Car Features");
            Console.WriteLine("3. List Brand Models");
            Console.WriteLine("4. List Model Cars");
            Console.WriteLine("5. Sell Car");
            Console.WriteLine("6. Exit");

        }
        public void Run()
        {
            Salesman salesman = null;
            while (isRunning)
            {
                while (salesman == null)
                {
                    LogInMenu();
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            salesman = LogIn();
                            break;
                        case 2:
                            Register();
                            break;
                        default:
                            this.isRunning = false;
                            return;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                if (salesman.Name == "Admin")
                {
                    ShowAdminMenu();

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
                else
                {
                    ShowSalesmanMenu();

                    int command = int.Parse(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            this.CarByName();
                            Console.ReadKey();
                            break;
                        case 2:
                            this.ListFeatures();
                            break;
                        case 3:
                            this.ListBrandModels();
                            Console.ReadKey();
                            break;
                        case 4:
                            this.ListModelCars();
                            Console.ReadKey();
                            break;
                        case 5:
                            this.SellCar(salesman.Name);
                            Console.ReadKey();
                            break;
                        default:
                            this.isRunning = false;
                            break;
                    }

                    Console.Clear();

                }
            }
        }
        private void SellCar(string salesmanName)
        {
            Console.WriteLine("Car name:");
            string carName = Console.ReadLine();
            Console.WriteLine("Sold amount");
            int amount = int.Parse(Console.ReadLine());
            Car car = this.dealershipBusiness.GetCarByName(carName);
            this.sales.Sale(salesmanName,carName,amount);
            Console.WriteLine("Sale complete.");
        }
        private void CreateCar()
        {
            Console.WriteLine("Car name:");
            string name = Console.ReadLine();
            Console.WriteLine("Car price:");
            decimal price = int.Parse(Console.ReadLine());
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

            Console.WriteLine("Car Features (write 'done' when ready):");
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
            Console.WriteLine($"Currently in stock: {car.Stock} .");
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
        private void ListModelCars()
        {
            Console.WriteLine("Model name:");
            string name = Console.ReadLine();
            Model model = this.dealershipBusiness.GetModelByName(name);
            Console.WriteLine("Cars we offer:");
            foreach (Car car in model.Cars)
            {
                Console.WriteLine(car.Name);
            }
        }

        private void Register()
        {
            Console.WriteLine("Your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Your password");
            string password = Console.ReadLine();
            if(registerLogin.Register(name, password))
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("User already exists");
            }
        }
        private Salesman LogIn()
        {
            Console.WriteLine("Your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Your password");
            string password = Console.ReadLine();
            Salesman salesman = null;
            if(registerLogin.LogIn(name, password))
            {
                salesman = this.dealershipBusiness.GetSalesmanByName(name);
                Console.WriteLine($"Login successful! Welcome, {salesman.Name}.");
                return salesman;
            }
            else
            {
                Console.WriteLine("Wrong username or password.");
                return salesman;
            }
        }
    }
}
