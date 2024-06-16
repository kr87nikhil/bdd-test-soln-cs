using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
internal class DesktopBrowserBuilderFactory(bool HeadlessMode) : IDeviceBrowserBuilderFactory
{
    public EdgeBrowserDriverBuilder GetEdgeBrowserDriverBuilder() => new EdgeBrowserDriverBuilder().EnableHeadless(HeadlessMode);
    public SafariBrowserDriverBuilder GetSafariBrowserDriverBuilder() => new();
    public ChromeBrowserDriverBuilder GetChromeBrowserDriverBuilder() => new ChromeBrowserDriverBuilder().EnableHeadless(HeadlessMode);
    public FirefoxBrowserDriverBuilder GetFirefoxBrowserDriverBuilder() => new FirefoxBrowserDriverBuilder().EnableHeadless(HeadlessMode);
}
