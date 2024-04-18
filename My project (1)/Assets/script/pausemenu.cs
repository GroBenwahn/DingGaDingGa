using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    
    void Update()      
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(GameIsPaused) 
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume");

    }

/*if (pausemenu.GameIsPaused)
{
    source.pitch *= .5f;
}*/

    public void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("pause");
    }

}
