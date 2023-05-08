using System.ComponentModel;

namespace EndPointAPI
{
    public class Book
    {
        private string _title;
        private string _author;
        private string _category;
        private int _stock;
        private int _total;
        private string _isbn;

        public Book(Book b)
        {
            _title = b._title;
            _author = b._author;
            _category = b._category;
            _stock = b._stock;
            _total = b._total;
            _isbn = b._isbn;
        }

        public string getTitle() { return _title; }
        public void setTitle(string title) { this._title = title; }
        public string getAuthor() { return _author; }
        public void setAuthor(string author) { this._author = author; }
        public string getCategory() { return _category; }
        public void setCategory(string category) { this._category = category; }

        public int getStock() { return _stock; }
        public void setStock(int stock) { this._stock = stock; }

        public int getTotal() { return _total; }
        public void setTotal(int total) { this._total = total; }

        public string getISBN() { return _isbn; }
        public void setISBN(string isbn) { this._isbn = isbn; }

        public override string ToString()
        {
            return "Book{" +
                "_title" + _title +
                "_author" + _author +
                "_category" + _category +
                "_stock" + _stock +
                "_total" + _total +
                "_isbn" + _isbn +
                '}';
        }
    }
}