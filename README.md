# Sudoku Game

This started with me creating a sudoku puzzle validator (checking if the solution was true), but I wanted to create something more. So I set out to create a sudoku game. This mini-project was just something for me to do for fun and at first I wanted to create this 'my-way', but this proved in-effective.

## Attempt 1

I first started out by trying to randomly fill the board by choosing a random point, finding n viable inputs for this point, evaulate its neighbors and their n viable inputs and then make use of various constraints like (subsets,hidden subsets, unique candidates...). This ended up working but was much slower than I'd like to admit, I tried adding in more constraints to lower the process time but decided it was time to do some reading.

## Attempt 2

Luckily I came across some great articles, most importantly [This one](http://norvig.com/sudoku.html). This method makes use of a tree-like search. It goes down a path of viable inputs until it gets to a dead end then reverts back to the previous square and tries another input assuming the previous square has n>1 viable inputs. Any puzzle I fed to my program, was now solved in milliseconds. Due to the fact the search progresses linearly through my squares - the list of squares is ordered from least valid moves to most.  

## Unique puzzle generation

Currently the application inputs a valid input into a minimum of 17 random squares before then feeding this board to the solver method to check if this mixture of numbers has a solution. Usually this process takes under 0.5 seconds, in edge cases it can take 30 seconds - 1 minute. 

## Performance improvements that could possibly be made to this project (who knows if they will work or even be better)

+ The solver could be improved to update the order of the available squares based on valid inputs remaining after each input. Updated squares would need to know their 'parent' square in order to revert back if a dead end is reached.

+ The puzzle generator can be improved by not trying a sequence of (~17) numbers if it has already failed before, at the moment in edge cases these repetitive attempts are high resulting in long process times.

+ Instead of creating a random puzzle whenever a player clicks new game. A puzzle creator application can be made to thousands of random valid puzzles and store them in a folder. When new game is clicked it fetches a random puzzle from this folder, resulting in minimal waiting time. This also allows you to alter these puzzles (rotation etc)  resulting in more puzzles. - I read that millions of children puzzles can be made from a single puzzle through alterations - how true this is i dont know. 

+ I need to add in more error handling in the code (Bugs are waiting to happen).

## Feature improvements that could be made

+ The GUI could be made much more aesthetically pleasing by porting this project to be a web app instead of a console application. Allowing me much more freedom. 

+ Difficulty levels. At the moment, the difficulty of each puzzle generated is random, albeit ~17 clues are given each time, their positions are completely random.

+ At the moment if the user has an error in his puzzle (duplicates in a row/column/3x3 block) then they are only notified when clicking the solve button or check answer button. When a user clicks check answer it can highlight the error square on the GUI or when they input an invalid number 

# Screenshots

+ [Starting up](https://imgur.com/BW65duS)
+ [New Game clicked](https://imgur.com/ArRWJrP)
+ [Checking answer](https://imgur.com/cqpDjfv)
+ [Getting the solution solved for you](https://imgur.com/Ho12RyC)
+ [An error on your board](https://imgur.com/wJ0EgoP)



