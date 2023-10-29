# Contributing To The Project

## Pull Requests

Pull Requests are welcome, just ping me in Discord and I'll get around to Code Reviewing it. For the time being all PRs are to be reviewed by me alone. 

General Code Contribution Guidelines are as follows:

1. Write readable C# code that doesn't make me want to gouge my eyes out. See [CONVENTIONS](docs/CONVENTIONS.md) for details.
2. Follow Domain Driven Design (DDD). Put simply, Frontend and API Controller code goes in App project, Service Classes and overall Business Logic goes in the Domain project, Data Models and Database Access stuff goes in the Data project.
3. Use [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) for your commit messages.
4. Run and Test your changes locally before opening a PR.
5. Delete your branch once it has been merged to main.

## Issues

For now let's limit Issues to Bug Reports. For Feature Requests ping me on Discord so we can talk about it.

When reporting an Issue please include the following:

1. BRIEF Summary of the Issue you are experiencing.
2. Steps taken to Reproduce the Issue.
3. Expected Result.
4. Actual Result.
5. Screenshots are a plus but not required.