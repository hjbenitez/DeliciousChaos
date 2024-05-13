using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapImage : MonoBehaviour
{
    public Image icon;

    public Sprite normalImg;
    public Sprite invertedImg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticValues.inverted)
        {
            icon.sprite = invertedImg;
        }
        else
        {
            icon.sprite = normalImg;
        }
    }
}
