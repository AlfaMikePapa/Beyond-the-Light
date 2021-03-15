using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGbackgroundchanger : MonoBehaviour
{
    public Canvas bgcanvas;
    public Image srImage;

    //Check the collision to player and then change bg for ug.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("Pelaaja havaittu");
            srImage = bgcanvas.GetComponentInChildren<Image>();
            Destroy(srImage);
            //srImage.color = Color.black;
           
        }
    }

}
