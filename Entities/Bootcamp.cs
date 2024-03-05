using Core.Entities;

namespace Entities;

public class Bootcamp : BaseEntity<int>
{
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public int BootcampStateId { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }


    public virtual Instructor Instructor { get; set; }
    public virtual BootcampState BootcampState { get; set; }

    public virtual ICollection<Application> Applications { get; set; }

    public Bootcamp()
    {
        Applications = new HashSet<Application>();
    }

    public Bootcamp(int id,string name, int instructorId, int bootcampStateId, DateTime starDate, DateTime endDate):this()
    {
        Id = id;
        Name = name;
        InstructorId = instructorId;
        BootcampStateId = bootcampStateId;
        StarDate = starDate;
        EndDate = endDate;
    }
}
