using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.Gherkin.Quick;
using Web.App.xUnit.Gherkin.Tests.Model.PageObject;
using Web.App.xUnit.Gherkin.Tests.Support;
using Web.App.xUnit.Gherkin.Tests.Support.Model;

namespace Web.App.xUnit.Gherkin.Tests.Specs;

public abstract class BaseStepDefinition: Feature
{
    private readonly BrowserFacade _browserFacade;
    protected BookStorePage? bookStorePage;

    protected BaseStepDefinition()
    {
        var builder = Host.CreateApplicationBuilder(Environment.GetCommandLineArgs());
        builder.Configuration.SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName)
            .AddJsonFile("appsettings.json", false, false);

        var desktopLaptopConfigurationSection = builder.Configuration.GetSection("WebApplication:Desktop/Laptop");
        builder.Services.Configure<DesktopLaptopBrowserConfiguration>(desktopLaptopConfigurationSection);

        _browserFacade = new BrowserFacade(desktopLaptopConfigurationSection.Get<DesktopLaptopBrowserConfiguration>()!);
        _browserFacade.SetBrowserDeviceFactory("Web").SetBrowserLaunchMode().InitializeBrowserBuilder();
        builder.Build();
    }

    [Given(@"browser loaded (.*) page")]
    public void BrowserLoadedBookStorePage(Uri bookStoreUrl)
    {
        _browserFacade.BuildBrowserDriver("firefox");
        bookStorePage = new BookStorePage(_browserFacade);
        bookStorePage.LaunchWebApp(bookStoreUrl);
    }
}
