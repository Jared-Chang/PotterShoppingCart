using System;
using System.Collections.Generic;
using System.Linq;

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

            List<List<int>> permutations = GetPermutations(array);
            List<int> prices = CalculatePrice(permutations);

            return prices.Min();
        }

        private List<int> CalculatePrice(List<List<int>> permutations)
        {
            var result = new List<int>();

            permutations.ForEach(list => { result.Add((int)list.Select(x => x * _potterPrice * _potterOff[x]).Sum()); });

            return result;
        }

        private List<List<int>> GetPermutations(int[] array)
        {
            var result = new List<List<int>>();

            for (int limit = 1; limit < _potterOff.Count; limit++)
            {
                result.Add(GetAPermutation(array, limit));
            }

            return result;
        }

        private List<int> GetAPermutation(int[] array, int limit)
        {
            int[] tempArray = new int[array.Length];
            Array.Copy(array, tempArray, array.Length);
            List<int> result = new List<int>();

            var numberOfDiffEpisode = 1;

            while (numberOfDiffEpisode != 0)
            {
                numberOfDiffEpisode = GetNumberOfDiffEpisode(limit, tempArray);

                result.Add(numberOfDiffEpisode);
            }

            return result;
        }

        private static int GetNumberOfDiffEpisode(int limit, int[] tempArray)
        {
            int numberOfDiffEpisode = 0;

            for (int j = 0; j < tempArray.Length && numberOfDiffEpisode != limit; j++)
            {
                if (tempArray[j] > 0)
                {
                    tempArray[j]--;
                    numberOfDiffEpisode++;
                }
            }

            return numberOfDiffEpisode;
        }
    }
}