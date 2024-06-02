using Web.App.xUnit.Gherkin.Tests.Web.Model;

namespace Web.App.xUnit.Gherkin.Tests.Model.RestSharp.ToolsQa;

internal interface IWebService
{
    public Task<BookIsbn> BorrowBooksFromStore(IList<BookIsbn> collectionOfIsbn);
    public Task<ReturnBookResponse> ReturnBook(string bookIsbn);
    public Task<BorrowedBooks> GetBooksLoanedToUser();
}
