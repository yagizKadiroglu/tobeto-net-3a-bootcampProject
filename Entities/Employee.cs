namespace Entities;

public class Employee : User
{
    public string Position { get; set; }

    public Employee()
    {
        
    }

    public Employee(int id, string username, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, string position) : this()
    {
        Id = id;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Password = password;
        Position = position;
    }
}

