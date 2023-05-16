using System.Net;

namespace EndPointAPI
{
    public class Account
    {
        public int _id { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public string _nume { get; set; }
        public string _prenume { get; set; }
        public string _cnp { get; set; }
        public string _email { get; set; }
        public string _address { get; set; }
        public string _city { get; set; }
        public string _phoneNumber { get; set; }
        public int _accountType { get; set; }
        public int _blackListed { get; set; }

        public Account()
        {

        }
        public Account (Account a)
        {
            _username = a._username;
            _password = a._password;
            _nume = a._nume;
            _prenume = a._prenume;
            _cnp = a._cnp;
            _email = a._email;
            _address = a._address;
            _city = a._city;
            _phoneNumber = a._phoneNumber;
            _accountType = a._accountType;
            _blackListed = a._blackListed;
        }

        public Account(int id, string username, string password, string nume, string prenume, string cnp, string email, string address, string city, string phoneNumber, int accountType, int blackListed)
        {
            _id = id;
            _username = username;
            _password = password;
            _nume = nume;
            _prenume = prenume;
            _cnp = cnp;
            _email = email;
            _address = address;
            _city = city;
            _phoneNumber = phoneNumber;
            _accountType = accountType;
            _blackListed = blackListed;
        }
    }
}