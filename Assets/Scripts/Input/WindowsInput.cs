using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsInput : InputManager {
    

    public override float UseInput () {
        return Input.GetAxis("Horizontal");
    }
}
