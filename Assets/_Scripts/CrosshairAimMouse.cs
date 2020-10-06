using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAimMouse : MonoBehaviour
{
    public GameObject crosshair;

    public float X_MODIFY = 14.5f;
    public float Y_MODIFY = 2;
    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        worldPosition.x += X_MODIFY;
        worldPosition.y += Y_MODIFY;
        crosshair.transform.position = worldPosition;
    }
}
