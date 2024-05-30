using OpenQA.Selenium;
using Web.App.xUnit.Gherkin.Tests.Drivers;

namespace Web.App.xUnit.Gherkin.Tests.Model.PageObject;

internal class BookStorePage(WebBrowser webBrowser)
{
    private readonly IWebDriver _webDriver = webBrowser.WebDriver;
    internal readonly By bookStoreCategory = By.CssSelector("div.category-cards div.card:nth-child(6)");
    internal readonly By loginButton = By.CssSelector("button#login");
    internal readonly By userNameInput = By.CssSelector("input#userName");
    internal readonly By passwordInput = By.CssSelector("input#password");
    internal readonly By userNameLabelAfterLogin = By.CssSelector("label#userName-value");
    internal readonly By logOutButton = By.CssSelector("div#books-wrapper button#submit");

    internal readonly By groupHeader = By.CssSelector("div.left-pannel span.group-header");
    internal readonly By groupHeaderText = By.CssSelector("div.header-text");
    internal readonly By groupSectionName = By.CssSelector("+ div.element-list li");

    internal readonly By listOfBookTitle = By.CssSelector("div.rt-table div.rt-tbody div.rt-td:nth-child(2)");
    internal readonly By bookAuthor = By.CssSelector("+ div.rt-td");
    internal readonly By bookPublisher = By.CssSelector("+ div.rt-td + div.rt-td");

    public void LaunchWebApp(Uri toolsQaBookStoreUrl)
    {
        _webDriver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromMinutes(2));
        _webDriver.Navigate().GoToUrl(toolsQaBookStoreUrl);
        _webDriver.FindElement(bookStoreCategory).Click();
    }

    /// <summary>
    /// Login into Book Library
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>Label for logged in User</returns>
    public string PerformLogin(string username, string password)
    {
        _webDriver.FindElement(loginButton).Click();
        _webDriver.FindElement(userNameInput).SendKeys(username);
        _webDriver.FindElement(passwordInput).SendKeys(password);
        _webDriver.FindElement(loginButton).Click();
        return _webDriver.FindElement(userNameLabelAfterLogin).Text;
    }

    public void PerformLogOut()
    {
        _webDriver.FindElement(logOutButton).Click();
    }

    public void OpenSectionUnderGroup(string groupName, string sectionName)
    {
        var sectionElement = GetSectionElementInGroup(groupName, sectionName);
        sectionElement.Click();
    }

    public IDictionary<string, IList<string>> GetListOfIssuedBooks()
    {
        var titleAuthorPublisherMap = new Dictionary<string, IList<string>>();
        var bookTitles = _webDriver.FindElements(listOfBookTitle)
            .Where(element => !string.IsNullOrEmpty(element.Text)).GroupBy(element => element.Text).ToList();
        foreach (var bookTitle in bookTitles)
        {
            var bookTitleElement = bookTitle.First();
            titleAuthorPublisherMap.Add(bookTitle.Key,
            [
                bookTitleElement.FindElement(bookAuthor).Text,
                bookTitleElement.FindElement(bookPublisher).Text
            ]);
        }
        return titleAuthorPublisherMap;
    }

    /// <summary>
    /// Handle cases where provided group/section is not available
    /// </summary>
    /// <param name="groupName"></param>
    /// <param name="sectionName"></param>
    /// <returns>Section element matching provided parameter</returns>
    /// <exception cref="ElementNotVisibleException"></exception>
    private IWebElement GetSectionElementInGroup(string groupName, string sectionName)
    {
        var groupElements = _webDriver.FindElements(groupHeader)
                .Where(element => element.FindElement(groupHeaderText).Text == groupName).ToList();
        if (!groupElements.Any())
        {
            throw new ElementNotVisibleException($"No element visible: Left-pannel group<{groupName}>");
        }
        var groupElement = groupElements.First();
        var headerElement = groupElement.FindElement(groupHeaderText);
        var sectionElements = from element in groupElement.FindElements(groupSectionName)
                              where element.Text == sectionName
                              select element;
        if (!sectionElements.Any())
        {
            throw new ElementNotVisibleException($"No element visible: {sectionName} within left-pannel group<{groupName}>");
        }
        if (!headerElement.GetAttribute("class").Contains("show"))
        {
            headerElement.Click();
        }
        return sectionElements.First();
    }
}
