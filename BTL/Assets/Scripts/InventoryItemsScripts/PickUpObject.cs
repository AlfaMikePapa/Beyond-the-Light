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


/*

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaffPickUp : MonoBehaviour
{

    [SerializeField]
    // private Text pickUpText;

    private bool pickUpAllowed;

  
    // Use this for initialization
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }
    

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            //  pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
            Debug.Log("OTA SAUVA SAaTANA ");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            //  pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }

}
*/