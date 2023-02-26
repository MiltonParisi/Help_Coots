using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationDOWN : MonoBehaviour
{
    public bool playAnim;
    public Animator animator;
    public float timer;

    public Transform target;

    public void PlayAnim()
    {
        if (!playAnim)
        {
            playAnim = true;
            animator.SetBool("playAnim", playAnim);

            SpriteRenderer spriteRenderer = animator.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // enable the sprite renderer
                spriteRenderer.enabled = true;
            }

            // Find all objects with the "Player" tag and disable their components
            GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject playerObject in playerObjects)
            {
                TopDown_Controller controller = playerObject.GetComponent<TopDown_Controller>();
                if (controller != null)
                {
                    controller.enabled = false;
                    controller.body.velocity = new Vector2(0, 0);
                }

                SpriteMaskController controller2 = playerObject.GetComponent<SpriteMaskController>();
                if (controller2 != null)
                {
                    controller2.enabled = false;
                }

                BoxCollider2D collider = playerObject.GetComponent<BoxCollider2D>();
                if (collider != null)
                {
                    collider.enabled = false;
                }

                SpriteRenderer playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
                if (playerSpriteRenderer != null)
                {
                    playerSpriteRenderer.enabled = false;
                }
            }

            // Find all objects with the "Interact_Range" tag and disable their components
            GameObject[] interactObjects = GameObject.FindGameObjectsWithTag("Interact_Range");
            foreach (GameObject interactObject in interactObjects)
            {
                BoxCollider2D interactcollider = interactObject.GetComponent<BoxCollider2D>();
                if (interactcollider != null)
                {
                    interactcollider.enabled = false;
                }
            }

            GameObject obj = GameObject.Find("Coots");
            obj.transform.position = target.transform.position;

        }
        else if (playAnim)
        {
            playAnim = false;
            animator.SetBool("playAnim", playAnim);

            SpriteRenderer spriteRenderer = animator.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // enable the sprite renderer
                spriteRenderer.enabled = false;
            }
        }
        Invoke(nameof(SetToFalse), timer);
    }

    private void SetToFalse()
    {
        playAnim = false;
        animator.SetBool("playAnim", playAnim);

        SpriteRenderer spriteRenderer = animator.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // enable the sprite renderer
            spriteRenderer.enabled = false;
        }

        // Find all objects with the "Player" tag and disable their components
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerObjects)
        {
            TopDown_Controller controller = playerObject.GetComponent<TopDown_Controller>();
            if (controller != null)
            {
                controller.enabled = true;
                controller.lastMoveDirection = Vector2.down;
            }

            BoxCollider2D collider = playerObject.GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }

            SpriteMaskController controller2 = playerObject.GetComponent<SpriteMaskController>();
            if (controller2 != null)
            {
                controller2.enabled = true;
            }


            SpriteRenderer playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
            if (playerSpriteRenderer != null)
            {
                playerSpriteRenderer.sortingLayerName = "Middle";
                playerSpriteRenderer.enabled = true;
            }
        }

        // Find all objects with the "Interact_Range" tag and disable their components
        GameObject[] interactObjects = GameObject.FindGameObjectsWithTag("Interact_Range");
        foreach (GameObject interactObject in interactObjects)
        {
            BoxCollider2D interactcollider = interactObject.GetComponent<BoxCollider2D>();
            if (interactcollider != null)
            {
                interactcollider.enabled = true;
            }
        }

    }
}
