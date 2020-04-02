using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Vector3 movement;
    public Vector3 stopMovement;
    public float moveSpeed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement.y = moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement.y = -moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.x = moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement.x = -moveSpeed;
        }


        transform.position += movement;
        movement = stopMovement;
    }
}
