using Autofac;
using Salon.Infrastructure.Implementation;
using Salon.Infrastructure.Interfaces;

namespace Salon.Infrastructure
{
    public static class Infrastructure
    {
        public static void AddInfrastructure(this ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.RegisterType<FileReader>().As<IFileReader>();
            builder.RegisterType<FileWriter>().As<IFileWriter>();
        }
    }
}
