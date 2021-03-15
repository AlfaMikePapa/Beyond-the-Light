using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : Interactable
{

    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        // Add item to inventory
        Debug.Log("Picking up " + item.name);
        // Destroys the object from world
        Destroy(gameObject);
    }


}
