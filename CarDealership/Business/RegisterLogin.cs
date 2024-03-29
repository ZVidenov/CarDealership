﻿using CarDealership.Data;
using CarDealership.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Business
{
    public class RegisterLogin
    {
        private DealershipContext database;
        public bool Register(string name,string password)
        {
            Salesman salesman = new Salesman();

            using (database = new DealershipContext())
            {
                salesman = this.database.Salesmen.FirstOrDefault(x => x.Name == name);
                if (salesman != null)
                    return false;
                salesman = new Salesman();
                salesman.Id = database.Salesmen.Max(u => u.Id) + 1;
                salesman.Name = name;
                salesman.Password = GetStringSha256Hash(password);
                salesman.Profits = 0;
                this.database.Salesmen.Add(salesman);
                this.database.SaveChanges();
                return true;
            }
        }
        public bool LogIn(string name, string password)
        {
            Salesman salesman = new Salesman();
            password = GetStringSha256Hash(password);
            using (database = new DealershipContext())
            {
                salesman = this.database.Salesmen.FirstOrDefault(x => x.Name == name);
                if (salesman == null)
                    return false;
                if(salesman.Name==name && salesman.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Salesman GetSalesman(string name)
        {
            Salesman salesman = new Salesman();
            using (database = new DealershipContext())
            {
                salesman = this.database.Salesmen.FirstOrDefault(x => x.Name == name);
            }
            return salesman;
        }
        internal static string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

    }
}
