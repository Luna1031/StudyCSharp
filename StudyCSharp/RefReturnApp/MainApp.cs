﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefReturnApp
{
    class Product
    {
        private int price = 100;

        public void PrintPrice()
        {
            Console.WriteLine($"Price : {price}");  
        }
        public ref int GetPrice()
        {
            return ref price;
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Product carrot = new Product();
            int local_price = carrot.GetPrice();
            carrot.PrintPrice();

            local_price = 3000;
            carrot.PrintPrice();
            Console.WriteLine($"local_price = {local_price}");
        }
    }
}
