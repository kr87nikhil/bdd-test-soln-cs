#Language: en-UK
@Book @Web
Feature: Book Store
Simple book store to issue/return book from listed books

Link to a feature: [BookStore](Web.App.xUnit.Gherkin.Tests/Features/BookStore.feature)
![Book Store](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSuOALk_hF98vY1Dbbu-tKPuw150jDUsA3IqA&s)

Background:
  Given I navigate to https://demoqa.com page
  And logged in as dotnet-demo user

@API
Scenario Outline: Book issued from Book Store
	Given <title> book is issued to User
	When I open <Profile> section of <Book Store Application> to view issued books
	Then <author>'s book <title> should be available

Examples:
| title                               | author               |
| Git Pocket Guide                    | Richard E. Silverman |
| Learning JavaScript Design Patterns | Addy Osmani          |
| Understanding ECMAScript 6          | Nicholas C. Zakas    |


@API
Scenario: Return book to Book Store
	Given Git Pocket Guide book is issued to User
	When I return book with title Git Pocket Guide
	And I open <Profile> section of <Book Store Application> to view issued books
	Then Richard E. Silverman's book Git Pocket Guide should not be available


Scenario Outline: Books not issued to User
	When I open <Profile> section of <Book Store Application> to view issued books
	Then <author>'s book <title> should not be available

Examples:
| title                      | author               |
| Git Pocket Guide           | Richard E. Silverman |
| Order of the Phoenix       | J.K. Rowling         |
| The Fellowship of the Ring | J. R. R. Tolkien     |
