using BookLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WishlistLibrary;

namespace UnitTestWishlist
{
    [TestClass]
    public class BookTest
    {
        private Book _book;
        
        [TestInitialize]
        public void TestInitialize ()
        {
            _book = new Book(-1, "test", "autor test", "unit test", 3, 3);

        }
        [TestMethod]
        public void InsertBookTest()
        {
            try
            {
                BookDAO.InsertBook(_book, _book.Stock);
                Assert.AreEqual("1", "1", "Inserat cu succes");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("1", "0", "Inserare esuata");
            }
        }

        [TestMethod]
        public void GetBooksTest()
        {
            try
            {
                List<Book> books = BookDAO.GetBooks();
                Assert.AreNotEqual(0, books.Count, "Preluarea cartilor a fost efectuata cu succes");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("1", "0", "Preluarea cartilor a esuat");
            }
        }

        [TestMethod]
        public void GetBookTest()
        {
            try
            {
                Book book = BookDAO.GetBook(_book.Title, _book.Author);
                Assert.AreNotEqual(null, book, "Cartea a fost preluata");
                Assert.AreEqual(_book.Title, book.Title, "Preluarea cartilor a fost efectuata cu succes");
                Assert.AreEqual(_book.Author, book.Author, "Preluarea cartilor a fost efectuata cu succes");
                Assert.AreEqual(_book.Category, book.Category, "Preluarea cartilor a fost efectuata cu succes");
                
                _book = book;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("1", "0", "Preluarea cartilor a esuat");
            }
        }

        [TestMethod]
        public void ModifyBookTest()
        {
            _book.Title = "new Title";
            try
            {
                BookDAO.ModifyBook(_book);
                //Book book = BookDAO.GetBook("new Title", _book.Author);
                //Assert.AreEqual("test", "new Title", "Modificarea cartii a fost efectuata cu succes");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("1", "0", ex.Message);
            }
        }
    }
}
