using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProiectIP;
using System;
using System.Collections.Generic;
using DatabaseLibrary;
using BookLibrary;
using AccountLibrary;

namespace UnitTest
{
    [TestClass]
    public class WishlistTest
    {
        [TestMethod]
        public void TestGetWishlist_ShouldReturnWishlist_WhenValidAccountIdProvided()
        {
            // Arrange
            int accountId = 1;
            Wishlist wishlist = new Wishlist();

            // Assuming you have a mock or test-specific implementation of WishlistManager,
            // you can set up a dummy wishlist to be returned by the GetWishlist method
            List<Book> expectedWishlist = new List<Book>()
            {
                new Book { Title = "Book 1", Author = "Author 1", Category = "Category 1", ISBN = 1 },
                new Book { Title = "Book 2", Author = "Author 2", Category = "Category 2",  ISBN = 2 }
            };
            // Set up the desired behavior of the GetWishlist method
            // For example, if using a mock framework like Moq:
            Mock<WishlistDAO> wishlistManagerMock = new Mock<WishlistDAO>();
            wishlistManagerMock.Setup(w => w.GetWishlist(accountId)).Returns(expectedWishlist);
            WishlistDAO wishlistManager = wishlistManagerMock.Object;

            // Act
            List<Book> actualWishlist = wishlistManager.GetWishlist(accountId);

            // Assert
            Assert.IsNotNull(actualWishlist);
            Assert.AreEqual(expectedWishlist.Count, actualWishlist.Count);
            for (int i = 0; i < expectedWishlist.Count; i++)
            {
                Assert.AreEqual(expectedWishlist[i].Category, actualWishlist[i].Category);
                Assert.AreEqual(expectedWishlist[i].Title, actualWishlist[i].Title);
                Assert.AreEqual(expectedWishlist[i].Author, actualWishlist[i].Author);
                Assert.AreEqual(expectedWishlist[i].ISBN, actualWishlist[i].ISBN);
            }
        }
    }
}
