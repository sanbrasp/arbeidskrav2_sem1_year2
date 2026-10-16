# Design Choices

Must contain:
- At least 3 design choices. For every choice you describe the problem, at least two alternatives, your choice, and the cost of the choice.
- 2 of the choices must concern sharing of state and render mode. You choose the third.
- Describe what would be easy and what would be hard to change in the solution. Use at least two examples like swapping storage 
in memory with a database or adding a new field to the game.
- Describe known limitations.

## Task 1 - 

**Games.razor**  
Displays the games and allows user to search and filter at the same time.

**GameCard.razor**  
Shows one game per card. 

**GameRepository.cs**  
Separation of concerns. The GameRepository is the One Source of Truth.

**GameFilterService.cs**  
Note to self:  
Options were compared (page, repo, separate class)  
Went with separate class for testability, because the filtering need will grow, and to avoid 
dependency of where the data comes from.  
The cost is one more class, one more registration, and the page has to pass the list in.

