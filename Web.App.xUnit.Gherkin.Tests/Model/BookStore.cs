using System.Text.Json.Serialization;

namespace Web.App.xUnit.Gherkin.Tests.Web.Model;

internal record Login(string UserName, string Password);
/// <summary>
/// Receives Generated Token & User Id of logged in User
/// </summary>
/// <param name="Password">Private accessor to restrict external usage</param>
internal record GeneratedToken(string UserId, string Username, string Password, string Token, DateTime Expires, 
    [property: JsonPropertyName("created_date")] DateTime CreatedDate, bool IsActive);

internal record BookIsbn(string Isbn);
internal record BookRequest(string UserId, IList<BookIsbn> CollectionOfIsbns);
internal record ReturnRequest(string UserId, string Isbn);

internal record Book(string Isbn, string Title, string SubTitle, string Author, 
    [property: JsonPropertyName("publish_date")] DateTime PublishDate, string Publisher, int Pages, string Description, Uri Website);
internal record BorrowedBooks(string UserId, string Username, IList<Book> Books);
