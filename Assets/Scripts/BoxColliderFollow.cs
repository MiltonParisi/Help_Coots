using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxColliderFollow : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public Transform up;
    public Transform down;

    private void Update()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (inputDirection != Vector2.zero) // check if player is moving
        {
            // decrease distance only when player is moving down
            if (inputDirection.y < 0)
            {
                transform.position = down.position;
            }
            else if (inputDirection.y > 0)
            {
                transform.position = up.position;
            }
            else if (inputDirection.x > 0)
            {
                transform.position = right.position;
            }
            else if (inputDirection.x < 0)
            {
                transform.position = left.position;
            }
        }
    }
}
