using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Application.Services.Users.Queries.GetUsers;
using Online_Store.Common;

public class GetUsersService : IGetUsersService
{
    private readonly IDataBaseContext _context;
    public GetUsersService(IDataBaseContext context)
    {
        _context = context;
    }


    public ResultGetUserDto Execute(RequestGetUserDto request)
    {
        if (!string.IsNullOrWhiteSpace(request.SearchKey))
        {
            //تبدیل "ي" به "ی" در سرچ
            request.SearchKey = request.SearchKey.Contains("ي") ? request.SearchKey.Replace("ي", "ی") : request.SearchKey;
            //تبدیل "ئ" به "ی" در سرچ
            request.SearchKey = request.SearchKey.Contains("ئ") ? request.SearchKey.Replace("ئ", "ی") : request.SearchKey;
            //تبدیل "ك" به "ک" در سرچ
            request.SearchKey = request.SearchKey.Contains("ك") ? request.SearchKey.Replace("ك", "ک") : request.SearchKey;
            //تبدیل "ؤ" به "و" در سرچ
            request.SearchKey = request.SearchKey.Contains("ؤ") ? request.SearchKey.Replace("ؤ", "و") : request.SearchKey;
        }
        
        var users = _context.Users.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.SearchKey))
        {
            users = users.Where(p => p.FirstName.Contains(request.SearchKey) || p.LastName.Contains(request.SearchKey) || p.Email.Contains(request.SearchKey));
        }
        int rowsCount = 0;
        var usersList = users.ToPaged(request.Page, 10, out rowsCount).Select(p => new GetUsersDto
        {
            Email = p.Email,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Id = p.Id,
            IsActive=p.IsActive
        }).ToList();

        return new ResultGetUserDto
        {
            RowCount = rowsCount,
            CurrentPage= request.Page,
            PageSize = 10,
            Users = usersList,
        };
    }
}
