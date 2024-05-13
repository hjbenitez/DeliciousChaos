using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceMan : Invert
{
    public GameObject NormalTexture;
    public GameObject InverseTexture;
    bool prevInvertState;

    private void Start()
    {
        prevInvertState = GameManager.inverted;
        InvertStatus();
    }

    private void Update()
    {
        if (prevInvertState != GameManager.inverted)
        {
            InvertStatus();
            prevInvertState = GameManager.inverted;
        }
    }

    public override void InvertStatus()
    {
        if (GameManager.inverted)
        {
            InverseTexture.SetActive(true);
            NormalTexture.SetActive(false);
        }

        else
        {
            InverseTexture.SetActive(false);
            NormalTexture.SetActive(true);
        }
    }
}
