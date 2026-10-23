# Software Design API

---

For task 4, the responsibilities are moved from 
`SoftwareDesign/Data/GameRepository` and into the API project's `SoftwareDesign.Api/Data/GameRepository`.

The now obsolete `SoftwareDesign.GameRepository` will be kept for history.

---

## Table

| Endpoint              | Old repository Method  | Takes                                         | Returns                                     |
|-----------------------|------------------------|-----------------------------------------------|---------------------------------------------|
| GET `/api/games`      |                        |                                               | The list of game, or empty list             |
| GET `/api/games/{id}` | `GetGameById`          | BoardGame game                                | A game, or null                             |
| POST                  | `RegisterNewBoardGame` | Everything but `Id` properties as parameters. | A new game with assigned ID, added to list. |
| PUT                   |                        |                                               | or 404                                      |
| DELETE                |                        |                                               | or 404                                      |