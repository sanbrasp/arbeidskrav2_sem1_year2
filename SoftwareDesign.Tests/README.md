# Test Suite for SoftwareDesign
Arbeidskrav 2, semester 1, year 2, Gokstad Akademiet.

TODO: DELETE WHEN DONE!  
Testing Documentation

Must contain:
- ~~At least 5 automated tests in its own test project (add test data and screenshots here)~~
- At least 3 tests should cover logic outside the components, example: GameNightState, filtering, or validation
- At least 1 test should test a component, example: DiceRating (Rating) sending the correct value through ValueChanged. Can use bUnit
- Tests should cover normal use and edge cases
- Write a manual test log for test cases in ~~task 1~~,2, 3, 4 that aren't automated. Log should show test case, steps, expected result
  and actual result.


---

## Overview
- [Manual Test Log](#task-1-manual-test-log)
- [Task 1 Automated Tests](#task-1-automated-tests)
- [Manual Test Log]()
- [Task 2 Tests](#task-2-tests)
- [Task 3 Tests](#task-3-tests)
- [Task 4 Tests](#task-4-tests)

---

## Task 1 Manual Test Log

**Case: _Search with no hits, clicking "Choose a random game!" does not crash_**    
- Search for `asd`
- Number of players: `Any`
- Click `🎲Roll the die`

**Expected result:**    
- `Hits: 0`
- `No games matching the search.`
- No hits
- No crash

**Actual result:**  
![manual test](Images/task1_manualtest_games_search.png)

**Case: _Search with hits, random game highlight working_**    
- Search for something that yields at least 2 results
- Click `🎲Roll the die`

**Expected result:**
- `Hits: 2`
- No message for no matching games
- Highlighted random game

**Actual result:**  
![random when there are hits](Images/task1_manualtest_games_hit_random.png)

**Case: _Dropdown menu affects hits_**    
- Pick 7 players
- Pick 9 players

**Expected result:**  
- `Hits: 3`
- `Hits: 1`

**Actual result:**    
![dropdown7](Images/task1_manualtest_dropdown7_9.png)

**Case: _Filtering and dropdown work together_**  
- Search for `span`
- Dropdown: `5 players`
- Dropdown: `6 players`

**Expected result:**  
- `Hits: 2`
- Two games, `Hits: 2`
- No hits, `No games matching the search`

**Actual result:**  
![dropdown and search](Images/task1_manualtest_dropdown_search.png)

---

## Task 1 Automated Tests
Task 1 test coverage.
![Task 1 Tests Run](Images/task1_tests_success.png)
- `BoardGame.SetRating`
- `GameFilterService.Filter` 
- `GameFilterService.FilterByNumberOfPlayers` 
- `GameFilterService.MaxAmountOfPlayers`
- `GameRandomizer.GetRandomGame`
- `GameRepository.GetAllGames`
- `GameRepository.RegisterNewBoardGame`

**Testing:**

- Edge cases
- No hits
- Empty collections
- Guards for rating
- Range for number of players
- Upper and lowercase searches

---


## Task 2 Tests
## Task 2 Manual Test Log
(case, steps, expected, actual)

**Case: Looking up an ID that exists**  

**Steps**  
- Navigate to `/games/1` using the URL field

**Expected result**  
- Hits: 1
- Game: Wyrmspan

**Actual result**  
![Lookup existing ID](Images/task2_lookup_existingId.png)


**Case: Looking up an ID that does not exist**  

**Steps**  
- Navigate to `/games/999` in the URL field

**Expected result**  
- Message displaying: `No game with ID 999 found.`
- Link back to game library: `Go back to the game library`

**Actual result**  
![nonexisting Id](Images/task2_lookup_nonexistingId.png)


**Case: Looking up an ID that is a string and not an int**  

**Steps**  
- Navigate to `/games/abc` in the URL field

**Expected result**  
- `Not Found` page
- Text saying: `Sorry, the content you are looking for does not exist`
- Link to go back home: `Go back to Home`

**Actual result**  
![wrong type lookup](Images/task2_lookup_usingthewrongtype.png)

This fails because the type is `int`, set in the page `GameDetails` in the route as 
`games/{Id:int}`. `abc` is not an int, so it won't be able to display anything.


**Case: Clicking the clickable die changes the rating immediately**  

**Steps**  
- Click the link `Link to game's page` on the first game
- Click on the die for `3` in the clickable row

**Expected result**  
- Clickable (outside the card) and un-clickable die is marked immediately on both

**Actual result**  
![die rating](Images/task2_clickingthedie_rating.png)

---

## Task 2 Automated Tests

---

## Task 3 Tests
## Task 3 Manual Test Log

## Task 3 Automated Tests


---

## Task 4 Tests
## Task 4 Manual Test Log

## Task 4 Automated Tests

---