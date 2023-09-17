using Online_Store.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Online_Store.Application.Services.Users.Queries.GetUsers;
using Online_Store.Persistence.Contexts;
using Online_Store.Application.Services.Users.Queries.GetRoles;
using Online_Store.Application.Services.Users.Commands.EditUser;
using Online_Store.Application.Services.Users.Commands.RegisterUser;
using Online_Store.Application.Services.Users.Commands.RemoveUser;
using Online_Store.Application.Services.Users.Commands.UserLogin;
using Online_Store.Application.Services.Users.Commands.UserSatusChange;
using Microsoft.AspNetCore.Authentication.Cookies;
using Online_Store.Application.Interfaces.FacadPatterns;
using Online_Store.Application.Services.Products.FacadPattern;
using Online_Store.Application.Services.Common.Queries.GetHomePageImages;
using Online_Store.Application.Services.Common.Queries.GetSlider;
using Online_Store.Application.Services.HomePages.Commands.AddNewSlider;
using Online_Store.Application.Services.HomePages.Commands.AddHomePageImages;
using Online_Store.Application.Services.Carts;
using Online_Store.Application.Services.Fainances.Commands.AddRequestPay;
using Online_Store.Common.Roles;
using Online_Store.Application.Services.Fainances.Queries.GetRequestPayService;
using Online_Store.Application.Services.Orders.Commands.AddNewOrder;
using Online_Store.Application.Services.Orders.Queries.GetUserOrders;
using Online_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Online_Store.Application.Services.Fainances.Queries.GetRequestPayForAdmin;
using Online_Store.Application.Services.Products.Queries.GetParentCategory;
using Online_Store.Application.Services.Products.Queries.GetMenuItem;
using Online_Store.Application.Services.Orders.Commands.OrderStatusChange;
using Online_Store.Application.Services.Fainances.Commands.EditAuthorityRequestPayService;
using Online_Store.Application.Services.Products.Commands.EditProduct;
using Online_Store.Application.Services.Products.Commands.RemoveProduct;
using EndPoint.Hubs;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
    options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
    options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.warehouse_keeper));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});


// Add services to the container
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();

//FacadeInject
builder.Services.AddScoped<IProductFacad, ProductFacad>();

//--------------------------------
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetParentCategoryService, GetParentCategoryService>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
builder.Services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddRequestPayService, AddRequestPayService>();
builder.Services.AddScoped<IGetRequestPayService, GetRequestPayService>();
builder.Services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();
builder.Services.AddScoped<IEditAuthorityRequestPayService, EditAuthorityRequestPayService>();



builder.Services.AddScoped<IAddNewOrderService, AddNewOrderService>();
builder.Services.AddScoped<IEditOrderService, EditOrderService>();
builder.Services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
builder.Services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
builder.Services.AddScoped<IOrderStatusChangeService, OrderStatusChangeService>();

builder.Services.AddScoped<IEditProductService, EditProductService>();
builder.Services.AddScoped<IRemoveProductService, RemoveProductService>();

builder.Services.AddSignalR();

string PicturesUploadPath = $@"E:\";
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(PicturesUploadPath));            //uploadpath


builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
string contectionString = @"Data Source=DESKTOP-7FRVFH5\MSSQLSERVERLAB; Initial Catalog=Online_StoreDb; Integrated Security=True;TrustServerCertificate=True";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(contectionString));
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
       name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

});

app.MapHub<ChatHub>("/chatHub");

app.Run();
