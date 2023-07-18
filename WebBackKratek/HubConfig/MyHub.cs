
using Microsoft.AspNetCore.SignalR;

namespace WebBackKratek.HubConfig
{
    //public class MyHub : Hub//<IChatHub>
    //{
    //    public static MyHub Instance { get; set; }

    //    public MyHub()
    //    {
    //        Instance = this;
    //    }

    //    public async Task askServer(string messageClient)
    //    {
    //        await Clients.All.SendAsync("askServerResponce",messageClient);

    //       // await Clients.All.askServerResponce(messageClient);
    //    }

    //    public async Task SendMessage()
    //    {
    //        // IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
    //        try
    //        {
    //            await Clients.All.SendAsync("aspResponceAll", "Пора обновиться");
    //        }
    //        catch(ObjectDisposedException ob)
    //        {
    //            return;
    //        }
    //        catch (Exception)
    //        {
                
    //            throw;
    //        }
           
    //    }
    //}
}
