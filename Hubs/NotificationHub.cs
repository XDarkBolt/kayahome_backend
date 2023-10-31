using kayahome_backend.Contexts;
using kayahome_backend.Contexts.Sets;
using Microsoft.AspNetCore.SignalR;

namespace kayahome_backend.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly KayaHomeContext dbContext;

        public NotificationHub(KayaHomeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("OnConnected");
            return base.OnConnectedAsync();
        }

        public async Task SaveUserConnection(string username)
        {
            var connectionId = Context.ConnectionId;
            HubConnection hubConnection = new HubConnection
            {
                ConnectionId = connectionId,
                UserName = username
            };

            dbContext.HubConnection.Add(hubConnection);
            await dbContext.SaveChangesAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var hubConnection = dbContext.HubConnection.FirstOrDefault(con => con.ConnectionId == Context.ConnectionId);
            if(hubConnection != null)
            {
                dbContext.HubConnection.Remove(hubConnection);
                dbContext.SaveChanges();
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}
