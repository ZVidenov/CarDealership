﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public ICollection<CarFeature> Features { get; set; }
        public Model Model { get; set; }
    }
}
