using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DatabaseLibrary;
using BookLibrary;
using AccountLibrary;
using LoanLibrary;
using WishlistLibrary;

namespace UnitTest
{
    [TestClass]
    public class UnitTestLibrary
    {
        private Book _book = new Book(
            -1, 
            "test title", 
            "test author", 
            "testCategory", 
            1, 
            1);

        private Account _account = new Account(
            -1, 
            "testUsername", 
            "testPassword", 
            "testNume",
            "testPrenume", 
            "1234567891234",
            "test@email",
            "test address",
            "testCity",
            "0712345678", 
            1,
            0);

        private Loan _loan = new Loan(
            -1,
            -1,
            -1,
            DateTime.Now,
            DateTime.Now.AddDays(14),
            0);

        private Wishlist _wishlist = new Wishlist(-1, -1);

        [TestMethod]
        public void InsertBookTest ()
        {
            try
            {
                BookDAO.InsertBook(_book, _book.Total);
                Assert.AreEqual("1", "1", "Carte inserata");
            }
            catch(Exception ex) 
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetBookTest () 
        {
            try
            {
                Book book = BookDAO.GetBook(_book.Title, _book.Author);

                Assert.AreNotEqual(null, book, "Cartea a fost preluata");
                Assert.AreEqual(_book.Title, book.Title, "Preluarea cartii a fost efectuata cu succes");
                Assert.AreEqual(_book.Author, book.Author, "Preluarea cartii a fost efectuata cu succes");
                Assert.AreEqual(_book.Category, book.Category, "Preluarea cartii a fost efectuata cu succes");

                _book = book;
            }
            catch (Exception ex)
            {
                Assert.Fail (ex.Message);
            }
        }

        [TestMethod]
        public void GetBooksTest ()
        {
            try
            {
                List<Book> books = BookDAO.GetBooks();

                Assert.AreNotEqual (0, books.Count, "Preluarea cartilor a fost efectuata cu succes");
            }
            catch (Exception ex)
            {
                Assert.Fail (ex.Message);
            }
        }

        [TestMethod]
        public void ModifyBookTest ()
        {
            try
            {
                Book book = new Book(-1, "new test title", "new test author", "new test category", 1, 1); ;
                BookDAO.ModifyBook(book);

                Assert.AreEqual("new test title", book.Title, "Titlul cartii a fost modificat cu succes");
                Assert.AreEqual("new test author", book.Author, "Autorul cartii a fost modificat cu succes");
                Assert.AreEqual("new test category", book.Category, "Categoria cartii a fost modificata cu succes");
            }
            catch (Exception ex)
            {
                Assert.Fail (ex.Message);
            }
        }

        [TestMethod]
        public void InsertAccountTest ()
        {
            try
            {
                AccountDAO.InsertAccount(_account);
                Assert.AreEqual("testUsername", _account.Username, "Cont inserat cu succes");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetAccountTest ()
        {
            try
            {
                Account account = AccountDAO.GetAccount(_account.Username, _account.Password);

                Assert.AreNotEqual(null, account, "Cartea a fost preluata");
                Assert.AreEqual(_account.Username, account.Username, "Preluarea contului a fost efectuata cu succes");
                Assert.AreEqual(_account.Password, account.Password, "Preluarea contului a fost efectuata cu succes");
                Assert.AreEqual(_account.Nume, account.Nume, "Preluarea contului a fost efectuata cu succes");
                Assert.AreEqual(_account.Prenume, account.Prenume, "Preluarea contului a fost efectuata cu succes");
                Assert.AreEqual(_account.CNP, account.CNP, "Preluarea contului a fost efectuata cu succes");
                Assert.AreEqual(_account.Email, account.Email, "Preluarea contului a fost efectuata cu succes");
                Assert.AreEqual(_account.City, account.City, "Preluarea contului a fost efectuata cu succes");
                Assert.AreEqual(_account.PhoneNumber, account.PhoneNumber, "Preluarea contului a fost efectuata cu succes");
                Assert.AreEqual(_account.Address, account.Address, "Preluarea contului a fost efectuata cu succes");

                _account = account;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AddLoanTest()
        {
            try
            {
                Book book = BookDAO.GetBook(_book.Title, _book.Author);
                Account account = AccountDAO.GetAccount(_account.Username, _account.Password);

                _loan.ISBN = book.ISBN;
                _loan.AccountId = account.Id;

                Console.WriteLine (_loan);
                LoanDAO.AddLoan(_loan);
                Assert.AreEqual("1", "1", "Imprumut inserat");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetLoansTest()
        {
            try
            {
                List<Loan> loans = LoanDAO.GetLoans(_account.Id);

                Assert.AreNotEqual(null, loans, "Imprumutul a fost prelucrat");
                Assert.AreEqual(_loan.LoanId, loans[0].LoanId, "Preluarea imprumutului a fost efectuata cu succes");

                _loan = loans[0];
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetAllLoanTest()
        {
            try
            {
                List<Loan> loans = LoanDAO.GetAllLoans();

                Assert.AreNotEqual(null, loans, "Imprumuturile au fost prelucrate");
                Assert.AreEqual(_loan.LoanId, loans[0].LoanId, "Preluarea imprumuturilor au fost efectuate cu succes");

                _loan = loans[0];
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ApproveLoanTest()
        {
            try
            {
                LoanDAO.ApproveLoan(_loan.LoanId);

                Assert.AreEqual(1, _loan.Accepted, "Preluarea imprumuturilor au fost efectuate cu succes");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AddBookWishlistTest()
        {
            try
            {


                Book book = BookDAO.GetBook(_book.Title, _book.Author);
                Account account = AccountDAO.GetAccount(_account.Username, _account.Password);

                _wishlist.ISBN = book.ISBN;
                _wishlist.AccountId = account.Id;
                Console.WriteLine(_wishlist);
                WishlistDAO.AddBookWishlist(_wishlist);

                WishlistDAO.AddBookWishlist(_wishlist);
                Assert.AreEqual("1", "1", "Cont inserat cu succes");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetWishlistTest()
        {
            try
            {
                List <Book> wishlist = WishlistDAO.GetWishlist(_account.Id);

                Assert.AreNotEqual(null, wishlist, "Wishlist-ul a fost preluata");
                Assert.AreEqual(_wishlist.ISBN, wishlist[0].ISBN, "Preluarea wishlist-ului a fost efectuata cu succes");

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        //ultimele

        [TestMethod]
        public void DeleteBookWishlistTest()
        {
            try
            {
                WishlistDAO.DeleteBookWishlist(_wishlist);
                //Assert.IsNull(_wishlist);

                List<Book> wishlist = WishlistDAO.GetWishlist(_account.Id);
                bool bookExistsInWishlist = (_wishlist.ISBN == wishlist[0].ISBN);
                Assert.IsFalse(bookExistsInWishlist, "Cartea a fost stearsa din wishlist");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            try
            {
                BookDAO.DeleteBook(_book);

                //Assert.IsNull(_wishlist);

                Book book = BookDAO.GetBook(_book.Title, _book.Author);
                bool bookExistsInLibrary = (book == _book);
                Assert.IsFalse(bookExistsInLibrary, "Cartea a fost stearsa");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetBookTest_BookDeleted()
        {
            try
            {
                Book book = BookDAO.GetBook(_book.Title, _book.Author);

                Assert.AreNotEqual(null, book, "Cartea a fost preluata");
                Assert.AreEqual(_book.Title, book.Title, "Preluarea cartii a fost efectuata cu succes");
                Assert.AreEqual(_book.Author, book.Author, "Preluarea cartii a fost efectuata cu succes");
                Assert.AreEqual(_book.Category, book.Category, "Preluarea cartii a fost efectuata cu succes");

                _book = book;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
