using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidInput : InputManager {

    public Text text;

    private bool isRotating;
    private Vector3 startDir;
    private Vector3 newDir;
    private float angle;

    public override float UseInput() {
        if (Input.touchCount == 2) {
            // Get movement of the finger since last frame
            if (!isRotating) {
                Vector2 p1 = Input.GetTouch(0).position;
                Vector2 p2 = Input.GetTouch(1).position;

                startDir = p1 - p2;
                isRotating = true;
            }
            else {
                //doe hetzelfde, maar bereken nieuwe positie en vergelijk met startpositie
                Vector2 p1 = Input.GetTouch(0).position;
                Vector2 p2 = Input.GetTouch(1).position;

                newDir = p1 - p2;
                angle = AbsoluteAngleBetween(startDir, newDir);
                startDir = newDir;
            }

        }
        else {
            angle = 0;
            isRotating = false;
        }
        return -angle;
    }

    public static float AbsoluteAngleBetween(Vector3 a, Vector3 b) {
        a.Normalize();
        b.Normalize();
        Vector3 aP = RotateZ(a, 90);

        return (Mathf.Atan2(Vector3.Dot(aP, b), Vector3.Dot(a, b)) / Mathf.PI) * 180;
    }

    public static Vector3 RotateZ(Vector3 toRotate, float degrees) {
        degrees = Mathf.PI * degrees / 180;
        float xnew = Mathf.Cos(degrees)*toRotate.x - Mathf.Sin(degrees)*toRotate.y;
        float ynew = Mathf.Sin(degrees)*toRotate.x + Mathf.Cos(degrees)*toRotate.y;

        toRotate.x = xnew;
        toRotate.y = ynew;

        return toRotate;
    }
}
