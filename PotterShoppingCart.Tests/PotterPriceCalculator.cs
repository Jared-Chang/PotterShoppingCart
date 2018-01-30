using System;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    public class PotterPriceCalculator
    {
        private readonly int _potterPrice = 100;
        private readonly List<double> _potterOff = new List<double> { 1, 1, .95, .9, .8, .75 };

        public int GetPrice(List<BookStore.Book> shoppingCart)
        {
            int price = 0;
            int[] array = new int[5];
            shoppingCart.ForEach(book => array[book.Episode - 1]++);

            int numberOfDiffEpisode = 0;

            do
            {
                numberOfDiffEpisode = Array.FindAll(array, x => x > 0).Length;
                array = Array.ConvertAll(array, x => x - 1);

                price += (int) (numberOfDiffEpisode * _potterOff[numberOfDiffEpisode] * _potterPrice);
            } while (numberOfDiffEpisode != 0);

            return price;
        }
    }
}