# Brick Breaker

A 2D brick breaker game built from scratch with Unity 6 and C#.

## How the ball works

I did not use Unity's own bounce material for the ball. Instead I move the ball myself in
`FixedUpdate` along a direction vector, and when it hits something I reflect that direction off
the contact normal with `Vector3.Reflect`. This keeps the ball speed constant and makes the
bounce angle predictable, which is what a brick breaker needs — a physics material can slowly
lose or gain energy and make the ball feel wrong.

## Structure

The game is organised in two layers:

```
Assets/_project/Scripts/
├── Elements/     Ball, Brick, Player, PlayerInput, Level
└── Managers/     GameDirector, LevelManager, BrickManager
```

- **Elements** are the objects in the scene. They know how to do one thing each.
- **Managers** hold the game state. `GameDirector` runs the game, `LevelManager` loads levels,
  `BrickManager` keeps track of the bricks that are still alive.

Levels are prefabs, so adding a new level means making a new prefab, not writing code.
Bricks have health and need more than one hit. Hit feedback is animated with DOTween.

## Built with

Unity 6 (6000.3.15f1) · C# · 2D physics · DOTween

## How to open

1. Install Unity 6 (6000.3.15f1) or newer.
2. Open Unity Hub → **Add** → choose this folder.
3. Open the main scene and press **Play**.
