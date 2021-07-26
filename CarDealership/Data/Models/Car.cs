using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class Car:MainEntity
    {
        public Car(string name, int price, string type, int stock)
        {

            Name = name;
            Price = price;
            Type = type;
            Stock = stock;
        }


        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public ICollection<CarFeature> Features { get; set; }
        public int? ModelId { get; set; }
        public Model Model { get; set; }
    }
}
