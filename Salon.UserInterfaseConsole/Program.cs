using Autofac;
using Salon.Infrastructure;
using Salon.Infrastructure.Interfaces;

var builder = new ContainerBuilder();

builder.AddInfrastructure();

var container = builder.Build();

var reader = container.Resolve<IFileReader>();
var writer = container.Resolve<IFileWriter>();

var clientQueue = reader.Read("salon.in");

writer.Write("salon.out", clientQueue);

Console.ReadKey();