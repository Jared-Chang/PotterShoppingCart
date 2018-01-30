namespace BookStoreNS
{
    public class BookStoreFacotry
    {
        public BookStore GetBookStore()
        {
            return new BookStore(new PotterPriceCalculator());
        }
    }
}