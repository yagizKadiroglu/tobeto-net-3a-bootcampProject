namespace Business.Requests.BlackLists;

public class CreateBlackListRequest
{
    public int ApplicantId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
}
