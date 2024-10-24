using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //IF Esc key pressed
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            //Display pause menu
            GetComponent<Canvas>().enabled = true;

            //Pause game
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0) 
        {
            Resume();
        }
    }
    public void Resume()
    {
        //Hide pause menu
        GetComponent<Canvas>().enabled = false;
        //Reset time scale
        Time.timeScale = 1;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void QuitGame()
    { 
        Application.Quit();
    }
}
