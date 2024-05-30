using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;

namespace Web.App.xUnit.Gherkin.Tests.Drivers;

internal abstract class WebBrowser(DriverOptions driverOptions, IWebDriver webDriver): IApp
{
    public IWebDriver WebDriver { get; } = webDriver;
}

internal class EdgeBrowser(EdgeOptions edgeOptions, EdgeDriver edgeDriver): WebBrowser(edgeOptions, edgeDriver)
{
}

internal class SafariBrowser(SafariOptions safariOptions, SafariDriver safariDriver): WebBrowser(safariOptions, safariDriver)
{
}

internal class ChromeBrowser(ChromeOptions chromeOptions, ChromeDriver chromeDriver): WebBrowser(chromeOptions, chromeDriver)
{
}
