using Core.Entities;

namespace Entities;

public class BootcampState : BaseEntity<int>
{
    public string Name { get; set; }

    public virtual ICollection<Bootcamp> Bootcamps { get; set; }

    public BootcampState()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }

    public BootcampState(int id,string name):this()
    {
        Id = id;
        Name = name;
    }
}
