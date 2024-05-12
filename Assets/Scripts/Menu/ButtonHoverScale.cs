using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHoverScale : MonoBehaviour
{
    public void HoverEnter()
    {
        transform.localScale = new Vector2(1.1f, 1.1f);
    }

    public void HoverExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }
}
