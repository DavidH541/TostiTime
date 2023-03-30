using Microsoft.AspNetCore.SignalR;

namespace TostiTime.API.HubConfig;

public class OfficeHub : Hub
{
    public async Task RefreshOffice(string officeName)
    {
        await Clients.All.SendAsync($"RefreshOffice/{officeName}");
    }
}
