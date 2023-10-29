# Coding Conventions

First and foremost, refer to the [.NET documentation for fundamental C# code conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). If you have been learning and/or using C# for even a little while you are probably already doing most of these.

Additionally here are some personal preferences I've developed over the last 5 years doing this for a living:


## C# / .NET
---

Comments are encouraged except for when they are rendered reduntant by self documenting code:
```
// Array of pokemon that are fainted (no shit sherlock)
BattlePokemon[] faintedPokemon = battlePokemon
    .Where(bp => bp.IsFainted == true)
    .ToArray();
```

Insert a single space between your comment slashes and the first letter of the comment.

```
//Don't do this.
// Do this instead.
```
  Organize Classes starting with Variables and Properties by Least Visible to Most Visible, followed by the constructor, then finally Methods organized by Most Visible to Least Visible:

```
public class MyClass : IMyClass
{
    private readonly IService service;

    public string MyPublicStringProperty { get; set; }

    public MyClass(IService service)
    {
        this.service = service;
    }

    public async Task<string> GetStringValueAsync(int value)
    {
        ServiceInput input = this.GetServiceInputs(value); 
        return await this.service.GetStringValueAsync(input);
    }

    private ServiceInput GetServiceInput(int value) 
    {
        var result = new ServiceInput();

        // Insert repeatable code here

        return result;
    }
}
```

Use `this.` whenever referencing a locally scoped variable, property, or class method. Use `base.` when referencing variables, properties, and methods inhereited from a parent class.

Remove any and all uneccesary usings.

Constant variables use `UPPER_CASE_UNDERSCORE` format.

```
private const int MAX_RETRIES = 3;
```

Avoid prepending private variables with "_". I know this is still technically common practice but I always thought it looked fugly.
```
// Don't
private readonly DarDbContext _dbContext;

// Do
private readonly DarDbContext dbContext;
  ```
  Prefer explicit type declarations over var, unless your initialization code explicitly defines the type:

```
// Don't
var trainers = await this.TrainersService.GetTrainersAsync();

// Do
IEnuerable<Trainer> trainers = await this.TrainersService.GetTrainersAsync();

// Also Ok
var trainer = new Trainer();
```

Avoid `for` loops whenever possible. Use `foreach` instead:
```
string[] trainers = { "Roxanne", "Brawly", "Wattson" };

// Don't
for (int i = 0; i < trainers.Length; i++)

// Do
foreach (string trainer in trainers)
```

Avoid nested `if` statements whenever possible. Instead try to return early.

```
// Don't
if (firstConditionMet)
{
    if (secondsConditionMet)
    {
        if (thirdConditionMet)
        {
            return true;
        }
    }
}

return false;

// Do

if (!firstConditionMet)
{
    return false;
}

if (!secondConditionMet)
{
    return false;
}

if (!thirdConditionMet)
{
    return false;
}

return true;
```

Always use brackets with conditionals, even if it's just one line:

```
// Don't

if (conditionFailed)
    return error;

// Please Don't

if (conditionFailed) return error;

// Do

if (conditionFailed)
{
    return error;
}
```

I'm sure there's more. I'll add them as they come to me.

## PostgreSQL
---
Since we use EntityFramework to handle all our queries, indexing, and ORM, the only thing th mention here is to use `lower_case_underscore` format for table and column names.

Date and Timestamp columns should always store UTC data, and the column name should reflect this. Example: `created_on_utc`.

## Svelte (HTML/CSS/Javascript)
---
// TODO