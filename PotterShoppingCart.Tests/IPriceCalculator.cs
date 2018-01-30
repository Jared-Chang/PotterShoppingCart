using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    public  interface IPriceCalculator
    {
        int GetPrice(List<BookStore.Book> shoppingCart);
    }
}