using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scen : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void Game_Exit()   
    {
        Application.Quit();
        UnityEngine.Debug.Log("game_exit");
    }


    public void main_Scene()   
    {
        SceneManager.LoadScene(0);   
        
    }

    public void select_Scene()    
    {
        SceneManager.LoadScene(1);   
    }

    public void option_Scene()    
    {
        SceneManager.LoadScene(2);   
    }

    public void In_Game_Scene()    
    {
        SceneManager.LoadScene(4);   
    }

    public void audio_scene()    
    {
        SceneManager.LoadScene(3);   
    }
    
    public void score_Scene()    
    {
        SceneManager.LoadScene(5);   
    }
}