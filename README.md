# Brick Breaker

A classic 2D brick breaker game built from scratch with **Unity 6 (URP)** and **C#**.

> 👤 Developed by a 3rd-year Software Engineering student at Kütahya Dumlupınar University, Organizer @ GDG & WTM Kütahya

## What this project demonstrates

- **Custom physics instead of the built-in bounce** — ball reflection is calculated manually from collision normals (`Vector3.Reflect`), with movement in `FixedUpdate` for frame-rate-independent, consistent speed
- **Clean, layered architecture** — single-responsibility scripts communicating through references, no god-objects and no `FindObjectOfType` calls
- **Data-driven level design** — levels are prefabs; the manager spawns, tracks and disposes of them at runtime (`Instantiate`/`Destroy` with proper cleanup)
- **Game feel / juice** — hit feedback (scale punch, shake, color flash) implemented with DOTween, tweens properly killed before reuse to avoid animation conflicts

## Architecture

```
GameDirector      → top-level game flow: restart, level switching, win state
 └─ LevelManager  → spawns/destroys levels and the ball
     └─ Level     → owns its bricks, reports back when cleared
         └─ Brick → health, hit feedback, notifies its Level on destruction
Ball / Player / PlayerInput → gameplay elements, each a single responsibility
```

Events flow upward (Brick → Level → LevelManager → GameDirector), so each script only knows about its direct owner — easy to extend with new brick types or level rules.

## Gameplay & Controls

Control the paddle with your mouse, bounce the ball, clear all bricks to win. Bricks take multiple hits and change color as they take damage.

| Input | Action |
|---|---|
| Mouse drag | Move paddle (screen-space input normalized to world space, clamped) |
| R | Restart level |
| E / Q | Next / previous level |

## Tech

- Unity 6000.3, Universal Render Pipeline
- C#
- DOTween (tweening/feedback)
