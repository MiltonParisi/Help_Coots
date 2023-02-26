using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Objective_Render_Handler : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float overlapRadius = 1.0f;

    public Image inventoryIcon;

    // Update is called once per frame
    void Update()
    {
        // Find all objects with the CabinetDoor_Controller script
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, overlapRadius);
        List<CabinetDoor_Controller> cabinets = new List<CabinetDoor_Controller>();

        // Check if each collider is a CabinetDoor_Controller and has an open door
        foreach (Collider2D collider in colliders)
        {
            CabinetDoor_Controller cabinet = collider.gameObject.GetComponent<CabinetDoor_Controller>();
            if (cabinet != null && cabinet.isOpen)
            {
                cabinets.Add(cabinet);
            }
        }

        // Find the nearest cabinet with an open door
        CabinetDoor_Controller nearestCabinet = null;
        float nearestDistance = float.MaxValue;

        foreach (CabinetDoor_Controller cabinet in cabinets)
        {
            float distance = Vector2.Distance(transform.position, cabinet.transform.position);

            if (distance < nearestDistance)
            {
                nearestCabinet = cabinet;
                nearestDistance = distance;
            }
        }

        // Check if a nearest cabinet with an open door was found
        if (nearestCabinet != null)
        {
            // Activate the sprite renderer of the object holding the script
            spriteRenderer.enabled = true;

            if(inventoryIcon != null)
            {
                inventoryIcon.enabled = true;
            }
        }
        else
        {
            // Deactivate the sprite renderer if no nearest cabinet with an open door was found
            spriteRenderer.enabled = false;
        }
    }

    // Draw a gizmo in the editor to visualize the overlap sphere
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, overlapRadius);
    }
}



