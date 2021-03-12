using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform target;
    public float smoothing;

    public bool stopFollowing;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (stopFollowing == false)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }
        }
    }
}
