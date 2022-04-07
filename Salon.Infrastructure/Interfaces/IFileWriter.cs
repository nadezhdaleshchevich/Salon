using Salon.BusinessLayer;

namespace Salon.Infrastructure.Interfaces
{
    public interface IFileWriter
    {
        void Write(string fileName, ClientQueue clientQueue);
    }
}
