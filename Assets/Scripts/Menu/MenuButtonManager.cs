using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
