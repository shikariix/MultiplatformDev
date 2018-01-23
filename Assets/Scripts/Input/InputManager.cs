using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager {

    public static InputManager GetInstance() {
        switch (Application.platform) {
#if !DISABLE_SYSTEM
            case RuntimePlatform.WindowsPlayer:
                return new WindowsInput();
            case RuntimePlatform.Android:
                //would be nice if this one worked on iphone too. might test that someday
                return new AndroidInput();
#endif
            default:
                //Does nothing, always "succeeds" its requested actions. This is for working in editor mainly.
                //setting this to WindowsInput for now, since the code would be exactly the same and that gave an error
                return new WindowsInput();
        }
    }

    //abstract "function prototype", that needs to be implemented in the extending class (just like an interface)
    public abstract float UseInput();
    
}
