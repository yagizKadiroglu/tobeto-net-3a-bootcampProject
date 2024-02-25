namespace Business.Responses.UserImages;

public class CreateUserImageResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ImagePath { get; set; }
}
