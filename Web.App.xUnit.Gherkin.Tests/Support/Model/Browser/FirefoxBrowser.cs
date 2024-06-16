using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;
internal class FirefoxBrowser : BrowserDriverBuilder
{
    private static readonly FirefoxOptions _firefoxDriverOptions = new();
    private readonly string BROWSEREXECUTABLELOCATION = Platform.CurrentPlatform.PlatformType.Equals(PlatformType.Linux) 
        ? @"C:/Program Files/Mozilla Firefox/firefox.exe": "/usr/bin/firefox";
    protected override string DRIVEREXECUTABLE { get => "geckodriver.exe"; }

    public FirefoxBrowser(): base(_firefoxDriverOptions) { }

    public FirefoxBrowser EnableHeadless(bool enableHeadless)
    {
        if (enableHeadless)
        {
            _firefoxDriverOptions.AddArgument("-headless");
        }
        return this;
    }

    public override FirefoxDriver BuildLocalBrowser(string driverExecutablePath)
    {
        var firefoxService = FirefoxDriverService.CreateDefaultService(Path.Join(driverExecutablePath, DRIVEREXECUTABLE));
        firefoxService.LogLevel = FirefoxDriverLogLevel.Debug;
        firefoxService.OpenBrowserToolbox = true;
        _firefoxDriverOptions.BinaryLocation = BROWSEREXECUTABLELOCATION;
        return new(firefoxService, _firefoxDriverOptions);
    }

    public override FirefoxDriver BuildLocalSeleniumBrowser(string browserVersion = "beta")
    {
        if (!string.IsNullOrEmpty(browserVersion))
        {
            _firefoxDriverOptions.BrowserVersion = browserVersion;
        }
        return new(_firefoxDriverOptions);
    }
}
