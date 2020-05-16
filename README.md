# Developer Exercise

This update on the original ReadMe file is intented to provide a brief explanation of the current author's chance to provide an architecture and an overall idea of an implementation of the initial project requirements.


## Project Structure
This is the initial project structure

![Image description](Images/ProjectStructure1.png)


### Example:

Input groceries:

| Product | Price |
| ------- | :---: |
| apple   |  50c  |
| banana  |  40c  |
| tomato  |  30c  |
| potato  |  26c  |

Input deals:

- `2 for 3` - ["apple", "banana", "tomato"]
- `buy 1 get 1 half price` - potato

Example scanned customer basket: "apple", "banana", "banana", "potato", "tomato", "banana", "potato"

Expected Output: `1 aws and 99 clouds`
Explanation:

The items are processed(Scanned) in order:

- "apple", "banana", "banana" are picked up for the `2 for 3` deal and 1 of the bananas is free - total cost `90c`

- "potato", "tomato", "banana", "potato" are left. There is a `buy 1 get 1 half price` for potatoes, meaning the second potato will be half price (13c) so it will be `39c` for both

- The other 2 items scanned `tomato` and `banana` are not part of any deals so they are charged their basic price `70c` total

The total amount the is equal to: `90c + 39c + 70c = 1 aws and 99 clouds` (199 clouds = 1.99 aws)

## Grading

You will be scored on the following:

- Code cleanliness and ease of understandability
- Code tests
- Code reusability
- Code modularity (i.e. ease of extension)
- Documentation

## Demonstrable concepts

You are free to make your solution to this exercise as simple or as complicated as you want based off the above criteria. The end result can come in the for of either of the options below:

- REST/HTTP API
- User interface (web app)
- Application CLI
