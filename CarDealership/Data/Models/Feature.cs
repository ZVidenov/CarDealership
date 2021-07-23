﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CarFeature> Cars { get; set; }
    }
}
