using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 13.0f;
    private Rigidbody playerRb;

    private float zBound = 4;
    private float xBound = 11;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrictPlayerPosition();
    }
      

    //Moves player based on key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    //Constricts both z and x axis
    void ConstrictPlayerPosition()
    {
        //Restrict z axis
        if (transform.position.z< -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        //Restrict x axis
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }
}
