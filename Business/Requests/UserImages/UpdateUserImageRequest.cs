namespace Business.Requests.UserImages;

public class UpdateUserImageRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ImagePath { get; set; }
}
