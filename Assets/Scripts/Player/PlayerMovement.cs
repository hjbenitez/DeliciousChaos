using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public AudioSource sourceSFX;
    public AudioClip[] hitSoundClips;
    public AudioClip invertSFX;

    private InvertAbility invertAbility;

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
    float sfxMaxVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        invertAbility = gameObject.GetComponent<InvertAbility>();
        GameManager.StartGame();

        currentWeapon = machineFork;
        machineFork.gameObject.SetActive(true);
        cakeZooka.gameObject.SetActive(false);

        health = maxHealth;
        sourceSFX.volume = sfxMaxVolume * GameManager.sfxVolume * GameManager.mainVolume;

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


            if (health <= 0 && !dead)
            {
                AudioSource ass = GetComponent<AudioSource>();
                ass.time = 0.5f;
                ass.volume = sfxMaxVolume * GameManager.sfxVolume * GameManager.mainVolume;
                ass.Play();
                sourceSFX.Stop();
                GameManager.musicStop();

                foreach (Rigidbody rb in rbs)
                {
                    rb.isKinematic = false;
                    rb.gameObject.GetComponent<Collider>().isTrigger = false;
                    rb.AddForce(new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), ForceMode.Impulse);
                }

                GameManager.playerDead = true;
                dead = true;
            }

            CheckInput();

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
                ass2HUH.volume = sfxMaxVolume * GameManager.sfxVolume * GameManager.mainVolume;
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

        else
            {
                _rb.velocity = Vector3.zero;
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
        if (invertAbility.inverted)
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

        sourceSFX.clip = invertSFX;
        sourceSFX.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            health--;
            int i = Random.Range(0, 3);
            sourceSFX.clip = hitSoundClips[i];
            sourceSFX.Play();
        }
    }
}
