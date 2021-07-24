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

        public Car GetCarByName(string name)
        {
            Car car = null;

            using (database = new DealershipContext())
            {
                car = this.database.Cars.FirstOrDefault(x => x.Name == name);
            }

            return car;
        }
        public Model GetModelByName(string name)
        {
            Model model = null;

            using (database = new DealershipContext())
            {
                model = this.database.Models.FirstOrDefault(x => x.Name == name);
            }

            return model;
        }
        public Brand GetBrandByName(string name)
        {
            Brand brand = null;

            using (database = new DealershipContext())
            {
                brand = this.database.Brands.FirstOrDefault(x => x.Name == name);
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
                this.database.Models.Add(model);
                this.database.SaveChanges();
            }
        }
        public void CreateBrand(Brand brand)
        {
            using (database = new DealershipContext())
            {
                this.database.Brands.Add(brand);
                this.database.SaveChanges();
            }
        }
        public void CreateFeature(Feature feature)
        {
            using (database = new DealershipContext())
            {
                this.database.Features.Add(feature);
                this.database.SaveChanges();
            }
        }
    }
}
