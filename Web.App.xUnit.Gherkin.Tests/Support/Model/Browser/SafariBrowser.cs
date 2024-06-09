using OpenQA.Selenium.Safari;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;
internal class SafariBrowser(SafariOptions safariDriverOptions) : BrowserDriverBuilder(safariDriverOptions)
{
    protected override string DRIVEREXECUTABLE { get => "safaridriver"; }

    public override SafariDriver BuildLocalBrowser(string driverExecutablePath)
    {
        if (string.IsNullOrEmpty(driverExecutablePath))
        {
            return new(safariDriverOptions);
        }
        var safariService = SafariDriverService.CreateDefaultService(Path.Join(driverExecutablePath, DRIVEREXECUTABLE));
        return new SafariDriver(safariService, safariDriverOptions);
    }
}
