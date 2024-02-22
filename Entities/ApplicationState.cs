using Core.Entities;

namespace Entities;

public class ApplicationState : BaseEntity<int>
{
    public string Name { get; set; }

    public virtual ICollection<Application> Applications { get; set; }

    public ApplicationState()
    {
        Applications = new HashSet<Application>();
    }

    public ApplicationState(int id,string name):this()
    {
        Id = id;
        Name = name;
    }
}
