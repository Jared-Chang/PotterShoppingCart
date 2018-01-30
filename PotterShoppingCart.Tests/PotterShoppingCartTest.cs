using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    public class BookStore
    {
        private List<Book> _shoppingCart = new List<Book>();

        public int Checkout()
        {
            int price = 0;
            int[] array = new int[5];
            _shoppingCart.ForEach(book => array[book.Episode - 1]++);

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
                    }
                }

                switch (numberOfDiffEpisode)
                {
                    case 1:
                        price += numberOfDiffEpisode * 100 * 1;
                        break;

                    case 2:
                        price += (int)(numberOfDiffEpisode * 100 * 0.95);
                        break;

                    case 3:
                        price += (int)(numberOfDiffEpisode * 100 * 0.9);
                        break;

                    case 4:
                        price += (int)(numberOfDiffEpisode * 100 * 0.8);
                        break;

                    case 5:
                        price += (int)(numberOfDiffEpisode * 100 * 0.75);
                        break;
                }
            } while (numberOfDiffEpisode != 0);

            return price;
        }

        public void PutInShoppingCart(string bookName, int episode, int number)
        {
            _shoppingCart.Add(new Book(bookName, episode));
        }

        public class Book
        {
            public Book(string bookName, int episode)
            {
                Episode = episode;
            }

            public int Episode { get; set; }
        }
    }

    [TestClass]
    public class PotterShoppingCartTest
    {
        [TestMethod]
        public void BuyFirstAndSecondPotter()
        {
            var bookStore = GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            PutOnePotterToShoppingCart(bookStore, 2);
            var expected = 190;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuyFirstPotter()
        {
            var bookStore = GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            var expected = 100;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuyFirstAndSecondAndThirdPotter()
        {
            var bookStore = GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            PutOnePotterToShoppingCart(bookStore, 2);
            PutOnePotterToShoppingCart(bookStore, 3);
            var expected = 270;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuyFirstAndSecondAndThirdAndFourthPotter()
        {
            var bookStore = GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            PutOnePotterToShoppingCart(bookStore, 2);
            PutOnePotterToShoppingCart(bookStore, 3);
            PutOnePotterToShoppingCart(bookStore, 4);
            var expected = 320;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuyAllPotter()
        {
            var bookStore = GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            PutOnePotterToShoppingCart(bookStore, 2);
            PutOnePotterToShoppingCart(bookStore, 3);
            PutOnePotterToShoppingCart(bookStore, 4);
            PutOnePotterToShoppingCart(bookStore, 5);
            var expected = 375;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuyFirstAndSecondAndTwoThirdPotter()
        {
            var bookStore = GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            PutOnePotterToShoppingCart(bookStore, 2);
            PutOnePotterToShoppingCart(bookStore, 3);
            PutOnePotterToShoppingCart(bookStore, 3);
            var expected = 370;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuyFirstAndTwoSecondAndTwoThirdPotter()
        {
            var bookStore = GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            PutOnePotterToShoppingCart(bookStore, 2);
            PutOnePotterToShoppingCart(bookStore, 2);
            PutOnePotterToShoppingCart(bookStore, 3);
            PutOnePotterToShoppingCart(bookStore, 3);
            var expected = 460;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        private BookStore GetBookStore()
        {
            return new BookStore();
        }

        private void PutOnePotterToShoppingCart(BookStore bookStore, int episode)
        {
            bookStore.PutInShoppingCart("Potter", episode, 1);
        }
    }
}