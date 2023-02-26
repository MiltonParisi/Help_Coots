using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Opacity : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, .2f); //50 % transparent
    }
}
