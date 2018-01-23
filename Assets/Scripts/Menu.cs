using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void PlayGame() {
        SceneManager.LoadScene("3D");
    }

    public void Restart() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void ExitGame() {
        Debug.Log("No quitting in Editor.");
        Application.Quit();
    }
}
