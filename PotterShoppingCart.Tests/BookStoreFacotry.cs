namespace PotterShoppingCart.Tests
{
    public class BookStoreFacotry
    {
        public BookStore GetBookStore()
        {
            return new BookStore(new PotterPriceCalculator());
        }
    }
}