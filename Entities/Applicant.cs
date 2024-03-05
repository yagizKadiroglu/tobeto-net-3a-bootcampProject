namespace Entities;

public class Applicant:User
{
    public string About { get; set; }

    public ICollection<Application> Applications { get; set; }
    public BlackList BlackList { get; set; } 

    public Applicant()
    {
        Applications = new HashSet<Application>();
    }

    public Applicant(int id, string username, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, string about) : this()
    {
        Id = id;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Password = password;
        About = about;
    }
}
