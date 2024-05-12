using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeo : Invert
{
    public Material normal;
    public Material inverse;
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
            gameObject.GetComponent<MeshRenderer>().material = inverse;
        }

        else
        {
            gameObject.GetComponent<MeshRenderer>().material = normal;
        }
    }
}
