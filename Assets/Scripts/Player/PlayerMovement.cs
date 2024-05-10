using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    Rigidbody rb;

    public float moveVertical = 1;
    public float moveHorizontal = 1;

    public bool inverted = false;

    public GameObject projectile;
    public GameObject projectileInverted;

    //Fire Rate
    public float fireRate = 2f;
    float fireRateTimer = 0f;
    bool canFire = true;

    //Mouse
    Vector3 mouseDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * 0.5f;
        mouseDirection = mouseRay.origin + mouseRay.direction * midPoint;

        mouseDirection.y = transform.position.y;

        this.transform.LookAt(mouseDirection);


        //if (StaticValues.levelStarted)
        {

        }

        CheckInput();
        print(fireRateTimer);

        if (!canFire)
        {
            fireRateTimer += Time.deltaTime;

            if (fireRateTimer > fireRate)
            {
                canFire = true;
                fireRateTimer = 0;
            }
        }
    }

    public void CheckInput()
    {
        Vector3 movement = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Mouse1)) //flip dimension
        {
            inverted = !inverted;
        }

        if (inverted == true)
        {
            if (Input.GetKeyDown("w")) //up
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
        else
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

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canFire)
            {
                Instantiate(projectile, transform.position + (transform.forward * 0.5f), transform.rotation);
                canFire = false;
            }
        }
        rb.velocity = movement * movementSpeed;
    }
}
