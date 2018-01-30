using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    public class BookStore
    {
        private List<Book> _shoppingCart = new List<Book>();
        private IPriceCalculator _priceCalculator;

        public BookStore(IPriceCalculator priceCalculator)
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
}