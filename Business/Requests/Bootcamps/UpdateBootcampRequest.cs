namespace Business.Requests.Bootcamps;

public class UpdateBootcampRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public int BootcampStateId { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
}
