using OpenQA.Selenium;
using System.Collections.Concurrent;
using Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
using Web.App.xUnit.Gherkin.Tests.Support.Model;
using Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;

namespace Web.App.xUnit.Gherkin.Tests.Support;

public class BrowserFacade(bool HeadlessMode, string browserDeviceName, LaunchBrowser launchBrowser) : IWebAppFactory
{
    private IWebDriver? webBrowserDriver;
    private readonly Dictionary<string, BrowserDriverBuilder> browserBuilderCollection = [];
    internal readonly ConcurrentDictionary<string, IWebDriver> browserDriverCollection = new();

    internal readonly IDeviceBrowserBuilderFactory BrowserDeviceFactory = 
        browserDeviceName.Equals("Mobile") ? new MobileBrowserBuilderFactory() : new DesktopBrowserBuilderFactory(HeadlessMode);

    public void InitializeBrowserBuilder()
    {
        browserBuilderCollection.Add("chrome", BrowserDeviceFactory.GetChromeBrowserDriverBuilder());
        browserBuilderCollection.Add("edge", BrowserDeviceFactory.GetEdgeBrowserDriverBuilder());
        browserBuilderCollection.Add("firefox", BrowserDeviceFactory.GetFirefoxBrowserDriverBuilder());
        browserBuilderCollection.Add("safari", BrowserDeviceFactory.GetSafariBrowserDriverBuilder());
    }

    public void SetBrowserDriver(string browserName)
    {
        if (browserDriverCollection.TryGetValue(browserName, value: out var webDriver))
        {
            webBrowserDriver = webDriver;
        }
        else
        {
            launchBrowser.DriverBuilder = browserBuilderCollection[browserName];
            browserDriverCollection.TryAdd(browserName, launchBrowser.BrowserDriver!);
        }
    }

    public IWebDriver OpenApp()
    {
        return webBrowserDriver!;
    }
}
