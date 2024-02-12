using BasicAuth;
using System.Globalization;

namespace BasicAuth;

public class User : Person
{
    public int Id { get; set; }

    public User() { }

    public User(int id, string firstname, string lastname, string username, string password)
        : base(firstname, lastname, username, password)
    {
        base.Firstname = firstname;
        base.Lastname = lastname;
        base.Username = username;
        base.Password = password;
        Id = id;
    }

    public void PrintUserInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Firstname:  {Firstname}");
        Console.WriteLine($"Lastname: {Lastname}");
        Console.WriteLine($"Username: {Username}");
        Console.WriteLine($"Password: {Password}");
    }
}
