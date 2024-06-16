using OpenQA.Selenium.Safari;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;
internal class SafariBrowserDriverBuilder : BrowserDriverBuilder
{
    private static readonly SafariOptions _safariDriverOptions = new();
    protected override string DRIVEREXECUTABLE { get => "safaridriver"; }

    public SafariBrowserDriverBuilder() : base(_safariDriverOptions) { }

    public override SafariDriver BuildLocalBrowser(string driverExecutablePath)
    {
        if (string.IsNullOrEmpty(driverExecutablePath))
        {
            return new(_safariDriverOptions);
        }
        var safariService = SafariDriverService.CreateDefaultService(Path.Join(driverExecutablePath, DRIVEREXECUTABLE));
        return new SafariDriver(safariService, _safariDriverOptions);
    }
}
