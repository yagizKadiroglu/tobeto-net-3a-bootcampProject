namespace Business.Requests.Bootcamps;

public class CreateBootcampRequest
{
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public int BootcampStateId { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
}


