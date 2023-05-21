namespace EndPointAPI
{
    public class Whishlist
    {
        private string _isbn { get; set; }
        private int _id { get; set; }

        public Whishlist (string isbn, int id)
        {
            _isbn = isbn;
            _id = id;
        }

        public Whishlist (Whishlist w)
        {
            _isbn = w._isbn;
            _id = w._id;
        }
    }
}
