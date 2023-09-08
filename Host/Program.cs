// See https://aka.ms/new-console-template for more information

using Database;
using Microsoft.Extensions.Hosting;
using Oakton;

await Host.CreateDefaultBuilder(args)
	.ApplyOaktonExtensions()
	.ConfigureServices(services =>
	{
		services.AddDatabase();
	})
	.Build()
	.RunOaktonCommands(args);
