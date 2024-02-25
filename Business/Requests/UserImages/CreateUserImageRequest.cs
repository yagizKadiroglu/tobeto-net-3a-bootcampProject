namespace Business.Requests.UserImages;

public class CreateUserImageRequest
{
    public int UserId { get; set; }
    public string ImagePath { get; set; }
}
