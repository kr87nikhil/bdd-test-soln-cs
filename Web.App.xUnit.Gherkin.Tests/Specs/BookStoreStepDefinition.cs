using Xunit.Gherkin.Quick;
using Feature = Xunit.Gherkin.Quick.Feature;

namespace Web.App.xUnit.Gherkin.Tests.Web.Specs;

[FeatureFile(@"./Features/BookStore.feature")]
public sealed class BookStoreStepDefinition: Feature
{
    [Given(@"I logged in as ([-\w]*) user")]
    public void GivenILoggedInAsUser(string username)
    {
        throw new NotImplementedException();
    }

    [Given(@"([\w ]*) book is issued to User")]
    public void GivenBookIsIssuedToUser(string title)
    {
        throw new NotImplementedException();
    }

    [When(@"I open (\w*) section of ([\w ]*) to view issued books")]
    public void WhenIOpenSectionToViewIssuedBooks(string section, string group)
    {
        throw new NotImplementedException();
    }

    [When(@"I return book with title ([\w ]*)")]
    public void WhenIReturnBookWithTitle(string title)
    {
        throw new NotImplementedException();
    }

    [Then(@"([ \w.]*)'s book ([\w ]*) should (be|not be) available")]
    public void ThenBookShouldOrShouldNotBeAvailable(string author, string title, string conditionalCheck)
    {
        throw new NotImplementedException();
    }
}
