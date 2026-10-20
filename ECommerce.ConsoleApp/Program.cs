using System;
using System.Collections.Generic;
using ECommerce.Core.Data;
using ECommerce.Core.Logic;

namespace ECommerce.ConsoleApp
{
    class Program
    {

        
        static void Main(string[] args)
        {
            ShopManager shopManager = new ShopManager();
            shopManager.RunShop();
        }
    }
}