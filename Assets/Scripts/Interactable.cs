using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    // Start is called before the first frame update

    public Transform interacticon;

    void Start()
    {
        interactKey = KeyCode.Space;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != null)
        {
            if (collision.gameObject.CompareTag("Interact_Range"))
            {
                SpriteRenderer spriteRenderer = interacticon.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    // enable the sprite renderer
                    spriteRenderer.enabled = true;
                }
                isInRange = true;
                Debug.Log("Player in range");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interact_Range"))
        {
            SpriteRenderer spriteRenderer = interacticon.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // enable the sprite renderer
                spriteRenderer.enabled = false;
            }
            isInRange = false;
            Debug.Log("Player not in range");

        }
    }
}
