﻿using Online_Store.Application.Services.Users.Queries.GetUsers;

public class ResultGetUserDto
{
    public List<GetUsersDto> Users { get; set; }
    //public int Rows { get; set; }
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

}