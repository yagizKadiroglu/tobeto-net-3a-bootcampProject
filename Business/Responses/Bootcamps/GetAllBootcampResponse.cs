namespace Business.Responses.Bootcamps;

public class GetAllBootcampResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public string InstructorFirstName { get; set; }
    public int BootcampStateId { get; set; }
    public string BootcampStateName { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
}
