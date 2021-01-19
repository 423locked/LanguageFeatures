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

            //используем метод TotalPrices на массиве productArray
            decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();

            //используем метод FilterByPrice(20) в массиве productArray чтобы найти элементы с ценой больше 20
            decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();

            //используем метод FilterByName чтобы отсортировать массив productArray по char firstLetter = 'S'
            decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

            return View("Index", new List<string> 
            { 
                $"Array Total: {arrayTotal:C2}",
                $"Price Total: {priceFilterTotal:C2}",
                $"Name Total: {nameFilterTotal:C2}" 
            });
        }
    }
}
