using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public Weapon machineFork;
    public Weapon cakeZooka;
    Weapon currentWeapon;

    public float movementSpeed;
    private float moveHorizontal = 1;
    private float moveVertical = 1;

    private GameManager gameManager;

    public float maxHealth = 5f;
    [HideInInspector]
    public float health;

    Rigidbody _rb;

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
        currentWeapon = machineFork;

        machineFork.gameObject.SetActive(true);
        cakeZooka.gameObject.SetActive(false);

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, -0.25f, transform.position.z);
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

            if (fireRateTimer > currentWeapon.GetFireRate())
            {
                canFire = true;
                fireRateTimer = 0;
            }
        }
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

        _rb.velocity = movement.normalized * movementSpeed;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canFire)
            {
                Instantiate(currentWeapon.GetProjectile(), currentWeapon.GetNozzle().position + (transform.forward * 0.5f), transform.rotation);
                canFire = false;
            }
        }
    }

    public void Invert()
    {
        if (gameManager.inverted)
        {
            invertValue = -1;
            currentWeapon = cakeZooka;

            machineFork.gameObject.SetActive(false);
            cakeZooka.gameObject.SetActive(true);
        }

        else
        {
            invertValue = 1;
            currentWeapon = machineFork;

            machineFork.gameObject.SetActive(true);
            cakeZooka.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            health--;
        }
    }
}
