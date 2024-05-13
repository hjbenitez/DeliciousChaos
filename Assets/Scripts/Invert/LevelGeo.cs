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
            gameObject.GetComponent<MeshRenderer>().material = inverse;
        }

        else
        {
            gameObject.GetComponent<MeshRenderer>().material = normal;
        }
    }
}
