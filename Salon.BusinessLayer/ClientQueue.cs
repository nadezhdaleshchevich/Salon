namespace Salon.BusinessLayer
{
    public class ClientQueue
    {
        private const int ServiceTime = 20;

        private readonly List<Client> _clients = new List<Client>();

        public void AddClient(Client client)
        {
            if (_clients.Count == 0)
            {
                client.LeavingTime = client.ArrivalTime.AddMinutes(ServiceTime);
            }
            else
            {
                var waitingTime = client.ArrivalTime.AddMinutes(client.Impatience * ServiceTime);
                var lastClientLeftTime = _clients.Max(c => c.LeavingTime);

                var startWorkTime = lastClientLeftTime < client.ArrivalTime
                    ? client.ArrivalTime
                    : lastClientLeftTime;

                client.LeavingTime = startWorkTime > waitingTime
                    ? client.LeavingTime = client.ArrivalTime
                    : startWorkTime.AddMinutes(ServiceTime);
            }

            _clients.Add(client);
        }

        public List<Client> Clients()
        {
            return _clients;
        }
    }
}
