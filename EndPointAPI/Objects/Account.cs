using System;

public class Account
{
    private int _id;
    private string _username;
    private string _password;
    private string _nume;
    private string _prenume;
    private string _email;
    private string _address;
    private string _city;
    private string _phoneNumber;
    private string _accountType;

    public int getId() { return _id; }
    public void setId(int id) { this._id = id; }
    
    public string getUsername() { return _username; }
    public void setUsername(string username) { this._username = username; }
    
    public string getPassword() { return _password; }
    public void setPassword(string password) { this._password = password; }

    public string getNume() { return _nume; }
    public void setNume(string nume) { this._nume = nume; }

    public string getPrenume() { return _prenume; }
    public void setPrenume(string prenume) { this._prenume = prenume; }

    public string getEmail() { return _email; }
    public void setEmail(string email) { this._email = email; }
    
    public string getAddress() { return _address; }
    public void setAddress(string address) { this._address = address; }
    
    public string getCity() { return _city; }
    public void setCity(string city) { this._city = city; }

    public string getPhoneNumber() { return _phoneNumber; }
    public void setPhoneNumber(string phoneNumber) { this._phoneNumber = phoneNumber; }

    public string getAccountType() { return _accountType; }
    public void setAccountType(string accountType) { this._accountType = accountType; }

    public override string ToString()
    {
        return "Book{" +
            "_id" + _id +
            "_username" + _username +
            "_password" + _password +
            "_nume" + _nume +
            "_prenume" + _prenume +
            "_email" + _email +
            "_address" + _address +
            "_city" + _city +
            "_phoneNumber" + _phoneNumber +
            "_accountType" + _accountType +
            '}';
    }
}
