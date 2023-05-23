using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIP
{
    public class Wishlist
    {
        public int _wishlistId { get; set; }
        public string _isbn { get; set; }
        public int _accountId { get; set; }

        public Wishlist(string isbn, int id)
        {
            _isbn = isbn;
            _accountId = id;
        }

        public Wishlist(Wishlist w)
        {
            _isbn = w._isbn;
            _accountId = w._accountId;
        }
    }
}
