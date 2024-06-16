using OpenQA.Selenium.Edge;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;
internal class EdgeBrowserDriverBuilder: BrowserDriverBuilder
{
    protected static readonly EdgeOptions _edgeDriverOptions = new();
    protected override string DRIVEREXECUTABLE { get => "msedgedriver.exe"; }

    public EdgeBrowserDriverBuilder() : base(_edgeDriverOptions) { }

    public EdgeBrowserDriverBuilder EnableHeadless(bool enableHeadless)
    {
        if (enableHeadless)
        {
            _edgeDriverOptions.AddArgument("--headless");
        }
        return this;
    }

    public override EdgeDriver BuildLocalBrowser(string driverExecutablePath)
    {
        var edgeService = EdgeDriverService.CreateDefaultService(Path.Join(driverExecutablePath, DRIVEREXECUTABLE));
        edgeService.LogPath = Path.Join(driverExecutablePath, "logs/edgeDriver.log");
        edgeService.EnableAppendLog = true;
        edgeService.EnableVerboseLogging = true;
        return new(edgeService, _edgeDriverOptions);
    }

    public override EdgeDriver BuildLocalSeleniumBrowser(string browserVersion = "beta")
    {
        if (!string.IsNullOrEmpty(browserVersion))
        {
            _edgeDriverOptions.BrowserVersion = browserVersion;
        }
        return new(_edgeDriverOptions);
    }
}
