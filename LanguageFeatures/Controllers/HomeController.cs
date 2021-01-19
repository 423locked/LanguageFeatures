using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) >= 20;
        }

        public ViewResult Index()
        {
            //объявляется новый объект cart на основе класса ShoppingCart.cs
            ShoppingCart cart = new ShoppingCart
            {
                Products = Product.GetProducts()
            };
            //вызывается расширяемый метод TotalPrices из MyExtensionMethod.cs
            Product[] productArray =
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };

            Func<Product, bool> nameFilter = delegate (Product prod)
            {
                return prod?.Name?[0] == 'S';
            };

            decimal priceFilterTotal = productArray.Filter(FilterByPrice).TotalPrices();

            decimal nameFilterTotal = productArray.Filter(nameFilter).TotalPrices();

            return View("Index", new List<string> 
            { 
                $"Price Total: {priceFilterTotal:C2}",
                $"Name Total: {nameFilterTotal:C2}" 
            });
        }
    }
}
