using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    public class BookStore
    {
        private List<Book> _shoppingCart = new List<Book>();

        public int Checkout()
        {
            return _shoppingCart.Count == 1 ? 100 : 190;
        }

        public void PutInShoppingCart(string bookName, int episode, int number)
        {
            _shoppingCart.Add(new Book(bookName, episode));
        }

        public class Book
        {
            public Book(string bookName, int episode)
            {
            }
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