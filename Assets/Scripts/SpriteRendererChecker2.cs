using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererChecker2 : MonoBehaviour
{
    public GameObject targetObject; // The specific object to check
    public SpriteRenderer spriteRenderer; // Reference to the sprite renderer component of the code holder

    public float timer;

    void Update()
    {
        Invoke(nameof(CheckSpriteRenderer), timer);
    }

    void CheckSpriteRenderer()
    {
        SpriteRenderer targetSpriteRenderer = targetObject.GetComponent<SpriteRenderer>();
        Interactable interactable = transform.GetComponent<Interactable>();

        if (targetSpriteRenderer != null && targetSpriteRenderer.enabled)
        {
            spriteRenderer.enabled = true; // Turn on the sprite renderer of the code holder
        }

        if (interactable != null && targetSpriteRenderer.enabled)
        {
            interactable.enabled = false;
            BoxCollider2D boxCollider = transform.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }
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
