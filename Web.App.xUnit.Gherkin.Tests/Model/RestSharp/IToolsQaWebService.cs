using Web.App.xUnit.Gherkin.Tests.Web.Model;

namespace Web.App.xUnit.Gherkin.Tests.Model.RestSharpClient;
    
internal interface IToolsQaWebService
{
    public Task<BookIsbn> BorrowBooksFromStore(IList<BookIsbn> collectionOfIsbn);
    public Task<ReturnBookResponse> ReturnBook(string bookIsbn);
    public Task<BorrowedBooks> GetBooksLoanedToUser();
}
