using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{

    public GameObject[] PathNode;
    public GameObject Valopallo;
    public float MoveSpeed;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        CheckNode();
    }

    void CheckNode()
    {
        Timer = 0;
        startPosition = Valopallo.transform.position;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * MoveSpeed;

        if (Valopallo.transform.position != CurrentPositionHolder)
        {
                Valopallo.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
        }
        else
        {
            if (CurrentNode < PathNode.Length - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) //Movespeed to 0.3f when player in range
    {
        if (col.gameObject.tag == "Player")
        {
            MoveSpeed = 0.3f;
        }
    }

    private void OnTriggerExit2D(Collider2D col) //Movespeed to 0.0f when player is out of range
    {
        if (col.gameObject.tag == "Player")
        {
            MoveSpeed = 0.0f;
        }
    }
}
