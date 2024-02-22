namespace Business.Responses.Bootcamps;

public class UpdateBootcampResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public int BootcampStateId { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
