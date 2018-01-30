using System.Collections.Generic;

namespace BookStoreNS
{
    public interface IPriceCalculator
    {
        int GetPrice(List<BookStore.Book> shoppingCart);
    }
}