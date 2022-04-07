using Salon.BusinessLayer;
using Salon.Infrastructure.Interfaces;

namespace Salon.Infrastructure.Implementation
{
    internal class FileReader : IFileReader
    {
        public ClientQueue Read(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(nameof(fileName));

            var clientQueue = new ClientQueue();

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            using var stream = new StreamReader(fileName);
            int n = Convert.ToInt32(stream.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var lineRead = stream.ReadLine().Split(' ');

                int hour = Convert.ToInt32(lineRead[0]);
                int minute = Convert.ToInt32(lineRead[1]);
                int impatience = Convert.ToInt32(lineRead[2]);

                var client = new Client
                {
                    ArrivalTime = new DateTime(year, month, day, hour, minute, 0),
                    Impatience = impatience
                };

                clientQueue.AddClient(client);
            }

            return clientQueue;
        }
    }
}
