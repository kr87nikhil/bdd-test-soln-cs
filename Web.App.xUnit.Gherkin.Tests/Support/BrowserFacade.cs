using OpenQA.Selenium;
using System.Collections.Concurrent;
using Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
using Web.App.xUnit.Gherkin.Tests.Support.Model;
using Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;

namespace Web.App.xUnit.Gherkin.Tests.Support;

public sealed class BrowserFacade(DesktopLaptopBrowserConfiguration configurationOption) : IWebAppFactory, IDisposable
{
    private IWebDriver? _webBrowserDriver;
    private LaunchBrowser? _launchBrowser;
    private IDeviceBrowserBuilderFactory? _browserDeviceFactory;
    private readonly Dictionary<string, BrowserDriverBuilder> _browserBuilderCollection = [];
    private readonly ConcurrentDictionary<string, IWebDriver> _browserDriverCollection = new();

    public BrowserFacade SetBrowserDeviceFactory(string deviceType)
    {
        _browserDeviceFactory = deviceType.Equals("Mobile")
            ? new MobileBrowserBuilderFactory() : new DesktopBrowserBuilderFactory(configurationOption.HeadlessExecution);
        return this;
    }

    public BrowserFacade SetBrowserLaunchMode()
    {
        if (configurationOption.SeleniumGridExecution)
        {
            _launchBrowser = new LaunchRemoteBrowser(configurationOption.SeleniumGridUrl);
        }
        else if (!string.IsNullOrEmpty(configurationOption.LocalBrowserBinaryExecutablePath))
        {
            _launchBrowser = new LaunchLocalBrowser(configurationOption.LocalBrowserBinaryExecutablePath);
        }
        else{
            _launchBrowser = new LaunchLocalManagedBrowser("");
        }
        return this;
    }

    public void InitializeBrowserBuilder()
    {
        _browserBuilderCollection.Add("chrome", _browserDeviceFactory.GetChromeBrowserDriverBuilder());
        _browserBuilderCollection.Add("edge", _browserDeviceFactory.GetEdgeBrowserDriverBuilder());
        _browserBuilderCollection.Add("firefox", _browserDeviceFactory.GetFirefoxBrowserDriverBuilder());
        _browserBuilderCollection.Add("safari", _browserDeviceFactory.GetSafariBrowserDriverBuilder());
    }

    public void BuildBrowserDriver(string browserName)
    {
        if (_browserDriverCollection.TryGetValue(browserName, value: out var webDriver))
        {
            _webBrowserDriver = webDriver;
        }
        else
        {
            _launchBrowser.DriverBuilder = _browserBuilderCollection[browserName];
            _browserDriverCollection.TryAdd(browserName, _launchBrowser.BrowserDriver!);
        }
    }

    public IWebDriver OpenApp()
    {
        return _webBrowserDriver!;
    }

    public void Dispose()
    {
        foreach(var browserDriver in _browserDriverCollection.Values)
        {
            browserDriver.Quit();
        }
    }
}
