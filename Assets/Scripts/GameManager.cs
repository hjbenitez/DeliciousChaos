using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool inverted = false;

    private bool offCooldown = true;

    public Image abilityImage;

    public float cooldown = 5f;

    public AudioSource music;
    public AudioSource musicInvert;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ToggleDimension();

        if (StaticValues.enemyCount <= 0)
        {
            StaticValues.NextWave();
        }

        UpdateIcon();

        StaticValues.inverted = inverted;

        if(StaticValues.inverted)
        {
            music.volume = 0f;
            musicInvert.volume = 0.5f;
        }

        else
        {
            music.volume = 0.5f;
            musicInvert.volume = 0f;
        }

        Debug.Log(offCooldown);
    }

    //public void ToggleDimension()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse1) && offCooldown == true) //flip dimension
    //    {
    //        inverted = !inverted;
    //        GetComponent<PlayerMovement>().Invert();

    //        StartCoroutine("UpdateCooldown");

    //        TimeSlow();

    //        Invoke("TimeRecovery", 1f);

    //        Invoke("ResetCooldown", 4f);
    //    }
    //}

    public void UpdateIcon()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && offCooldown == true)
        {
            inverted = !inverted;
            GetComponent<PlayerMovement>().Invert();

            TimeSlow();

            Invoke("TimeRecovery", 1f);

            offCooldown = false;
            abilityImage.fillAmount = 1;
        }

        if (offCooldown == false)
        {
            abilityImage.fillAmount -= 1 / cooldown * Time.deltaTime;

            if(abilityImage.fillAmount <= 0)
            {
                abilityImage.fillAmount = 0;
                offCooldown = true;
            }
        }
    }

    private IEnumerator UpdateCooldown()
    {
        offCooldown = false;
        yield return new WaitForSeconds(5f);
    }

    public void ResetCooldown()
    {
        offCooldown = true;
    }
    
    public void TimeSlow()
    {
        Time.timeScale = 0.5f;
    }
    
    public void TimeRecovery()
    { 
        Time.timeScale = 1f;
    }
}
