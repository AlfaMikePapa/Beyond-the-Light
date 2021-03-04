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

    public bool PlayerIsClose = false;
    //public GameObject Player;

    // Use this for initialization
    void Start()
    {
        //PathNode = GetComponentInChildren<>();
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
        if (PlayerIsClose == true)
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
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerIsClose = true;
        }
    }
}
