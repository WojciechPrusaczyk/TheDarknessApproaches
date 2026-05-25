# The Darkness Approaches

A short walking simulator made in **24 hours** for a game jam under the theme *"The Darkness Approaches"*.

## Concept

You roam a dark courtyard carrying a lantern. Every 20 to 40 seconds the screen begins to dim — a vignette closes in, colors drain, and the world goes black. If you are not hiding inside a safe box when the darkness falls, it is game over.

## Gameplay

- Explore the courtyard and locate shelter spots (crates/boxes)
- Watch the edges of the screen — the vignette fading in is your only warning
- Survive as many darkness cycles as you can

## What I built

The core mechanic is driven by `VignetteController.cs`:

- Randomized timer (20–40 s) triggers a coroutine-based fade animation using Unity's **Post Processing Stack** (Vignette + ColorGrading)
- If the player is in a safe position when the screen goes fully black, the effect reverses and the cycle resets
- If not — death scene loads

```csharp
// Darkness hits every 20–40 seconds (randomised each cycle)
public float TimeToObscure() => Random.Range(minObscure, maxObscure);
```

## Tech

- Unity 2D
- C#
- Unity Post Processing Stack v2

## Notes

This was my **first project in Unity**, built solo in 24 hours. The code is rough in places and the repo contains Unity-generated files that should have been gitignored — I know, I learned that lesson here. The project is archived and not actively maintained.
