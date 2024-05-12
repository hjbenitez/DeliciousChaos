using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public TMPro.TextMeshProUGUI text;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI wavesText;

    public List<string> DeathQuotes;

    public bool dead;

    public GameObject deathUI;

    // Start is called before the first frame update
    void Start()
    {
        int quote = Random.Range(0, DeathQuotes.Count);

        text.text = DeathQuotes[quote];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            PauseGame();
        }

        if (StaticValues.playerDead && !dead)
        {
            wavesText.text = "Waves Survived: " + StaticValues.wave.ToString();
            scoreText.text = "Score: " + StaticValues.totalScore.ToString();

            deathUI.SetActive(true);
            Destroy(GameObject.Find("PlayerUI"));

            dead = true;
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        StaticValues.playerDead = false;
        SceneManager.LoadScene("YorickBlockOutFinal");
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
