# Documentation of AI Use in this project

Contains documentation of when, how, and why AI was used in this project.

---


Overview
- [How AI Has Been Used](#how-ai-has-been-used)
- [Conceptual Discussions](#conceptual-discussions)
- [Translation](#translation)
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
Whenever AI has directly affected code or the project is documented in this file._

---

## Conceptual Discussions
Briefly documents conversations of a Socratic nature where things like concepts, best practices, and other 
subjects have been discussed.  

---

## Translation
`Claude.ai` has been used to translate the assignment texts from Norwegian to English, as that makes it easier 
for me to follow along. 

---

## Direct Effect From AI Assistance
### Throwaway Seed Constructor 
Used for quickly seeding some games for testing during development. Deleted after testing.

### CSS Help
- `flex`, `wrap`, `gap`, speed tutorials in CSS, sources for quickly reading up on it.  
- I needed some help with the syntax for the hit counter inside a `<p>`.  
- Gave me a refresher on the `? : operator` explained with a weather example and a lamp example for the class attribute, 
which resulted in `<div class="game-card @(IsPickedCard ? "picked-card" : "")">`
- The card markup block and simple CSS rule for `.picked-card` which I asked to be given straight up.
- The syntax for page side attribute: `IsPickedCard="@(game == _randomBoardGame)"`
- The CSS for showing the ID at the top right of the `GameCard`: `position: relative` on the card, and
`position: absolute` with `top` and `right` on the ID. Given as is.

### Theory Test Refresher
`Claude.ai` gave me a "fill in the blanks" for the `Theory` part of a test to remind me of the syntax.  
All test are written by myself.

### Manual Test Explanation
I was having some trouble understanding what exactly to do in a manual test, and the difference between automated and 
manual in this contenxt. `Claude.ai` provided an explanation translated from Norwegian to English.

### Formatting Suggestions for the Project Readme
Suggested a body shape for the README for me to fill out.

### Rewording of a Messy Paragraph
`Claude.ai` suggested a rewrite of a paragraph in the "Why" section of Task 1 in the project README.
I had written it in a way that made it clunky to read.

---

## AI Use Reflection