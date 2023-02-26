using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetDoor_Controller : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;

    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.SetBool("isOpen", isOpen);
        }
        else if (isOpen)
        {
            isOpen = false;
            animator.SetBool("isOpen", isOpen);
        }
    }
}
