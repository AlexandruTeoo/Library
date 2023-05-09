namespace EndPointAPI
{
    public class Whishlist
    {
        private string _isbn;
        private int _id;

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

        public string getISBN () { return _isbn; }
        public void setISBN(string isbn) { _isbn = isbn; }

        public int getId () { return _id; }
        public void setId (int id) { _id = id;}

        public override string ToString()
        {
            return "Whishlist{" +
                "_isbn" + _isbn +
                "_id" + _id +
                "}";
        }
    }
}
