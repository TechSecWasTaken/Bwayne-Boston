using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        /*
        // PRINTS MOUSEPOS TO CONSOLE
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(mousePos);
        */

    }
    
}
