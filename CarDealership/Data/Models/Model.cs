using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class Model:MainEntity
    {
        public Model(string name)
        {
            Name = name;
            this.Cars = new List<Car>();
        }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
