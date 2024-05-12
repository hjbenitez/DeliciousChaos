using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public Weapon machineFork;
    public Weapon cakeZooka;
    Weapon currentWeapon;

    public List<Rigidbody> rbs;

    public float movementSpeed;
    private float moveHorizontal = 1;
    private float moveVertical = 1;
    private bool dead;
    public Animator anim;

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

    private int numberOfTricks;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        gameManager = gameObject.GetComponent<GameManager>();

        currentWeapon = machineFork;
        machineFork.gameObject.SetActive(true);
        cakeZooka.gameObject.SetActive(false);

        health = maxHealth;

        foreach (Rigidbody rb in rbs)
        {
            rb.gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, -0.25f, transform.position.z);

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * 1f;
        mouseDirection = mouseRay.origin + mouseRay.direction * midPoint;

        mouseDirection.y = transform.position.y;

        if (!dead)
        {
            this.transform.LookAt(mouseDirection);
        }



        if (health <= 0 && !dead)
        {
            AudioSource ass = GetComponent<AudioSource>();
            ass.time = 0.5f;
            ass.Play();

            foreach(Rigidbody rb in rbs)
            {
                rb.isKinematic = false;
                rb.gameObject.GetComponent<Collider>().isTrigger = false;
                rb.AddForce(new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), ForceMode.Impulse);
            }

            StaticValues.playerDead = true;
            dead = true;
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

        if (Input.GetKeyDown("space"))
        {
            AudioSource ass2HUH = anim.gameObject.GetComponent<AudioSource>();
            ass2HUH.pitch = 1;

            int tricktype = Random.Range(0, 2);

            if (numberOfTricks >= 8)
            {
                tricktype = 2;
                numberOfTricks = 0;
                ass2HUH.pitch = 0.5f;
            }

            ass2HUH.time = 0;
            ass2HUH.Play();

            anim.SetInteger("TrickNum", tricktype);
            anim.SetTrigger("Trick");

            numberOfTricks++;
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
                currentWeapon.PlaySFX();
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
