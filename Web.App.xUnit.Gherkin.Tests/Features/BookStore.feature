# language: en
@Book @Web
Feature: Book Store
  Simple book store to issue/return book from listed books
  
  Link to a feature: [Book Store](Web.App.xUnit.Gherkin.Tests/Features/BookStore.feature)
  ![Book Store](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSuOALk_hF98vY1Dbbu-tKPuw150jDUsA3IqA&s)
  
  Background:
    Book can be issued & returned only via REST API flow
    Link to rented books information: [Borrowed Books](Web.App.xUnit.Gherkin.Tests/TestData/IssuedBooks.json)
    Given browser loaded https://demoqa.com/books page
    And I logged in as a standard user
  
  @API
  Scenario Template: Book issued from Store
  	Given <title> book is issued to User
  	When I open Profile section of Book Store Application to view issued books
  	Then <author>'s book <title> should be available
  
    Scenarios:
      | title                               | author               |
      | Git Pocket Guide                    | Richard E. Silverman |
      | Learning JavaScript Design Patterns | Addy Osmani          |
      | Understanding ECMAScript 6          | Nicholas C. Zakas    |
  
  
  @API
  Scenario: Return book to Book Store
  	Given Git Pocket Guide book is issued to User
  	When I return book with title Git Pocket Guide
  	* I open Profile section of Book Store Application to view issued books
  	Then Richard E. Silverman's book Git Pocket Guide should not be available
  
  
  Scenario Outline: Books not issued from Store
  	When I open Profile section of Book Store Application to view issued books
  	Then <author>'s book <title> should not be available
  
    Scenarios:
      | title                      | author               |
      | Git Pocket Guide           | Richard E. Silverman |
    
    @ignore
    Examples:
      | title                      | author               |
      | Order of the Phoenix       | J.K. Rowling         |
      | The Fellowship of the Ring | J. R. R. Tolkien     |
