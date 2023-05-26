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
        public Wishlist() { }   
        public Wishlist(int isbn, int id)
        {
            ISBN = isbn;
            AccountId = id;
        }

        public Wishlist(Wishlist w)
        {
            ISBN = w.ISBN;
            AccountId = w.AccountId;
        }
        #endregion
    }
}
