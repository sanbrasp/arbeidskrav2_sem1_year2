# Test Suite for SoftwareDesign
Arbeidskrav 2, semester 1, year 2, Gokstad Akademiet.

TODO: DELETE WHEN DONE!  
Testing Documentation

Must contain:
- At least 5 automated tests in its own test project (add test data and screenshots here)
- At least 3 tests should cover logic outside the components, example: GameNightState, filtering, or validation
- At least 1 test should test a component, example: DiceRating sending the correct value through ValueChanged. Can use bUnit
- Tests should cover normal use and edge cases
- Write a manual test log for test cases in task 1-4 that aren't automated. Log should show test case, steps, expected result
  and actual result.


---

## Overview
- [Task 1 Tests](#task-1-tests)
- [Task 2 Tests](#task-2-tests)
- [Task 3 Tests](#task-3-tests)
- [Task 4 Tests](#task-4-tests)

---

## Task 1 Tests
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

---

## Task 3 Tests

---

## Task 4 Tests

---