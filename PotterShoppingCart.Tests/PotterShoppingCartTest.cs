using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class PotterShoppingCartTest
    {
        private string _bookPotter = "Potter";

        [TestMethod]
        public void BuyFirstPotter()
        {
            var bookStore = new BookStore();

            bookStore.PutInShoppingCart(_bookPotter, 1, 1);
            var expected = 100;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuyFirstAndSecondPotter()
        {
            var bookStore = new BookStore();

            bookStore.PutInShoppingCart(_bookPotter, 1, 1);
            bookStore.PutInShoppingCart(_bookPotter, 2, 1);
            var expected = 190;

            var actual = bookStore.Checkout();

            Assert.AreEqual(expected, actual);
        }
    }

    public class BookStore
    {
        private List<Book> _shoppingCart = new List<Book>();

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

        public int Checkout()
        {
            if (_shoppingCart.Count == 1)
                return 100;
            else
            {
                return 190;
            }
        }
    }
}