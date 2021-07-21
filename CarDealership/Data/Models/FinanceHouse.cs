using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class FinanceHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SalesmenHouses> Salesmen{ get; set; }
    }
}
