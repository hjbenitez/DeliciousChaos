using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    public Rigidbody _rb;

    private float moveHorizontal = 1;
    private float moveVertical = 1;

    public bool inverted = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (StaticValues.levelStarted)
        {
            
        }

        CheckInput();
    }

    public void CheckInput()
    {
        Vector3 movement = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.Mouse1)) //flip dimension
        {
            inverted = !inverted;
        }

        if (inverted == true) //controls inversed
        {
            if (Input.GetKey("w")) //up
            {
                movement = new Vector3(movement.x, movement.y, -moveVertical);
            }
            else if (Input.GetKey("s")) //down
            {
                movement = new Vector3(movement.x, movement.y, moveVertical);
            }

            if (Input.GetKey("a")) //left
            {
                movement = new Vector3(moveHorizontal, movement.y, movement.z);
            }
            else if (Input.GetKey("d")) //right
            {
                movement = new Vector3(-moveHorizontal, movement.y, movement.z);
            }
        }
        else //controls normal
        {
            if (Input.GetKey("w")) //up
            {
                movement = new Vector3(movement.x, movement.y, moveVertical);
            }
            else if (Input.GetKey("s")) //down
            {
                movement = new Vector3(movement.x, movement.y, -moveVertical);
            }

            if (Input.GetKey("a")) //left
            {
                movement = new Vector3(-moveHorizontal, movement.y, movement.z);
            }
            else if (Input.GetKey("d")) //right
            {
                movement = new Vector3(moveHorizontal, movement.y, movement.z);
            }
        }

        _rb.velocity = movement * movementSpeed;
    }
}
