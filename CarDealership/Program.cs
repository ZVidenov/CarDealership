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
                RegisterLogin registerLogin = new RegisterLogin();
                Display display = new Display(dealershipBusiness, registerLogin);
                display.Run();
            
        }
    }
}
