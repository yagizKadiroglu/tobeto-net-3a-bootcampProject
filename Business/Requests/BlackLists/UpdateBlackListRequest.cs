namespace Business.Requests.BlackLists;

public class UpdateBlackListRequest
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
}
