using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
internal class DesktopBrowserBuilderFactory(bool HeadlessMode) : IDeviceBrowserBuilderFactory
{
    public EdgeBrowser GetEdgeBrowserBuilder() => new EdgeBrowser().EnableHeadless(HeadlessMode);
    public SafariBrowser GetSafariBrowserBuilder() => new();
    public ChromeBrowser GetChromeBrowserBuilder() => new ChromeBrowser().EnableHeadless(HeadlessMode);
    public FirefoxBrowser GetFirefoxBrowserBuilder() => new FirefoxBrowser().EnableHeadless(HeadlessMode);
}
