using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
internal class MobileBrowserFactory : IDeviceBrowserFactory
{
    public EdgeBrowser GetEdgeBrowser => throw new NotImplementedException();
    public SafariBrowser GetSafariBrowser => throw new NotImplementedException();
    public ChromeBrowser GetChromeBrowser => throw new NotImplementedException();
    public FirefoxBrowser GetFirefoxBrowser => throw new NotImplementedException();
}
