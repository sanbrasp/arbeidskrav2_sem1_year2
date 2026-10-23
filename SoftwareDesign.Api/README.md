# Software Design API

---

For task 4, the responsibilities are moved from 
`SoftwareDesign/Data/GameRepository` and into the API project's `SoftwareDesign.Api/Data/GameRepository`.

The now obsolete `SoftwareDesign.GameRepository` will be kept for history.

---

## Table

| Endpoint              | Old repository method                                                                                                  | New repo method |
|-----------------------|------------------------------------------------------------------------------------------------------------------------|-----------------| 
| GET `/api/games`      | `GetAllGames()`                                                                                                        |                 |
| GET `/api/games/{id}` | `GetGameById(int id)`                                                                                                  |                 | 
| POST `/api/games`     | `RegisterNewBoardGame(string name, int minPlayers, int maxPlayers, string category, string description, int playtime)` |                 | 
| PUT                   | N/A                                                                                                                    |                 | 
| DELETE                | N/A                                                                                                                    |                 |


