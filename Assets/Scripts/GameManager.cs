using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool inverted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ToggleDimension();

        StaticValues.inverted = inverted;
    }

    public void ToggleDimension()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) //flip dimension
        {
            inverted = !inverted;
            GetComponent<PlayerMovement>().Invert();
        }
    }
}
