# Documentation of AI Use in this project

Contains documentation of when, how, and why AI was used in this project.

---


Overview
- [How AI Has Been Used](#how-ai-has-been-used)
- [Conceptual Discussions](#conceptual-discussions)
- [Translation](#translation)
- [Proof Reading and Code Reviews](#proof-reading-and-code-review)
- [Direct Effect](#direct-effect-from-ai-assistance)
  - [Throwaway Seed Constructor](#throwaway-seed-constructor)
  - [Board Games Suggestions](#board-games-suggestions)
  - [CSS Help](#css-help)
  - [Theory Test Refresher](#theory-test-refresher)
  - [Manual Test Explanation](#manual-test-explanation)
  - [Formatting Suggestion](#formatting-suggestions-for-the-project-readme)
  - [Rewording Paragraph](#rewording-of-a-messy-paragraph)
  - [bUnit First Test]()
  - [Reversed CallBack and Method Names](#reversed-callbackevent-and-method-names)
  - [Lookup By ID When ID Not Found](#lookup-by-id-suggestions-for-id-not-found)
- [Reflection](#ai-use-reflection)

---

## How AI Has Been Used
`Claude.ai` has been used as a tutor through this project, where it has been initially (and repeatedly) instructed
to not provide any "free-answers" or code, and instead ask the questions needed for me to find the answer myself.    
Only when I have not been able to find the answer, having tried and failed several times, have I ended up asking for a
suggestion with detailed explanations that I have then practiced at length until I could safely say I understood.

`Google Notebook LM` / `Gemini Notebook` has been used as a "quizmaster", and it has generated video explainers, flashcards,
and other helpful media based on my own notes from lectures and studies.

_AI has not been used as a code generator or project architect. It has been used as a tutor and learning tool, and it has
also been used for boilerplate tasks such as name generation for projects, translation of assignments, creating bullet lists of
what was already in the assignment text, and things of that nature.  
Whenever AI has directly affected the code or the project, it is documented in this file._

---

## Conceptual Discussions
Briefly documents conversations of a Socratic nature where things like concepts, best practices, and other 
subjects have been discussed.  
Specific concepts discussed include but are not limited to: Object initializers, why DI is for services, what automated
tests mean, test naming pattern conventions.  
Discussions about async task and the loop of `OnClicked -> ValueChanged -> InvokeAsync`.  
Hot Reload: "rude edits". "Deleting class.." scared me, so I needed an explanation for what it actually meant.

---

## Translation
`Claude.ai` has been used to translate the assignment texts from Norwegian to English, as that makes it easier 
for me to follow along. 

---

## Proof Reading and Code Review
`Claude.ai` has been used for proof reading documents and code reviews during this project.

---

## Direct Effect From AI Assistance
Things the AI assisted with that directly affected the contents of the project.

### Throwaway Seed Constructor
Used for quickly seeding some games for testing during development. Deleted after testing.

### Board Games Suggestions
Because I do not partake in board games, I don't know what exists out there, so I had `Claude.ai` find 
a collection of various games with differing min and max players and categories, and used those in my project.    
Note: The game `Wyrmspan` was added by myself with description from the creator.

### CSS Help
- `flex`, `wrap`, `gap`, speed tutorials in CSS, sources for quickly reading up on it.  
- I needed some help with the syntax for the hit counter inside a `<p>`.  
- Gave me a refresher on the `? : operator` explained with a weather example and a lamp example for the class attribute, 
which resulted in `<div class="game-card @(IsPickedCard ? "picked-card" : "")">`
- The card markup block and simple CSS rule for `.picked-card` which I asked to be given straight up.
- The syntax for page side attribute: `IsPickedCard="@(game == _randomBoardGame)"`
- The CSS for showing the ID at the top right of the `GameCard`: `position: relative` on the card, and
`position: absolute` with `top` and `right` on the ID. Given as is.
- I could not figure out how to add die faces as buttons, so `Claude.ai` gave me the markup.
- The first CSS for `DiceRating` in `DiceRating.razor.css` (dice-rating, dice-option.selected, dice-option).

### Theory Test Refresher
`Claude.ai` gave me a "fill in the blanks" for the `Theory` part of a test to remind me of the syntax.  
All tests are written by myself.

### Manual Test Explanation
I was having some trouble understanding what exactly to do in a manual test, and the difference between automated and 
manual in this context. `Claude.ai` provided an explanation translated from Norwegian to English.

### Formatting Suggestions for the Project Readme
Suggested a body shape for the README for me to fill out.

### Rewording of a Messy Paragraph
`Claude.ai` suggested a rewrite of a paragraph in the "Why" section of Task 1 in the project README.
I had written it in a way that made it clunky to read.

---

### bUnit First Test
Since I have never worked with bUnit before, I had `Claude.ai` give me the shape of how one would write one.  
I then filled out the triple a's myself and ran it.  
I wrote the rest of the tests myself with only a few guided questions from `Claude.ai`. I got some syntax wrong, and 
tried to pull data from the wrong CSS classes a few times.

---

### Reversed CallbackEvent and Method Names
I had reversed the method names, which I did not notice until I made Claude review my code.

---

### Lookup By ID Suggestions for ID Not Found
AI named three ways to report: return null, throw, or `TryGet`.  
I was already planning on returning null, but I wanted to see the alternatives.  
Because it's not an error, throw was out of the question, and I did not want an extra `out` value, so 
I stayed with my initial thought.  

In the same code I also had a redundant guard that broke my logic, and forgot that `FirstOrDefault` already ensured 
that null would be returned when ID was not found. AI pointed this out to me with guided questions.

Missing ID is handled by `GameDetails`.

---

### Add To Gamenight Wiring
I was unsure of where to wire the method because I was very tired. The AI tried directing me with guided 
questions, but I was unable to comprehend, and also made mistakes in the syntax. I eventually asked it directly 
where the wiring needed to happen, and it told me it needed to go inside the loop on the `GameCard tag` on the page.  
I wrote the wiring for the confirmation message and adjusted the wiring based on guided questions from the AI.  

---

## AI Use Reflection
Because my template already covers some of the requirements from the "AI Use" in the assignment, I will add 
the missing sections here:

**How AI Was Used**  
[Refer to this section](#how-ai-has-been-used).

**What AI Contributed**  
Documented in detail in this file, under [this section](#direct-effect-from-ai-assistance).  
Conceptual/Socratic documented briefly in [this section](#conceptual-discussions).  
Translations documented in [this section](#translation).  
Proof reading and code reviewing mentioned in [this section](#proof-reading-and-code-review).

**How AI Affected the Final Solution**  
_A selection of things AI affected in the project:_

- Blazor project structure: because this is new to me, I needed some initial suggestions for how the structure itself looks
compared to a regular C# project.
- Test naming pattern: because I asked for a reminder of the naming convention, that directly affected how I named 
the rest of the tests.
- The seed games: because I don't know anything about board games, I asked `Claude.ai` to supply me with examples that I 
used in the project.
- Blazor wiring: I made a lot of syntax errors and needed some suggestions for the wiring of methods and data.
- ID Design: AI suggested three options, where I chose the object initializer, and that directly affected 
the project.

**Things I have assessed, changed, or developed further from suggestions received**  
_A selection of situations:_

| Subject                                   | Disagreement                                                                                                                                                                                                                       | 
|-------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Picked Card border thickness              | AI insisted I should keep the border thinner, but I thought the "highlight" became much clearer with a thicker border that visibly made the selected card pop out. I stayed with my own choice.                                    |
| AI being picky about the manual test text | AI thought I should put more text in the "Actual result" section, whereas I already had screenshots showing every "Actual result" making it easy to compare with "Expected result". I stayed with my own choice.                   |
| Six GameCard parameters kept              | AI wanted me to use the class itself as a parameter, to which I pointed out it would have created a dependency that I didn't want. I chose to keep six parameters. Final answer pending until I am able to ask someone about this. |

Whenever AI gave me CSS visual styling (borders, colors) I would play around with it until I landed on something 
I liked better, or decided to keep the suggestion from AI.

**Errors, limitations or challenges brought on with the use of AI**  
_A selection of situations with challenges and errors:_

| Kind                            | Situation                                                                                                                                                                                                                                             |
|---------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Fact and verification of claims | AI listed a game example with the wrong player count. I set a rule for AI to always supply sources for its claims.                                                                                                                                    |
|                                 | AI claimed that the DI container ignores internal constructors, which was based on weak evidence from an error text mentioning a public constructor.                                                                                                  |
|                                 | Did not translate "Terningkast" well, which caused confusion later during the setup of the bounds for `SetRating`. It translated "Terningkast" to "Dice throw", which doesn't have the same underlying meaning in English.                            |
| Misreadings                     | Misread my empty-list test and told me to fake a condition.                                                                                                                                                                                           |
|                                 | Guessed that my `IsPickedCard` line was missing when it was due to where I had placed the `@()` in the class attribute.                                                                                                                               |
| Stale information               | Used to follow up bullet lists of to-dos, would list closed items as open due to reading from outdated sources internally.                                                                                                                            |
| Tutoring style                  | As per ground rules, had the role of tutor. Would ask way too many questions in one message that made things more confusing than it had to be. Adjusted several times.                                                                                |
|                                 | Would side-track from its own questions, and had to be re-adjusted a few times until the ground rule was very specific (no more than 1 or 2 questions per message, shorter replies, no side-tracking)                                                 |
|                                 | Gave me a full markup that I didn't ask for despite the ground rule of not giving free answers unless I specifically ask for examples (but then to not use data from the project in the example). Stopped doing this after I refined the ground rule. |


Limitations: 
- I was sometimes too tired to follow the guided questions
- AI can't see screenshots in .md files and will suggest things like "add some screenshots"
- Long conversations outgrow AI's memory, and they have to be continued from a summary
- As per the rule of providing sources, AI would sometimes provide made-up links or links it hadn't opened
- Sometimes gives answers you haven't asked for, despite rules disallowing it.
- Ground rules need to be renewed if the conversation is long.