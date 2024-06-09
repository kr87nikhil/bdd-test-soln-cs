using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;
internal class FirefoxBrowser(FirefoxOptions firefoxDriverOptions) : BrowserDriverBuilder(firefoxDriverOptions)
{
    private readonly string BROWSEREXECUTABLELOCATION = Platform.CurrentPlatform.PlatformType.Equals(PlatformType.Linux) 
        ? @"C:/Program Files/Mozilla Firefox/firefox.exe": "/usr/bin/firefox";
    protected override string DRIVEREXECUTABLE { get => "geckodriver.exe"; }

    public FirefoxBrowser EnableHeadless(bool enableHeadless)
    {
        if (enableHeadless)
        {
            firefoxDriverOptions.AddArgument("-headless");
        }
        return this;
    }

    public override FirefoxDriver BuildLocalBrowser(string driverExecutablePath)
    {
        var firefoxService = FirefoxDriverService.CreateDefaultService(Path.Join(driverExecutablePath, DRIVEREXECUTABLE));
        firefoxService.LogLevel = FirefoxDriverLogLevel.Debug;
        firefoxService.OpenBrowserToolbox = true;
        firefoxDriverOptions.BinaryLocation = BROWSEREXECUTABLELOCATION;
        return new(firefoxService, firefoxDriverOptions);
    }

    public override FirefoxDriver BuildLocalSeleniumBrowser(string browserVersion = "beta")
    {
        if (!string.IsNullOrEmpty(browserVersion))
        {
            firefoxDriverOptions.BrowserVersion = browserVersion;
        }
        return new(firefoxDriverOptions);
    }
}
