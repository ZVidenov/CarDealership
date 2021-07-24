﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class Brand:MainEntity
    {
        
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
