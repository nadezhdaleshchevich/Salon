using Salon.BusinessLayer;

namespace Salon.Infrastructure.Interfaces
{
    public interface IFileReader
    {
        ClientQueue Read(string fileName);
    }
}
