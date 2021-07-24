using CarDealership.Business;
using CarDealership.Presentation;
using System;

namespace CarDealership
{
    class Program
    {
        static void Main(string[] args)
        {
            
                DealershipBusiness dealershipBusiness = new DealershipBusiness();
                Display display = new Display(dealershipBusiness);
                display.Run();
            
        }
    }
}
