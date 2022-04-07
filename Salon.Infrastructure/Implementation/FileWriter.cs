using Salon.BusinessLayer;
using Salon.Infrastructure.Interfaces;

namespace Salon.Infrastructure.Implementation
{
    internal class FileWriter : IFileWriter
    {
        public void Write(string fileName, ClientQueue clientQueue)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(nameof(fileName));
            if (clientQueue == null) throw new ArgumentNullException(nameof(clientQueue));

            using (var stream = new StreamWriter(fileName))
            {
                var clients = clientQueue.Clients();

                foreach (var client in clients)
                {
                    var leavingTime = client.LeavingTime;

                    stream.WriteLine($"{leavingTime.Hour} {leavingTime.Minute}");
                }
            }
        }
    }
}
