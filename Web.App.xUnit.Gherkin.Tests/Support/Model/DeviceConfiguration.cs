namespace Web.App.xUnit.Gherkin.Tests.Support.Model;

public record DesktopLaptopBrowserConfiguration
{
    public required bool HeadlessExecution { get; set; }
    public required Uri SeleniumGridUrl { get; set; }
    public required bool SeleniumGridExecution { get; set; }
    public required IList<BrowserConfiguration> LocalBrowser { get; set; }
    public required string LocalBrowserBinaryExecutablePath { get; set; }
}

public record BrowserConfiguration
{
    public required string Name { get; set; }
    public string? Version { get; set; }
    public string? DriverVersion { get; set; }
}
