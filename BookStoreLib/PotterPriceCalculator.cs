using System.Collections.Generic;

namespace BookStoreNS
{
    internal class PotterPriceCalculator : IPriceCalculator
    {
        private readonly int _potterPrice = 100;
        private readonly List<double> _potterOff = new List<double> { 1, 1, .95, .9, .8, .75 };

        public int GetPrice(List<BookStore.Book> shoppingCart)
        {
            int price = 0;
            int[] array = new int[5];
            shoppingCart.ForEach(book => array[book.Episode - 1]++);

            bool fourFirst = shoppingCart.Count % 4 == 0;

            int numberOfDiffEpisode = 0;

            do
            {
                numberOfDiffEpisode = 0;

                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] > 0)
                    {
                        array[j]--;
                        numberOfDiffEpisode++;
                        if (fourFirst && numberOfDiffEpisode == 4) break;
                    }
                }

                price += (int)(numberOfDiffEpisode * _potterOff[numberOfDiffEpisode] * _potterPrice);
            } while (numberOfDiffEpisode != 0);

            return price;
        }
    }
}