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

        if (GameManager.playerDead && !dead)
        {
            wavesText.text = "Waves Survived: " + GameManager.wave.ToString();
            scoreText.text = "Score: " + GameManager.totalScore.ToString();

            deathUI.SetActive(true);
            Destroy(GameObject.Find("PlayerUI"));

            dead = true;
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.musicManager.ChangeMusic(0);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        GameManager.musicReset();
        GameManager.playerDead = false;
        SceneManager.LoadScene("YorickBlockOutFinal");
        Time.timeScale = 1;
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
