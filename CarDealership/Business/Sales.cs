using CarDealership.Data;
using CarDealership.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Business
{
    public class Sales
    {
        private DealershipContext database;

        public void Sale(string salesmanName, string carName,int soldAmount){
            Salesman salesman = new Salesman();
            Car car = new Car();
            decimal earnings=0;
            using (database = new DealershipContext())
            {
                salesman = this.database.Salesmen.FirstOrDefault(x => x.Name == salesmanName);
                car= this.database.Cars.FirstOrDefault(x => x.Name == carName);
                earnings = car.Price * soldAmount;
                salesman.Profits = salesman.Profits + earnings;
                car.Stock = car.Stock - soldAmount;
                database.SaveChanges();
            }
        }
    }
}
