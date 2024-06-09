using OpenQA.Selenium.Chrome;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;
internal class ChromeBrowser(ChromeOptions chromeDriverOptions) : BrowserDriverBuilder(chromeDriverOptions)
{
    protected override string DRIVEREXECUTABLE { get => "chromedriver.exe"; }

    public ChromeBrowser EnableHeadless(bool enableHeadless)
    {
        if (enableHeadless)
        {
            chromeDriverOptions.AddArgument("--headless");
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
        return new(service, chromeDriverOptions);
    }

    public override ChromeDriver BuildLocalSeleniumBrowser(string browserVersion = "beta")
    {
        if (!string.IsNullOrEmpty(browserVersion))
        {
            chromeDriverOptions.BrowserVersion = browserVersion;
        }
        return new(chromeDriverOptions);
    }
}
