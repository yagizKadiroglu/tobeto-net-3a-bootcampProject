namespace Business.Responses.BlackLists;

public class DeleteBlackListResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
}


