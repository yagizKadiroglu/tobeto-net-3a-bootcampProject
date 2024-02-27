namespace Entities;

public class Applicant:User
{
    public string About { get; set; }

    public ICollection<Application> Applications { get; set; }
    public ICollection<BlackList> BlackLists { get; set; } 

    public Applicant()
    {
        BlackLists = new HashSet<BlackList>();
        Applications = new HashSet<Application>();
    }

}
