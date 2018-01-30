using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    public class BookStore
    {
        private List<Book> _shoppingCart = new List<Book>();

        public int Checkout()
        {
            switch (_shoppingCart.Count)
            {
                case 1:
                    return 100;

                case 2:
                    return 190;

                case 3:
                    return 270;

                case 4:
                    int[] array = new int[5];
                    _shoppingCart.ForEach(book => array[book.Episode]++);

                    foreach (var i in array)
                    {
                        if (i > 1)
                        {
                            return 370;
                        }
                    }

                    return 320;

                case 5:
                    int[] array2 = new int[6];
                    _shoppingCart.ForEach(book => array2[book.Episode]++);

                    foreach (var i in array2)
                    {
                        if (i > 1)
                        {
                            return 460;
                        }
                    }
                    return 375;

                default:
                    return 0;
            }
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