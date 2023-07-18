namespace WebBackKratek.HubConfig
{
    public interface IChatHub
    {
        Task askServerResponce(string message);
        Task ReceiveAllClients();
    }
}
