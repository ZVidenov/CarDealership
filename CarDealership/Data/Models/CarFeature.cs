using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class CarFeature
    {
        public CarFeature(int carId,int featureId)
        {
            CarId = carId;
            FeatureId = featureId;
        }
        public int CarId { get; set; }
        public Car Car {get;set;}
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
