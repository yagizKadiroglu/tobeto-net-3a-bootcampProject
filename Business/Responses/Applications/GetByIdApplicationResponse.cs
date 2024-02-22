namespace Business.Responses.Applications;

public class GetByIdApplicationResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string ApplicantFirstName { get; set; }
    public int BootcampId { get; set; }
    public string BootcampName { get; set; }
    public int ApplicationStateId { get; set; }
    public string ApplicationStateName { get; set; }
    public DateTime UpdatedDate { get; set; }

}



