using Business.Interfaces;
using Business.Services;
using Presentation.ConsoleApp.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<IMenuDialog, MenuDialog>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var mainMenu = scope.ServiceProvider.GetService<IMenuDialog>()!;
mainMenu.Run();