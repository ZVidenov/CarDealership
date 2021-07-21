using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class SalesmenHouses
    {
        public SalesmenHouses(int salesmanId,int financeHouseId)
        {
            SalesmanId = salesmanId;
            FinanceHouseId = financeHouseId;
        }
        public int SalesmanId { get; set; }
        public Salesman Salesman { get; set; }
        public int FinanceHouseId { get; set; }
        public FinanceHouse FinanceHouse { get; set; }
    }
}
