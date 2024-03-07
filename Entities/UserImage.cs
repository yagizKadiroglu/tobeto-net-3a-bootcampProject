using Core.Entities;

namespace Entities;

public class UserImage:BaseEntity<int>
{
    public int UserId { get; set; }
    public string ImagePath { get; set; }


    public UserImage()
    {
        
    }
    public UserImage(int id,int userId, string ımagePath)
    {
        Id = id;
        UserId = userId;
        ImagePath = ımagePath;
    }
}
