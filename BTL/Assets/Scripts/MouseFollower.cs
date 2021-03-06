using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseFollower : MonoBehaviour
{
    //Check where the mouse is and move the object there.
    public void Update()
    {
            Vector3 temp = Input.mousePosition;
            temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }

}
