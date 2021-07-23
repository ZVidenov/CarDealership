using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class CarFeature
    {
        public int CarId { get; set; }
        public Car Car {get;set;}
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
