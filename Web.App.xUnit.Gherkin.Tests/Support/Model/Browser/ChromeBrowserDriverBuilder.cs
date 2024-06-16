using OpenQA.Selenium.Chrome;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;
internal class ChromeBrowserDriverBuilder : BrowserDriverBuilder
{
    private static readonly ChromeOptions _chromeDriverOptions = new();
    protected override string DRIVEREXECUTABLE { get => "chromedriver.exe"; }

    public ChromeBrowserDriverBuilder() : base(_chromeDriverOptions) { }

    public ChromeBrowserDriverBuilder EnableHeadless(bool enableHeadless)
    {
        if (enableHeadless)
        {
            _chromeDriverOptions.AddArgument("--headless");
        }
        return this;
    }

    public override ChromeDriver BuildLocalBrowser(string driverExecutablePath)
    {
        var service = ChromeDriverService.CreateDefaultService(Path.Join(driverExecutablePath, DRIVEREXECUTABLE));
        service.LogPath = Path.Join(driverExecutablePath, "logs/chromeDriver.log");
        service.EnableAppendLog = true;
        service.EnableVerboseLogging = true;
        service.DisableBuildCheck = true;
        return new(service, _chromeDriverOptions);
    }

    public override ChromeDriver BuildLocalSeleniumBrowser(string browserVersion = "beta")
    {
        if (!string.IsNullOrEmpty(browserVersion))
        {
            _chromeDriverOptions.BrowserVersion = browserVersion;
        }
        return new(_chromeDriverOptions);
    }
}
