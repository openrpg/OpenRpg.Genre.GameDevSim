# OpenRpg.Genre.GameDevSim

An OpenRpg Genre library for game dev sim style games i.e Game Dev Story or Game Dev Tycoon

![](https://imgur.com/lKTNCjK.png)
> Above image is taken from the example console app project bundled in the repo.

## How To Use It?

As with other OpenRpg Genre libs just make sure you have the relevant OpenRpg nuget dependencies, then add this one in.

## What Does It Contain

### Staff

This model is basically an extended `Character` class with custom effects being available on it.

### Company

The company model represents your company and how much cash you have, what staff you have as well as other metadata.

### GameTheme / GameGenre

These represent the theme/genre of a game you want to create, it has a name and effects that are applied.

### Game

This is the actual produced game, it stores the name, theme, genre as well as other metadata.

> If you want an actual example of all this stuff being used look at the examples project which contains a console app that lets you create basic games and sell them