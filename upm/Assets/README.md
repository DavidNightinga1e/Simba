# Simba
Unity package that impliments ECS-like behaviour in more simple way 

# Theory

Entity - `GameObject`  
Component - `SimbaComponent`   
System - `ISystem`   

### SimbaComponent

`SimbaComponent` is a `MonoBehaviour`, that injects into Simba on `Awake`. That means, that after `Awake` you have access to it by searching functions from any other point. 
There are 2 types of search functions:

#### Get  

Given `T` (type of SimbaComponent inheritor) returns component that has exact same type with constant time

|Parameter    |Value   |
|------------	|-------|
| Complexity 	|O(1) |
| Result     	|T   	|

#### Find

Given `T` searches for all components that are `T` or it's inheritors with time, affected by number of components currently in scope

|Parameter    |Value  |
|------------	|-------|
| Complexity 	|O(n) |
| Result     	|List\<T\>|

### ISystem

`ISystem` is a base interface for all systems. It isn't intended to be used as it, but it's inheritors are:
```cs
interface IAwakeSystem { Awake(); }
interface IStartSystem { Start(); }
interface IUpdateSystem { Update(); }
interface ILateUpdateSystem { LateUpdate(); }
interface IOnDestroySystem { OnDestroy(); }
```

Interface method invokation is based by it's name and controlled by `SystemRunner`

### SystemRunner

`SystemRunner` is a `MonoBehaviour`, that implements property `List<ISystem> Systems` which controls order of system execution. Mind that it is a method, and you shoudn't implement system constructors in it. Otherwise new systems are going to be created every frame

✔ Correct:
```cs
protected override List<ISystem> Systems { get; } = new List<ISystem>
    {
        new System()
    };
```

❌ Wrong:
```cs
protected override List<ISystem> Systems => new List<ISystem>
    {
        new System()
    };
```
