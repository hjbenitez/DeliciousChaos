using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool inverted = false;

    private bool offCooldwon = true;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("UpdateCooldown");
    }

    // Update is called once per frame
    void Update()
    {
        ToggleDimension();

        StaticValues.inverted = inverted;

        Debug.Log(offCooldwon);
    }

    public void ToggleDimension()
    {
        if (offCooldwon == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1)) //flip dimension
            {
                inverted = !inverted;
                GetComponent<PlayerMovement>().Invert();

                StartCoroutine("UpdateCooldown");

                TimeSlow();

                Invoke("TimeRecovery", 1f);
                
                Invoke("ResetCooldown", 4f);
            }
        }
    }

    private IEnumerator UpdateCooldown()
    {
        offCooldwon = false;
        yield return new WaitForSeconds(5f);
    }

    public void ResetCooldown()
    {
        offCooldwon = true;
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
