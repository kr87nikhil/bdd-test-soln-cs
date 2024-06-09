using OpenQA.Selenium.Edge;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;
internal class EdgeBrowser(EdgeOptions edgeDriverOptions) : BrowserDriverBuilder(edgeDriverOptions)
{
    protected override string DRIVEREXECUTABLE { get => "msedgedriver.exe"; }

    public EdgeBrowser EnableHeadless(bool enableHeadless)
    {
        if (enableHeadless)
        {
            edgeDriverOptions.AddArgument("--headless");
        }
        return this;
    }

    public override EdgeDriver BuildLocalBrowser(string driverExecutablePath)
    {
        var edgeService = EdgeDriverService.CreateDefaultService(Path.Join(driverExecutablePath, DRIVEREXECUTABLE));
        edgeService.LogPath = Path.Join(driverExecutablePath, "logs/edgeDriver.log");
        edgeService.EnableAppendLog = true;
        edgeService.EnableVerboseLogging = true;
        return new(edgeService, edgeDriverOptions);
    }

    public override EdgeDriver BuildLocalSeleniumBrowser(string browserVersion = "beta")
    {
        if (!string.IsNullOrEmpty(browserVersion))
        {
            edgeDriverOptions.BrowserVersion = browserVersion;
        }
        return new(edgeDriverOptions);
    }
}
