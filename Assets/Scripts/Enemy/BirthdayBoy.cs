using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthdayBoy : EnemyInvert
{
    public List<GameObject> NormalTextures;
    public List<GameObject> InverseTextures;

    public override void InvertStatus()
    {
        if (StaticValues.inverted)
        {
            foreach (GameObject obj in InverseTextures)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in NormalTextures)
            {
                obj.SetActive(true);
            }
        }

        else
        {
            foreach (GameObject obj in InverseTextures)
            {
                obj.SetActive(true);
            }

            foreach (GameObject obj in NormalTextures)
            {
                obj.SetActive(false);
            }
        }
    }
}
