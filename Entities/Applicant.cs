namespace Entities;

public class Applicant:User
{
    public string About { get; set; }

    public ICollection<Application> Applications { get; set; }

    public Applicant()
    {
        Applications = new HashSet<Application>();
    }

}
