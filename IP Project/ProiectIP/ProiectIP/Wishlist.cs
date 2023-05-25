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
        public int _wishlistId { get; set; }
        public int _isbn { get; set; }
        public int _accountId { get; set; }
        #endregion
        #region Constructors
        public Wishlist() { }   
        public Wishlist(int isbn, int id)
        {
            _isbn = isbn;
            _accountId = id;
        }

        public Wishlist(Wishlist w)
        {
            _isbn = w._isbn;
            _accountId = w._accountId;
        }
        #endregion
    }
}
