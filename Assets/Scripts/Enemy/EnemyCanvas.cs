using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCanvas : MonoBehaviour
{
    public Canvas canvasComp;
    public GameObject exclimation;
    public GameObject healthBar;
    public GameObject damageNumberObjPrefab;
    public Transform canvasPos;

    private bool damageTimerTicking;
    private float timer;
    private GameObject currentDamageNumObj;

    private int damageNumShown;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DamageNumber(int damageTaken)
    {
        timer = 0;
        damageTimerTicking = true;

        if(currentDamageNumObj != null)
        {
            Destroy(currentDamageNumObj);
        }

        damageNumShown += damageTaken;

        currentDamageNumObj = Instantiate(damageNumberObjPrefab, canvasComp.transform);
        currentDamageNumObj.GetComponent<Text>().text = damageNumShown.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(canvasPos.position.x, canvasPos.position.y + 0.5f, canvasPos.position.z + 0.9f);

        if (damageTimerTicking && timer < 2)
        {
            timer += Time.deltaTime;
        }
        else if(damageTimerTicking && timer > 2)
        {
            damageNumShown = 0;
            Destroy(currentDamageNumObj);

            damageTimerTicking = false;
            timer = 0;
        }
    }
}
