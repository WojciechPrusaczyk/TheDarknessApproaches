using System;
using System.Collections;
using UnityEngine;

public class Anim:MonoBehaviour
{
    public Sprite[] characteranimationSprites;
    public SpriteRenderer characterRenderer;
    private Coroutine runningRoutine;
    private bool isPlaying = false;
    public IEnumerator Animacja()
    {

        yield return null;
        int spriteIndex = 0;

        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            characterRenderer.sprite = characteranimationSprites[spriteIndex++];
            if (spriteIndex >= characteranimationSprites.Length)
                spriteIndex = 0;

        }
    }

    internal void Stop()
    {
        isPlaying = false;
        if (runningRoutine != null)
            StopCoroutine(runningRoutine);
    }

    internal void Play()
    {

        if (!isPlaying)
        {
            runningRoutine = StartCoroutine(Animacja());
        }
        isPlaying = true;
    }
}
