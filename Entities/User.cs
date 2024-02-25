using Core.Entities;

namespace Entities;

public class User:BaseEntity<int>
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<UserImage> UserImages { get; set; }

    public User()
    {
        UserImages = new HashSet<UserImage>();
    }

    public User(int id,string username, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password)
    {
        Id = id;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Password = password;
    }
}
