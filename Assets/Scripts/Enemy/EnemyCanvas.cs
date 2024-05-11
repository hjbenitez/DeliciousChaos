using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCanvas : MonoBehaviour
{
    public Canvas canvasComp;
    public Image healthBar;
    public Transform canvasPos;

    private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(canvasPos.position.x, canvasPos.position.y + 1.5f, canvasPos.position.z + 0.9f);

        transform.LookAt(transform.position + cam.forward);
    }
}
