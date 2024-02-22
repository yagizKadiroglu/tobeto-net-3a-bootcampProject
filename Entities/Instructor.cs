namespace Entities;

public class Instructor:User
{
    public string CompanyName { get; set; }

    public virtual ICollection<Bootcamp> Bootcamps { get; set; }

    public Instructor()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }
}
