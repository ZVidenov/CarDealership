using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Business
{
    public class DealershipBusiness
    {
        private DealershipContext database;

        public List<Salesman> GetAllSalesmen()
        {
            List<Salesman> salesmen = null;

            using (database = new DealershipContext())
            {
                salesmen = this.database.Salesmen.ToList();
            }

            return salesmen;
        }
        public Car GetCarByName(string name)
        {
            Car car = null;

            using (database = new DealershipContext())
            {
                car = this.database.Cars.Include(i=>i.Features).ThenInclude(i=>i.Feature).Include(n => n.Model).FirstOrDefault(t => t.Name == name);

            }

            return car;
        }
        public Salesman GetSalesmanByName(string name)
        {
            Salesman salesman = null;

            using (database = new DealershipContext())
            {
                salesman = this.database.Salesmen.FirstOrDefault(t => t.Name == name);

            }

            return salesman;
        }

        public Model GetModelByName(string name)
        {
            Model model = null;
            
            using (database = new DealershipContext())
            {
                model = this.database.Models.Include(n=>n.Cars).Include(n=>n.Brand).FirstOrDefault(x => x.Name == name);

            }

            return model;
        }
        public Brand GetBrandByName(string name)
        {
            Brand brand = null;

            using (database = new DealershipContext())
            {
                brand = this.database.Brands.Include(n=>n.Models).FirstOrDefault(x => x.Name == name);
            }

            return brand;
        }
        public Feature GetFeatureByName(string name)
        {
            Feature feature = null;

            using (database = new DealershipContext())
            {
                feature = this.database.Features.FirstOrDefault(x => x.Name == name);
            }

            return feature;
        }
        public void CreateCar(Car car)
        {
            using (database = new DealershipContext())
            {      
                car.Id= database.Cars.Max(u => u.Id)+1;
                this.database.Cars.Add(car);
                this.database.SaveChanges();
            }
        }
        public void CreateModel(Model model)
        {
            using (database = new DealershipContext())
            {
                model.Id = database.Models.Max(u => u.Id) + 1;
                this.database.Models.Add(model);
                this.database.SaveChanges();
            }
        }
        public void CreateBrand(Brand brand)
        {
            using (database = new DealershipContext())
            {
                brand.Id = database.Brands.Max(u => u.Id) + 1;
                this.database.Brands.Add(brand);
                this.database.SaveChanges();
            }
        }
        public void CreateFeature(Feature feature)
        {
            using (database = new DealershipContext())
            {
                feature.Id = database.Features.Max(u => u.Id) + 1;
                this.database.Features.Add(feature);
                this.database.SaveChanges();
            }
        }
        public void CreateCarFeatures(List<Feature>features, Car car)
        {
            using (database = new DealershipContext())
            {
                foreach (Feature feature in features)
                {
                    database.CarFeatures.Add(new CarFeature(car.Id, feature.Id));
                    database.SaveChanges();
                }
            }
        }
        public void AddModelToBrand(string modelName, Brand brand)
        {
            using (database = new DealershipContext())
            {
                Model model = this.database.Models.FirstOrDefault(x => x.Name == modelName);
                model.BrandId = brand.Id;
                this.database.SaveChanges();
            }
        }
        public List<Feature> GetCarFeatures(Car car)
        {
            List < Feature > features = new List<Feature>();
            using (database = new DealershipContext())
            {
                foreach (CarFeature feature in car.Features)
                {
                    features.Add(feature.Feature);
                }
                
            }
            return features;
        }
    }
}
