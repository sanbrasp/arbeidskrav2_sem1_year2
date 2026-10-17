# Dice Throw Cafe
_(Translated from Norwegian to English)_

TODO: DELETE WHEN FINISHED!  
#### Requirements
- `GameCard` receives the game as a parameter (currently six separate values, not one `BoardGame`)
- ~~README.md: responsibility of the page and `GameCard`, and why they are split this way~~
- Responsibility table written (what)
- ~~Why written~~

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
- ~~Search for an existing game, in both lowercase and uppercase~~
- ~~Search for something that doesn't exist: clear message shown~~
- ~~"Roll the dice" does not crash when there are no matches~~
- ~~Player filter boundaries: a 2-4 player game shows for 2 and 4, not for 1 or 5~~
- ~~Search and filter combined: hit count is correct~~
- ~~Clear the search field: whole collection shows again~~

#### Delivery
- ~~The page~~
- ~~The component~~
- ~~Test results (in README)~~
- ~~Division of responsibilities described in README.md~~

#### Tip from the assignment
- ~~Filtering gathered in one property in C#~~
- ~~Filter still in one place after adding the player filter~~

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

**Pages and Components:**  

| Part                   | Does                                                                                                                                                                                                                            | Does not                                                             |
|------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------|
| `Home.razor`           | Dice Throw Café home page. Welcomes the user.                                                                                                                                                                                   |                                                                      |
| `GameRepository.cs`    | Owns the list, hands it out as read-only, owns IDs.                                                                                                                                                                             | Knows nothing about pages or search.                                 |
| `Games.razor`          | Displays the library of games, allows search and filtering. Asks the repository for the games in `OnInitialized`, holds the search text, filters in one property, loops, and shows empty states (no result / empty games list). | Does not own or create games.                                        |
| `GameCard.razor`       | Shows one game per card.                                                                                                                                                                                                        | Does not know the list, the search, or the repository.               |
| `GameFilterService.cs` | Handles real-time filtering on letters and number of players.                                                                                                                                                                   | Does not know where the data comes from.                             |
| `GameRandomizer.cs`    | Handles the choice of a random game based on the current view the user sees.                                                                                                                                                    | Does not know about anything but the games list.                     |
| `BoardGame.cs`         | The model for a board game. Validates its own rating (1 - 6).                                                                                                                                                                   | Does not know anything about the other classes, pages or components. |

**Why Page and Component are split**  
`GameCard` (component) and `Games` (page) are split because it is a more practical way to display and maintain 
the game information. The `GameCard` is a reusable component that can easily be used on any page.  

The page, `Games.razor`, is responsible for displaying the `GameCard` and looping over the contents of the list received through 
`GameRepository`. It displays buttons, search field, dropdown menu for number of players, and the `GameCard`.  
It handles the button `@onclick` and displays the number of search hits. It also has logic for empty lists and non-results.

The component, `GameCard.razor`, is responsible for the information in each card, and uses Parameter properties 
which are passed down from the parent (`Games`) to the card, and correspond with the `BoardGame` model which every board game uses.  
`GameCard` also handles the highlighting of a picked card, and is told by the page whether it is the picked card. 
The page compares each game with the picked one and passes `IsPickedCard`. The card decides how the picked card looks.
It knows nothing about the list, the search, or the repository.

If I want to change how a card looks, I only have to change `GameCard`, because the page only displays the `GameCard`.  
If I add a new field to `BoardGame`, I have to change the `BoardGame constructor`, the `RegisterNewBoardGame` signature, 
the calls to `RegisterNewBoardGame`, and the tests that create games. I also have to change `Games.razor` and `GameCard`
because the page needs to pass the new value, and the card needs a new parameter to show it.      
This is the cost of the six separate parameters, but it keeps the card independent of `BoardGame`.

**Test Results:**  
Refer to the documentation in [Test Suite README](../SoftwareDesign.Tests/README.md)

**Design Choices:**  
Refer to the documentation in [DesignChoices.md](../Docs/DesignChoices.md)

**AI Assistance Documentation:**  
Refer to the documentation in [AIUse.md](../Docs/AIUse.md)

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
- [Test Documentation](../SoftwareDesign.Tests/README.md)

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