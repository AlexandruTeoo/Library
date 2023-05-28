/**************************************************************************
 *                                                                        *
 *  File:        WishlistLibrary.dll                                      *
 *  Copyright:   (c) 2023, Radu Dumitriu                                  *
 *  E-mail:      radu-toader.dumitriu@student.tuiasi.ro                   *
 *  Website:     https://github.com/RadukDumi                             *
 *  Description: Wishlist (class)                                         *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistLibrary
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
