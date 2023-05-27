using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary
{
    public class Account
    {
        #region Getters and Setters
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int AccountType { get; set; }
        public int BlackListed { get; set; }
        #endregion
        #region Constructors
        public Account()
        {

        }
        public Account(Account a) // constructor
        {
            Username = a.Username;
            Password = a.Password;
            Nume = a.Nume;
            Prenume = a.Prenume;
            CNP = a.CNP;
            Email = a.Email;
            Address = a.Address;
            City = a.City;
            PhoneNumber = a.PhoneNumber;
            AccountType = a.AccountType;
            BlackListed = a.BlackListed;
        }

        // constructor
        public Account(int id, string username, string password, string nume, string prenume, string cnp, string email, string address, string city, string phoneNumber, int accountType, int blackListed)
        {
            Id = id;
            Username = username;
            Password = password;
            Nume = nume;
            Prenume = prenume;
            CNP = cnp;
            Email = email;
            Address = address;
            City = city;
            PhoneNumber = phoneNumber;
            AccountType = accountType;
            BlackListed = blackListed;
        }
        #endregion
    }
}
