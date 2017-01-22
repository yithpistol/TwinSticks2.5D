using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

    private bool gamePaused = false;
    private float fixedDeltaTime;

    private void Start()
    {
        PlayerPrefsManager.UnlockLevel(0);
        fixedDeltaTime = Time.fixedDeltaTime;
        print(fixedDeltaTime);
    }





    void Update() {

        if (CrossPlatformInputManager.GetButton("Fire1")) {
            recording = false;
        } else { recording = true; }

        if (Input.GetKeyDown(KeyCode.P) && gamePaused == false)
        {
            PauseGame();
            gamePaused = true;
        } else if (gamePaused==true && Input.GetKeyDown(KeyCode.P)){ Resume(); gamePaused = false; }


    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
    }

    void Resume()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

}
