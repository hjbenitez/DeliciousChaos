using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI score;
    public Image hpBar;

    public Image waveBanner;
    public TextMeshProUGUI waveText;

    private PlayerMovement pm;

    
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = StaticValues.totalScore.ToString();

        hpBar.fillAmount = pm.health / pm.maxHealth;

        waveText.SetText("Wave " + StaticValues.wave.ToString());
    }
}
