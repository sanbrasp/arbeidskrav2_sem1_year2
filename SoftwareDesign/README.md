# Dice Throw Café
_(Translated from Norwegian to English)_

### TASK 2 BULLET LIST (DELETE WHEN DONE)

#### Test cases and edge cases
- ~~`/games/1` and a missing ID (`/games/9999`)~~
- ~~`/games/abc`: explain why it does not match the game page~~
- ~~Click rating 1 and 6 on the game page: the parent gets the right value~~
- ~~`ReadOnly` ignores clicks~~
- Value outside 1–6 into `DiceRating`: define and document what it shows
- ~~Menu highlighting follows the current page~~

#### Delivery
- README: parameters and events of `DiceRating` and `GameCard`
- Test results

#### Notes for later
- Task 3 fills in My Game Night
- Task 4 saves the rating

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

| Part                                  | Does                                                                                                                                                                                                                            | Does not                                                             |
|---------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------|
| `Home.razor`                          | Dice Throw Café home page. Welcomes the user.                                                                                                                                                                                   |                                                                      |
| `GameRepository.cs`                   | Owns the list, hands it out as read-only, owns IDs.                                                                                                                                                                             | Knows nothing about pages or search.                                 |
| `GameRepository.RegisterNewBoardGame` | Registers a new game and assigns an ID to the game during creation.                                                                                                                                                             |                                                                      |
| `Games.razor`                         | Displays the library of games, allows search and filtering. Asks the repository for the games in `OnInitialized`, holds the search text, filters in one property, loops, and shows empty states (no result / empty games list). | Does not own or create games.                                        |
| `GameCard.razor`                      | Shows one game per card.                                                                                                                                                                                                        | Does not know the list, the search, or the repository.               |
| `GameFilterService.cs`                | Handles real-time filtering on letters and number of players.                                                                                                                                                                   | Does not know where the data comes from.                             |
| `GameRandomizer.cs`                   | Handles the choice of a random game based on the current view the user sees.                                                                                                                                                    | Does not know about anything but the games list.                     |
| `BoardGame.cs`                        | The model for a board game. Validates its own rating (1 - 6).                                                                                                                                                                   | Does not know anything about the other classes, pages or components. |

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

### Dice Throw and Game Page
Task 2:  
Component communication and navigation.

**Components, pages and classes**

| Part                         | Does                                                                                                                                                                                                                     | Does not                                                             |
|------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------|
| `DiceRating.razor`           | Component, runs a foreach loop with a range from 1 - 6, Value and ReadOnly comes DOWN from parent. ValueChanged reports UP.                                                                                              | Does not know about other pages, does not change its own Value.      |
| `DiceRating.razor.css`       | Handles the styling for the component.                                                                                                                                                                                   | Does not hold logic.                                                 |
| `GameCard.razor`             | Now shows a read-only `DiceRating` and raises `OnAddToGameNight` if a user adds a game.                                                                                                                                  | As noted in Task 1 table.                                            |
| `GameRepository.GetGameById` | Looks up a game using its ID. Returns null if ID does not exist.                                                                                                                                                         | Does not decide what the page shows for missing game (page decides). |
| `GameDetails.razor`          | Displays `GameCard` for chosen game (by ID), has button for going back to games, calls on `BoardGame`'s `SetRating` method instead of using `@bind-Value`. Uses NavigationManager in the button. Has handler for Rating. | Does not write to the rating directly, goes through `SetRating`.     |
| `Games.razor`                | Now has a confirmation field holding a message that is displayed if a game is added to "My Game Night". Message is not shown if a game is not added to "My Game Night".                                                  | Does not store the added game or decide what "adding" means.         |
| `NavMenu.razor`              | Displays linked pages in the left side of the main page layout.                                                                                                                                                          |                                                                      |
| `MyGameNight.razor`          | Does nothing for task 2, will contain data in task 3. Created skeleton for `NavMenu`. Does have a link to go back to Home.                                                                                               |                                                                      |
| `NotFound.razor`             | Handles situations where a page does not exist. Has a link to go back to Home.                                                                                                                                           |                                                                      |

**Page table**  

| Route               | Goes to                                                                                                |
|---------------------|--------------------------------------------------------------------------------------------------------|
| `"/"`               | Goes to the root, "Home". The start page of the project.                                               |
| `"/games"`          | Goes to the "Game Shelf" where all games are displayed using `GameCard`.                               |
| `"/games/{Id:int}"` | Is a direct route to each game's page, navigated using the ID.                                         |
| `"/my-game-night"`  | Goes to the "My Game Night" page that is empty for this task.                                          |
| "`/not-found`"      | Goes to the "Not Found" page in instances where a user tries to navigate to a page that does not exist |


**DiceRating table**  

| Name           | Type                 | Direction | What it means                                                                                          |
|----------------|----------------------|-----------|--------------------------------------------------------------------------------------------------------|
| `Value`        | `int`                | Down      | Gives the child an int value and decides which die is highlighted.                                     |
| `ValueChanged` | `EventCallback<int>` | Up        | Carries an `int` and is raised when the user clicks a die face, and not at all when `ReadOnly = true`. |
| `ReadOnly`     | `bool`               | Down      | When true, switches off the clicks in the `GameCard` (example, shelf card).                            |

A value within the range of 1 - 6, highlights a die face. Any other value (including 0 for an unrated game), leaves all six 
unhighlighted.  
The `@bind-Value` is supported by the component, but due to encapsulation, the `Rating` can only be set through `SetRating`.   
The page instead uses `Value` and `ValueChanged`, and the handler calls `SetRating`. 


**GameCard table**

| Name               | Type                     | Direction | What it means                                                                                                     |
|--------------------|--------------------------|-----------|-------------------------------------------------------------------------------------------------------------------|
| `Id`               | `int`                    | Down      | Game's unique ID. Shown in the top right corner, used in the link to the game's page.                             |
| `Name`             | `string`                 | Down      | The game's name. Also what `OnAddToGameNight` carries.                                                            |
| `MinPlayers`       | `int`                    | Down      | Minimum number of players.                                                                                        |
| `MaxPlayers`       | `int`                    | Down      | Maximum number of players.                                                                                        |
| `Category`         | `string`                 | Down      | The category of the game.                                                                                         |
| `Description`      | `string`                 | Down      | A short game description.                                                                                         |
| `Rating`           | `int`                    | Down      | The game's rating, shown in a read-only `DiceRating`.                                                             |
| `IsPickedCard`     | `bool`                   | Down      | When "true", adds the class `picked-card` to highlight a randomly picked game.                                    |
| `OnAddToGameNight` | `EventCallback<string>`  | Up        | Raised when the user clicks "Add to game night". Carries the game's `Name` (string). Parent decides what happens. |


**Data UP and data DOWN examples**  
`DiceRating`: the parent (`GameDetails`) owns the rating, which lives in `BoardGame`.   
`Value` goes down so the component can display it.  
When a die is clicked, `ValueChanged` goes up with the new value.  
The parent then updates the value, and a new Value comes down.  
The component never changes the value directly.

`GameCard`: the parent (`Games`) owns the list of games that are loaded from the repository, and a confirmation message.
The game's data goes down into `GameCard`, through its parameters (`Id`, `Name`, etc.).  
When the user clicks "Add to game night", `OnAddToGameNight` goes up with the game's `Name` (string).  
The parent then shows a confirmation message, and the card never decides what "adding" means.


**Why `/games/abc` fails**  
Documented in the [Test Suite README](../SoftwareDesign.Tests/README.md) under `Task 2 Manual Test Log`.

**Limitations**  
- Page `GameDetails` will have dead buttons for now when I reuse the card. This will solve itself in task 3 with saved state.
- Two rating rows: for now there are two rating rows where one is static and follows the card, and one is clickable on the 
`GameDetails` page.
- In task 2, the set rating will not yet be stored, only displayed.

**Test Results:**  
Refer to the documentation in [Test Suite README](../SoftwareDesign.Tests/README.md)

**Design Choices:**  
Refer to the documentation in [DesignChoices.md](../Docs/DesignChoices.md)

**AI Assistance Documentation:**  
Refer to the documentation in [AIUse.md](../Docs/AIUse.md)

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