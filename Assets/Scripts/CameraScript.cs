using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {


    Vector3 gravity = new Vector3(0, -9.81f, 0);
    public Transform target;
    private float input;
    private bool playing = true;

    private InputManager im;

    public Text text;
    public GameObject replay;
    private float playTime = 0;

    void Awake() {
        im = InputManager.GetInstance();
    }

    void FixedUpdate () {
        if (playing) { 
            transform.position = new Vector3 (target.position.x, target.position.y, -10);
            playTime += Time.deltaTime;

            input = im.UseInput();

            //was used for debugging; now irrelevant
            //text.text = "Angle is: " + input;
            text.text = "";

            if (input != 0) {
                TurnCamera(input);
            }

            Physics.gravity = gravity * 2;
        } else {
            text.text = "You win!\n" + (int)playTime + " seconds";
            replay.SetActive(true);
        }
    }

    public void KillControls() {
        playing = false;
    }

    public void TurnCamera(float value) {
        transform.Rotate(0, 0, value);
        gravity = -transform.up * 10;
    }
}
