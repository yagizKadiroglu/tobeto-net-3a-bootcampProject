﻿namespace Business.Responses.UserImages;

public class UpdateUserImageResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ImagePath { get; set; }
}
