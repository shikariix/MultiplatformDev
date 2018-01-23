using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    private CameraScript cs;

    void Start() {
        cs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
    }

	void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Game Finished!");
            cs.KillControls();
        }
    }
}
