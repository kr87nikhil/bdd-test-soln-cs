using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
internal class DesktopBrowserFactory(DriverOptions WebDriverOptions, bool HeadlessMode) : IDeviceBrowserFactory
{
    public EdgeBrowser GetEdgeBrowser =>
        new EdgeBrowser((EdgeOptions)WebDriverOptions).EnableHeadless(HeadlessMode);

    public SafariBrowser GetSafariBrowser => new((SafariOptions)WebDriverOptions);

    public ChromeBrowser GetChromeBrowser =>
        new ChromeBrowser((ChromeOptions)WebDriverOptions).EnableHeadless(HeadlessMode);

    public FirefoxBrowser GetFirefoxBrowser =>
        new FirefoxBrowser((FirefoxOptions)WebDriverOptions).EnableHeadless(HeadlessMode);
}
