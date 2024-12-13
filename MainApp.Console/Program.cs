﻿using Business.Interfaces;
using Business.Services;
using Presentation.ConsoleApp.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Business.Helpers;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFileService>(new FileService("Data", "contactlist.json"));
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<IGenerateUniqeId, GenerateUniqeId>();
        services.AddTransient<IMenuDialog, MenuDialog>();

    })
    .Build();

using var scope = host.Services.CreateScope();
var mainMenu = scope.ServiceProvider.GetService<IMenuDialog>()!;
mainMenu.Run();