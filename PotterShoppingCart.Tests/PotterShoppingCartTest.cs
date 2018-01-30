using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    public class BookStore
    {
        private List<Book> _shoppingCart = new List<Book>();
        private PotterPriceCalculator _priceCalculator;

        public BookStore(PotterPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        public int Checkout()
        {
            return _priceCalculator.GetPrice(_shoppingCart);
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
        private readonly BookStoreFacotry _bookStoreFacotry = new BookStoreFacotry();

        [TestMethod]
        public void BuyFirstAndSecondPotter()
        {
            var bookStore = _bookStoreFacotry.GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            PutOnePotterToShoppingCart(bookStore, 2);
            var expected = 190;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuyFirstPotter()
        {
            var bookStore = _bookStoreFacotry.GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            var expected = 100;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuyFirstAndSecondAndThirdPotter()
        {
            var bookStore = _bookStoreFacotry.GetBookStore();

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
            var bookStore = _bookStoreFacotry.GetBookStore();

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
            var bookStore = _bookStoreFacotry.GetBookStore();

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
            var bookStore = _bookStoreFacotry.GetBookStore();

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
            var bookStore = _bookStoreFacotry.GetBookStore();

            PutOnePotterToShoppingCart(bookStore, 1);
            PutOnePotterToShoppingCart(bookStore, 2);
            PutOnePotterToShoppingCart(bookStore, 2);
            PutOnePotterToShoppingCart(bookStore, 3);
            PutOnePotterToShoppingCart(bookStore, 3);
            var expected = 460;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        private void PutOnePotterToShoppingCart(BookStore bookStore, int episode)
        {
            bookStore.PutInShoppingCart("Potter", episode, 1);
        }
    }
}