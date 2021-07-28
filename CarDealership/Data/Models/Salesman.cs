using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class Salesman:MainEntity
    {
        
        public string Name { get; set; }
        public string Password { get; set; }
        public double Profits { get; set; }
    }
}
