using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaFadeIn : MonoBehaviour
{
    public float duration = 1.0f; // The duration of the fade-in effect in seconds
    public SpriteRenderer spriteRenderer; // Reference to the sprite renderer component

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0;
        Color spriteColor = spriteRenderer.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsedTime / duration); // Calculate the alpha value based on the elapsed time and duration
            spriteColor.a = alpha; // Set the alpha value of the sprite renderer's color property
            spriteRenderer.color = spriteColor; // Update the sprite renderer's color property
            yield return null;
        }
        spriteColor.a = 1; // Ensure the final alpha value is set to 1
        spriteRenderer.color = spriteColor; // Update the sprite renderer's color property
    }
}
