namespace Entities;

public class Instructor:User
{
    public string CompanyName { get; set; }

    public virtual ICollection<Bootcamp> Bootcamps { get; set; }

    public Instructor()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }

    public Instructor(int id, string username, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, string companyName):this()
    {
        Id = id;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Password = password;
        CompanyName = companyName;
    }
}
