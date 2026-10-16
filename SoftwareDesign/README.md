# Dice Throw Cafe
_(Translated from Norwegian to English)_

TODO: DELETE WHEN FINISHED!  
#### Requirements
- `GameCard` receives the game as a parameter (currently six separate values, not one `BoardGame`)
- README.md: responsibility of the page and `GameCard`, and why they are split this way
- Responsibility table written (what)
- Why written

- ~~Page `/games` shows all games in the collection~~
- ~~List lives in its own class, not in the component (`GameRepository`)~~
- ~~`GameCard` component shows one game~~
- ~~`GameCard` is not responsible for the list~~
- ~~List displayed with `@foreach`~~
- ~~`@if` shows different content for matches vs. empty list~~
- ~~Search field bound with `@bind`, filters by name while typing~~
- ~~Search is case-insensitive~~
- ~~Player count filter (shown when the count is between `MinPlayers` and `MaxPlayers`)~~
- ~~Hit count shown, updates when search or filter changes~~
- ~~"Roll the dice" button picks a random game among the matches~~
- ~~Picked game is highlighted~~
- ~~Button uses `@onclick`~~

#### Collection
- ~~At least eight games (added 11)~~

#### Test cases and edge cases
- Search for an existing game, in both lowercase and uppercase
- Search for something that doesn't exist: clear message shown
- "Roll the dice" does not crash when there are no matches
- Player filter boundaries: a 2-4 player game shows for 2 and 4, not for 1 or 5
- Search and filter combined: hit count is correct
- Clear the search field: whole collection shows again

#### Delivery
- ~~The page~~
- ~~The component~~
- Test results (in README)
- Division of responsibilities described in README.md

#### Tip from the assignment
- ~~Filtering gathered in one property in C#~~
- Filter still in one place after adding the player filter

#### Assessed
- Interface split into components with clear responsibilities
- Data binding and events used correctly
- Edge cases handled
- Code easy to read and change

#### Notes for later
- Filter runs twice per render (known limitation, accepted at this size)
- `GameCard` six parameters instead of one `BoardGame`
- Player count filter and dice add more state to the page: watch the size of `@code`

---

## Overview
- [Tasks](#tasks)
    - [Task 1 - Game Shelf](#game-shelf)
    - [Task 2 - Dice Throw and Game Page](#dice-throw-and-game-page)
    - [Task 3 - My Game Night](#my-game-night)
    - [Task 4 - Behind the Counter](#behind-the-counter)
    - [Task 5 - Design Documentation, Choices, and Testing](#design-documentation-design-choices-and-testing)
    - [Task 6 - Video Presentation](#video)
- [Sources](#sources)

---

## Tasks
### Game Shelf
**Task 1:  
Components and data binding.**  
~~page, component~~, test results, ~~responsibilities~~

**Pages and Components:**  

| Part                   | Does                                                                                                                                                                                                                                        | Does not                                                             |
|------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------|
| `Home.razor`           | Dice Throw Café home page. Welcomes the user.                                                                                                                                                                                               |                                                                      |
| `GameRepository.cs`    | Owns the list, hands it out as read-only, own IDs.                                                                                                                                                                                          | Knows nothing about pages or search.                                 |
| `Games.razor`          | Displays the library of games, allows the user to search for a game. It asks the repository for the games in `OnInitialized`, holds the search text, filters in one property, loops, and shows empty states (no result / empty games list). | Does not own or create games.                                        |
| `GameCard.razor`       | Shows one game per card.                                                                                                                                                                                                                    | Does not know the list, the search, or the repository.               |
| `GameFilterService.cs` | Handles real-time filtering on letters and number of players.                                                                                                                                                                               | Does not know where the data comes from.                             |
| `GameRandomizer.cs`    | Handles the choice of a random game based on the current view the user sees.                                                                                                                                                                | Know about anything but the games list.                              |
| `BoardGame.cs`         | The model for a board game.                                                                                                                                                                                                                 | Does not know anything about the other classes, pages or components. |


**Test Results:**  
TODO: Test results here. Screenshots and such.

**Design Choices**  
Documentation found [here](../Docs/DesignChoices.md)

---

### Dice-Throw and Game Page
Task 2:  
Component communication and navigation.

---

### My Game Night
Task 3:  
Application state and responsive UI.

---

### Behind The Counter
Task 4:  
HttpClient and CRUD against Rest API.

---

## Design Documentation, Design Choices, and Testing
Task 5:  
Each subject has its own document, located in solution root directory `Docs`.  

- [Design Documentation](../Docs/DesignDocumentation.md)
- [Design Choices](../Docs/DesignChoices.md)
- [Test Documentation](../Docs/TestDocumentation.md)

---

## Video
Video presentation will be available in the submission link, but not in the repo.  

[Video Presentation](../Task6_Video/presentation.mp4) (TODO: Ensure name is correct!)

---

## Sources

| Subject                                        | URL                                                                                                                     |
|------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------|
| **Using Max on Enumerable collection:**        | https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.max?view=net-10.0                                   |
| **DefaultIfEmpty:**                            | https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.defaultifempty?view=net-10.0                        |
| **Refresher on Expression bodied definition:** | https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator#expression-body-definition |
| **IEnumerable Any():**                         | https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=net-10.0                                   |
| **Blazor Render Modes:**                       | https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0                       |
| **Blazor data binding:**                       | https://learn.microsoft.com/en-us/aspnet/core/blazor/components/data-binding?view=aspnetcore-10.0                       |
| **Refresher on ternary conditional operator:** | https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator                       |
| **Enumerable.Count:**                          | https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count?view=net-10.0                                 |
| **Blazor Event Handling:**                     | https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-10.0                     |
| **CSS borders:**                               | https://developer.mozilla.org/en-US/docs/Web/CSS/Reference/Properties/border                                            |
| **CSS Box Shadows:**                           | https://developer.mozilla.org/en-US/docs/Web/CSS/Reference/Properties/box-shadow                                        |
| **CSS background color:**                      | https://developer.mozilla.org/en-US/docs/Web/CSS/Reference/Properties/background-color                                  |
| **Select Box Binding:**                        | https://stackoverflow.com/questions/58485439/select-box-binding-in-blazor                                               |
| **CSS Text Color:**                            | https://www.w3schools.com/css/css_text.asp                                                                              |