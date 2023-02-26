using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererChecker : MonoBehaviour
{
    public GameObject targetObject; // The specific object to check
    public GameObject targetObject2; // The specific object to check

    public SpriteRenderer spriteRenderer; // Reference to the sprite renderer component of the code holder

    public float timer;

    void Update()
    {
        Invoke(nameof(CheckSpriteRenderer), timer);
    }

    void CheckSpriteRenderer()
    {
        SpriteRenderer targetSpriteRenderer = targetObject.GetComponent<SpriteRenderer>();
        SpriteRenderer targetSpriteRenderer2 = targetObject2.GetComponent<SpriteRenderer>();

        if (targetSpriteRenderer != null && !targetSpriteRenderer.enabled && !targetSpriteRenderer2.enabled)
        {
            spriteRenderer.enabled = true; // Turn on the sprite renderer of the code holder
        }

        if (spriteRenderer.enabled == true)
        {
            AlphaFadeIn alphaFade = transform.GetComponent<AlphaFadeIn>();
            if (alphaFade != null)
            {
                alphaFade.enabled = true;
            }
        }
    }
}
