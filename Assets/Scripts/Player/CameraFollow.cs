using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerVisual;

    public Texture2D cursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerVisual.position.x, this.transform.position.y, playerVisual.position.z- 8);
    }
}
