using Microsoft.AspNetCore.SignalR;

namespace BisleriumBlog.WebAPI.Helper
{
    public class Notification : Hub
    {
        public async Task SendMessagem(string messsage)
        {
            // Sent Message
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", messsage);
        }
    }
}
