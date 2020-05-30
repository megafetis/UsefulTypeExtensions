# UsefulTypeExtensions

[![NuGet](https://img.shields.io/nuget/dt/UsefulTypeExtensions.svg)](https://www.nuget.org/packages/UsefulTypeExtensions/) 
[![NuGet](https://img.shields.io/nuget/vpre/UsefulTypeExtensions.svg)](https://www.nuget.org/packages/UsefulTypeExtensions/)

Collection of useful type extensions

## Installing UsefulTypeExtensions

You should install [UsefulTypeExtensions with NuGet](https://www.nuget.org/packages/UsefulTypeExtensions):

    Install-Package UsefulTypeExtensions
    
Or via the .NET Core command line interface:

    dotnet add package UsefulTypeExtensions


##### Common usage (Example):

Check InheritsOrImplements:

```cs 
public abstract class BaseEntity<TId>:IEntity<string>
{
    TId Id {get;set;}
}

public abstract class BaseIntIdEntity : BaseEntity<int>
{

}

public class SomeEntity1:BaseEntity<string>,IHasName
{
    public string Name { get; set; }
}

public class SomeEntity2 : IEntity<int>, IHasName
{
    public string Name { get; set; }
    public int Id { get; set; }
}

public class SomeEntity3 : BaseIntIdEntity, IHasName
{
    public string Name { get; set; }
}


```
common interfaces
```cs

interface IEntity<TId>:IEntity
{
    TId Id {get; set;}
}

interface IEntity
{

}

interface IHasName
{
    string Name {get; set;}
}

```

Tests:

```cs
Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(IEntity<>)));
Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(SomeEntity1)));
Assert.False(typeof(SomeEntity1).InheritsOrImplements(typeof(IEntity<int>)));
Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(IEntity<string>))); 
Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(IHasName)));
Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(BaseEntity<>)));
Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(BaseEntity<string>)));
Assert.False(typeof(SomeEntity1).InheritsOrImplements(typeof(BaseEntity<int>)));

Assert.True(typeof(BaseEntity<>).InheritsOrImplements(typeof(IEntity<>)));

Assert.True(typeof(BaseEntity<string>).InheritsOrImplements(typeof(IEntity<string>)));

Assert.True(typeof(BaseEntity<string>).InheritsOrImplements(typeof(IEntity<>)));
Assert.True(typeof(IEntity<string>).InheritsOrImplements(typeof(IEntity<>)));
Assert.True(typeof(IEntity<string>).InheritsOrImplements(typeof(IEntity)));
Assert.True(typeof(IEntity<string>).InheritsOrImplements(typeof(IEntity<string>)));
Assert.True(typeof(IEntity<>).InheritsOrImplements(typeof(IEntity<>)));

Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity<>)));

Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity)));
Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity<>)));
Assert.False(typeof(SomeEntity2).InheritsOrImplements(typeof(BaseEntity<>)));
Assert.False(typeof(SomeEntity2).InheritsOrImplements(typeof(BaseEntity<int>)));
Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity<int>)));
Assert.False(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity<string>)));

Assert.True(typeof(IEntity).InheritsOrImplements(typeof(IEntity)));
Assert.False(typeof(IEntity).InheritsOrImplements(typeof(IEntity<>)));
Assert.True(typeof(IEntity<>).InheritsOrImplements(typeof(IEntity)));

Assert.False(typeof(BaseEntity<>).InheritsOrImplements(typeof(SomeEntity1)));
Assert.False(typeof(BaseEntity<string>).InheritsOrImplements(typeof(SomeEntity1)));
Assert.True(typeof(BaseEntity<string>).InheritsOrImplements(typeof(BaseEntity<>)));
Assert.False(typeof(BaseEntity<string>).InheritsOrImplements(typeof(BaseEntity<int>)));

Assert.True(typeof(BaseEntity<>).InheritsOrImplements(typeof(object)));
Assert.True(typeof(BaseEntity<>).InheritsOrImplements(typeof(Object)));
Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(object)));
Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(object)));

Assert.True(typeof(BaseIntIdEntity).InheritsOrImplements(typeof(BaseEntity<>)));
Assert.True(typeof(BaseIntIdEntity).InheritsOrImplements(typeof(BaseEntity<int>)));
Assert.True(typeof(BaseIntIdEntity).InheritsOrImplements(typeof(BaseIntIdEntity)));
Assert.True(typeof(BaseIntIdEntity).InheritsOrImplements(typeof(IEntity<int>)));
Assert.True(typeof(SomeEntity3).InheritsOrImplements(typeof(BaseIntIdEntity)));
Assert.True(typeof(SomeEntity3).InheritsOrImplements(typeof(IEntity<int>)));

```

Get default value of type:
```cs
Assert.Null(typeof(SomeEntity1).GetDefaultValue());
Assert.Null(typeof(string).GetDefaultValue());
Assert.AreEqual(typeof(int).GetDefaultValue(),0);
Assert.AreEqual(typeof(long).GetDefaultValue(),0);
Assert.AreEqual(typeof(DateTime).GetDefaultValue(),DateTime.MinValue);

```
