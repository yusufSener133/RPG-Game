using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility 
{
    public static float AngleTowardsMouse(Vector3 _pos)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(_pos);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        return angle;
    }
}
