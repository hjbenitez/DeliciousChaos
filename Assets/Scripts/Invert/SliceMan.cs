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
        prevInvertState = StaticValues.inverted;
        InvertStatus();
    }

    private void Update()
    {
        if (prevInvertState != StaticValues.inverted)
        {
            InvertStatus();
            prevInvertState = StaticValues.inverted;
        }
    }

    public override void InvertStatus()
    {
        if (StaticValues.inverted)
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
