using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIP
{
    public class Wishlist
    {
        #region Getters and Setters
        public int WishlistId { get; set; }
        public int ISBN { get; set; }
        public int AccountId { get; set; }
        #endregion
        #region Constructors
        public Wishlist() { }    // constructor
        public Wishlist(int isbn, int id) // constructor
        {
            ISBN = isbn;
            AccountId = id;
        }

        public Wishlist(Wishlist w) // constructor
        {
            ISBN = w.ISBN;
            AccountId = w.AccountId;
        }
        #endregion
    }
}
