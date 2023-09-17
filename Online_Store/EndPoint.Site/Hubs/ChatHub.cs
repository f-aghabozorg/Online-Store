using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.SignalR;
using Online_Store.Domain.Entities.Users;
using OnlineStore.Persistence.Migrations;
using System.Security.Claims;

namespace EndPoint.Hubs;

public class ChatHub : Hub
{
    public static int useronline = 0;
    public async Task SendMessage(string user,string message)
    {
        await Clients.All.SendAsync("ReceiveMessage",user, message);
    }
    public override async Task OnConnectedAsync()
    {
        useronline++;
        await Clients.All.SendAsync("userconnect", useronline);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        useronline--;
        await Clients.All.SendAsync("userdisconnect", useronline);
        await base.OnDisconnectedAsync(exception);
    }

}