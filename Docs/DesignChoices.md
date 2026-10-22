# Design Choices

Must contain:
- At least 3 design choices. For every choice you describe the problem, at least two alternatives, your choice, and the cost of the choice.
- 2 of the choices must concern sharing of state and render mode. You choose the third.
- Describe what would be easy and what would be hard to change in the solution. Use at least two examples like swapping storage 
in memory with a database or adding a new field to the game.
- Describe known limitations.

## Overview
- [Design Choices](#design-choices)
  - [Task 1 Choice 1: Where Filtering Lives](#task-1-choice-where-filtering-lives)
  - [Task 1 Choice 2: Who Creates the Games and their IDs](#task-1-choice-who-creates-the-games-and-their-ids)
  - [Task 1 Choice 3: How the Page tells if a Card is Picked](#task-1-choice-how-the-page-tells-if-a-card-is-picked)
  - [Task 3 Choice 1: How the Game Night is Shared](#task-3-choice-how-the-game-night-is-shared)
  - [Task 3 Choice 2: Lifetime of the Service](#task-3-choice-lifetime-of-the-service)
  - [Task 3 Choice 3: Render Mode](#task-3-choice-render-mode)

---

## Design Choices

<details><summary>Expand to see task 1 choices</summary>

### Task 1 Choice: Where Filtering Lives

| Choice                                | Reason                                                                                                                                  | Problem that led to choice                                       | Lifetime                                      |
|---------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------|-----------------------------------------------|
| Filtering lives in `GameFilterService` | Separation of concerns, tidier code, easier to maintain, filtering need will expand, filter should not depend on where data comes from. | Filtering in the page couldn't be tested and cluttered the page. | Singleton, does not need to remember anything |


| Alternative          | Reasoning                                                                                                                  |
|----------------------|----------------------------------------------------------------------------------------------------------------------------|
| Keep in page         | Did not opt for this because it can't be tested without rendering, and causes the page to be cluttered. Also not reusable. |
| Filter in repository | Did not opt for this because it mixes concerns, and would create a dependency between the filter and repository.           |
| Separate service     | Decided that this was the best option for separation of concerns, maintainability, testing, and encapsulation.             |


The cost of this choice:  
- One more class
- One more registration
- The page has to hand the list every time the filter is called

---

### Task 1 Choice: Who Creates the Games and their IDs

| Choice                                             | Reason                                                                                       | Problem that led to choice                                                                                                                              | Lifetime                                      |
|----------------------------------------------------|----------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------|
| Repository decides IDs (Object initializer method) | Simple and testable, nobody has to invent an ID. IDs start at 1 and increment with no reuse. | Each game needs a unique ID because Task 2 will be using them in page routes, and Task 4 lets a game be deleted. It also makes no sense to reuse an ID. | Singleton, because there is one shared list and counter. |


| Alternative              | Reasoning                                                                                                           |
|--------------------------|---------------------------------------------------------------------------------------------------------------------|
| Constructor parameter    | Did not opt for this because the caller would have to supply an ID manually during creation.                        |
| Set later through method | Did not opt for this because `Id` is `init`, and can only be set during creation.                                   |
| Object initializer       | Chosen because it allows IDs to be created during object creation, and nobody outside the repo has to invent an ID. |

The cost of this choice:
- Because `Id` is `init`, the repository must build the game itself.
- `RegisterNewBoardGame` takes five constructor values, so adding a field means changing the signature too.
- Only convention keeps other code from creating a game without an ID.

---

### Task 1 Choice: How the Page Tells if a Card is Picked

| Choice                                       | Reason                                                                                                                                                 | Problem that led to choice                                                                                                      | Lifetime |
|----------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------|----------|
| `IsPickedCard` bool parameter on `GameCard`  | The page compares each game with the picked one and passes the result down. The card adds `picked-card` itself, so it stays in charge of its own look. | The page knows which game is picked, but the card only draws itself, so it needs a way to be told whether it is the picked one. | N/A      |


| Alternative                  | Reasoning                                                                                                                                                      |
|------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Wrapper tag around each card | Did not opt for this because the page would have to know about the card's styling, and the card no longer controls its own look.                               |
| Highlight by position        | Did not opt for this because the position of a game changes when the search or the dropdown changes the list, so the highlight would end up on the wrong card. |
| Bool parameter               | Chosen because the card only needs to know `IsPickedCard`, not how the page found the pick.                                                                    |

Cost of this choice:
- One more parameter on the `GameCard`

</details>

---

<details><summary>Expand to see task 2 choices</summary>

### Task 3 Choice: How the Game Night is Shared
State service

| Alternatives | Reason | Cost |
|--------------|--------|------|
| | | |

### Task 3 Choice: Lifetime of the Service
Scoped

| Reason | Two-Tab Result | Cost |
|--------|----------------|------|
| | | |

### Task 3 Choice: Render Mode
Global Interactivity  
Reason, per-page consequence, cost

| Reason | Per-Page Consequence | Cost |
|--------|----------------------|------|
| | | |

</details>