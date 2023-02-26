using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMaskController : MonoBehaviour
{
    public string maskObjectTag = "Transparent_Overlay";
    //public Transform maskObject;
    private SpriteRenderer spriteRenderer;
    public List<Transform> maskObjects;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        maskObjects = new List<Transform>();
        GameObject[] maskObjectArray = GameObject.FindGameObjectsWithTag(maskObjectTag);
        foreach (GameObject maskObject in maskObjectArray)
        {
            maskObjects.Add(maskObject.transform);
        }
    }

    private void Update()
    {
        bool isVisible = false;
        foreach (Transform maskObject in maskObjects)
        {
            // Check if the sprite's Y value is greater than the mask object's Y value
            if (transform.position.y > maskObject.position.y)
            {
                isVisible = true;
                SpriteMask spriteMask = maskObject.GetComponent<SpriteMask>();
                if (spriteMask != null)
                {
                    spriteMask.enabled = true;
                }
            }
            else
            {
                // Disable the sprite mask on the mask object if the sprite is below the mask object
                SpriteMask spriteMask = maskObject.GetComponent<SpriteMask>();
                if (spriteMask != null)
                {
                    spriteMask.enabled = false;
                }
            }
        }
        // Set the sprite renderer to enable/disable the sprite based on visibility
        spriteRenderer.enabled = isVisible;
    }

}