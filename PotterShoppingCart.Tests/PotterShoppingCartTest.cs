using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    public class BookStore
    {
        private List<Book> _shoppingCart = new List<Book>();
        private readonly int _potterPrice = 100;
        private readonly List<double> _potterOff = new List<double> { 1, 1, .95, .9, .8, .75 };

        public int Checkout()
        {
            int price = 0;
            int[] array = new int[5];
            _shoppingCart.ForEach(book => array[book.Episode - 1]++);

            int numberOfDiffEpisode = 0;

            do
            {
                numberOfDiffEpisode = 0;

                numberOfDiffEpisode = Array.FindAll(array, x => x > 0).Length;
                array = Array.ConvertAll(array, x => x - 1);

                price += (int)(numberOfDiffEpisode * _potterOff[numberOfDiffEpisode] * _potterPrice);
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