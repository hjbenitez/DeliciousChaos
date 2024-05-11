using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    private float moveHorizontal = 1;
    private float moveVertical = 1;

    private GameManager gameManager;


    Rigidbody _rb;
    public Projectile projectile;
    public Projectile projectileInverted;
    Projectile currentProjectile;

    float invertValue = 1;

    //Fire Rate
    float fireRateTimer = 0f;
    bool canFire = true;

    //Mouse
    Vector3 mouseDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        gameManager = gameObject.GetComponent<GameManager>();
        currentProjectile = projectile;
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * 1f;
        mouseDirection = mouseRay.origin + mouseRay.direction * midPoint;

        mouseDirection.y = transform.position.y;

        this.transform.LookAt(mouseDirection);


        //if (StaticValues.levelStarted)
        {

        }

        CheckInput();
        //print(fireRateTimer);

        if (!canFire)
        {
            fireRateTimer += Time.deltaTime;

            if (fireRateTimer > currentProjectile.GetFireRate())
            {
                canFire = true;
                fireRateTimer = 0;
            }
        }

        print(currentProjectile.GetFireRate());
    }

    public void CheckInput()
    {
        Vector3 movement = new Vector3(0, 0, 0);

        if (Input.GetKey("w")) //up
        {
            movement = new Vector3(movement.x, movement.y, moveVertical * invertValue);
        }
        else if (Input.GetKey("s")) //down
        {
            movement = new Vector3(movement.x, movement.y, -moveVertical * invertValue);
        }

        if (Input.GetKey("a")) //left
        {
            movement = new Vector3(-moveHorizontal * invertValue, movement.y, movement.z);
        }
        else if (Input.GetKey("d")) //right
        {
            movement = new Vector3(moveHorizontal * invertValue, movement.y, movement.z);
        }

        _rb.velocity = movement * movementSpeed;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canFire)
            {
                Instantiate(currentProjectile.gameObject, transform.position + (transform.forward * 0.5f), transform.rotation);
                canFire = false;
            }
        }
    }

    public void Invert()
    {
        if (gameManager.inverted)
        {
            invertValue = -1;
            currentProjectile = projectileInverted;
        }

        else
        {
            invertValue = 1;
            currentProjectile = projectile;
        }
    }
}
