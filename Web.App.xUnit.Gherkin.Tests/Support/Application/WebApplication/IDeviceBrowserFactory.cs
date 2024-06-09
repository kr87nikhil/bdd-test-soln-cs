using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
internal interface IDeviceBrowserFactory
{
    public abstract EdgeBrowser GetEdgeBrowser { get; }
    public abstract SafariBrowser GetSafariBrowser { get; }
    public abstract ChromeBrowser GetChromeBrowser { get; }
    public abstract FirefoxBrowser GetFirefoxBrowser { get; }
}