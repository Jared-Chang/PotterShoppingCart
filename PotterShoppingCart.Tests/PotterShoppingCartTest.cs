using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }

    public class BookStore
    {
        public void PutInShoppingCart(string bookName, int episode, int number)
        {
        }

        public int Checkout()
        {
            return 100;
        }
    }
}