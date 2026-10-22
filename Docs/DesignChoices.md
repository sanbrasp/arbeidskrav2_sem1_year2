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
  - [Task 4 Choice?]()
  - [Easy and Harder to Change](#easy-and-harder-to-change)
  - [Known Limitations](#known-limitations)

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


| Alternative                  | Reasoning  | Problem that led to choice | Lifetime  |                                                                                                                                                    
|------------------------------|------------|----------------------------------------------------------------------------------------------------------------------------------------------------|
| Wrapper tag around each card | |Did not opt for this because the page would have to know about the card's styling, and the card no longer controls its own look.                               |
| Highlight by position        | |Did not opt for this because the position of a game changes when the search or the dropdown changes the list, so the highlight would end up on the wrong card. |
| Bool parameter               | |Chosen because the card only needs to know `IsPickedCard`, not how the page found the pick.                                                                    |

Cost of this choice:
- One more parameter on the `GameCard`

</details>

---

<details><summary>Expand to see task 3 choices</summary>

### Task 3 Choice: How the Game Night is Shared

| Choice | Reason | Problem that led to choice | Lifetime |
|------------------|--------|----------------------------|----------|
| State Service `GameNightState` | The service owns the list and its rules, and its event tells subscribers when the list changes. | The user's list and the total playtime needed to be tracked across several components. List must survive navigation. | Scoped, lives for the duration of the circuit. |


| Alternatives | Reasoning |
|-----------------------|--------|
| `Parameters and EventCallback` | Not used because it requires a parent-child relationship. |
| `Cascading Values` | Does not have a built-in way to tell components that something changed. Only passes data down. |
| `State Service` | (Chosen) Uses events and subscriptions. Can be reached from all components. |


**Cost of this choice:**  
- The components depend on a service and have to subscribe and unsubscribe (`Dispose()`).  
- The list is lost on "Refresh".


### Task 3 Choice: Lifetime of the Service

| Choice | Reason | Problem that led to choice |
|--------|----------------|------|
| `Scoped` | Scoped creates one instance that follows one circuit (one user/tab) and is not shared with anyone else. | The user list must not be shared across users/tabs. Must survive navigation. |

| Alternatives | Reasoning |
|--------------|-----------|
| `Singleton` | Not chosen because it would share the list between tabs/users. |
| `Transient` | Not chosen because the list would not survive navigation. Every component gets its own instance. |
| `Scoped` | Chosen because it lets the list survive navigation and does not share it with anyone else (its own circuit only). |

**Cost of this choice:**  
- The same guest using two tabs gets two lists
- A refresh starts a new list



### Task 3 Choice: Render Mode

| Choice | Reason | Problem that led to choice | Lifetime |
|--------|----------------|------|-------------|
| `Global Interactivity` | The router passes the mode on to every page omitting the need for a manual `@rendermode`. All pages and menu share the same circuit. | The list must survive navigation and the menu must update live. | N/A |

| Alternatives | Reasoning |
|--------------|-----------|
| `Global Interactivity` (`Routes`, `HeadOutlet`) | The whole app in one circuit. The scoped list survives navigation. One place decides the mode for everyone. |
| `Interactivity per page` | Not chosen. A page with no render mode closes the circuit, so the list is lost, the buttons are dead, and the badge does not update. |
| `Static rendering` (no interactivity) | Not chosen. Is not interactive, and would leave buttons dead. No circuit at all. No live menu, and no shared state between pages. |

**Cost of this choice:**  
- One connection is held open per tab
- If connection is lost, the list is lost

**Limitations**

</details>

---

## Easy and Harder to Change
TODO: at least 2 examples.  
storage swap? game-night CSS? PLaytimeMinutes? Name to Id callback?

---

## Known Limitations
TODO: task 3 items plus task 1 one?

---