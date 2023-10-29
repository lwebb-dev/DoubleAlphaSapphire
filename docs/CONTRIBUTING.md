# Contributing To The Project

At the time of writing this, the DoubleAlphaSapphire App repository is private. Which means if you are reading this, you have been given explicit permission to do so.


## Pull Requests
---
Pull Requests are welcome, just ping me in Discord and I'll get around to Code Reviewing it. For the time being all PRs are to be reviewed by me alone. 

General Code Contribution Guidelines are as follows:

1. Write readable C# code that doesn't make me want to gouge my eyes out. see [CONVENTIONS](docs/CONVENTIONS.md) for details.
2. Follow Domain Driven Design (DDD). Put simply, Frontend and API Controller code goes in App project, Service Classes and overall Business Logic goes in the Domain class, Data Models and Database Access stuff goes in the Data project.
3. Run and Test your changes locally before opening a PR.
4. Delete your branch once it has been merged to main.

## Issues
---
For now let's limit Issues to Bug Reports. For Feature Requests ping me on Discord so we can talk about it.

When reporting an Issue please include the following:

1. BRIEF Summary of the Issue you are experiencing.
2. Steps taken to Reproduce the Issue.
3. Expected Result.
4. Actual Result.
5. Screenshots are a plus but not required.