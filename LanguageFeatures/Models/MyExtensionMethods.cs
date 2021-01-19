﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices (this IEnumerable<Product> products)
        {   //ключевое слово this Указывает на то что TotalPrices - расширяемый метод
            decimal total = 0;
            foreach (Product prod in products)  //products-> Обращение к полю Products из ShoppingCart
            {
                total += prod?.Price ?? 0;
            }
            return total;
        }

        public static IEnumerable<Product> FilterByPrice (this IEnumerable<Product> productEnum, decimal minimumPrice)
        {
            foreach (Product prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimumPrice)
                    yield return prod;
            }
        }

        public static IEnumerable<Product> FilterByName (this IEnumerable<Product> productEnum, char firstLetter)
        {
            foreach (Product prod in productEnum)
            {
                if (prod?.Name?[0] == firstLetter)
                    yield return prod;
            }
        }

    }
}