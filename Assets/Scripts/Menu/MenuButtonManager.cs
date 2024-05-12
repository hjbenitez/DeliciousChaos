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
        SceneManager.LoadScene("YorickBlockOutFinal");
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ClickReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickMenuOptions()
    {
        SceneManager.LoadScene("MenuOptions");
    }

    public void ClickCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
