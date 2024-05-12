using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public Image hpBar;

    private PlayerMovement pm;
    
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = StaticValues.totalScore.ToString();

        hpBar.fillAmount = pm.health / pm.maxHealth;
    }
}
