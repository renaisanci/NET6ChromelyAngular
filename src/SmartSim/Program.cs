// See https://aka.ms/new-console-template for more information
using Chromely;
using Chromely.Core.Configuration;
using Chromely.Core;
using Chromely.NativeHosts;
using Microsoft.Extensions.DependencyInjection;
using SmartSim;

//Console.WriteLine("Hello, World!");



// Copyright © 2017 Chromely Projects. All rights reserved.
// Use of this source code is governed by MIT license that can be found in the LICENSE file.

var config = DefaultConfiguration.CreateForRuntimePlatform();
config.StartUrl = "local://dist/smartsim-ui/index.html";

ThreadApt.STA();

AppBuilder
    .Create(args)
    .UseConfig<DefaultConfiguration>(config)
    .UseApp<DemoApp>()
    .Build()
    .Run();

public class DemoApp : ChromelyBasicApp
{
    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
      

        /*
        // Optional - adding custom handler
        services.AddSingleton<CefDragHandler, CustomDragHandler>();
        */

        /*
        // Optional- using config section to register IChromelyConfiguration
        // This just shows how it can be used, developers can use custom classes to override this approach
        //
        var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

        var configuration = builder.Build();
        var config = DefaultConfiguration.CreateFromConfigSection(configuration);
        services.AddSingleton<IChromelyConfiguration>(config);
        */

        /* Optional
        var options = new JsonSerializerOptions();
        options.ReadCommentHandling = JsonCommentHandling.Skip;
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.AllowTrailingCommas = true;
        services.AddSingleton<JsonSerializerOptions>(options);
        */

        RegisterChromelyControllerAssembly(services, typeof(MovieController).Assembly);
    }
}