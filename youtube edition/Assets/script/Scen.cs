using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //<- 이거 필수 입력

public class Scen : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void Game_Exit()   //게임 종료
    {
        Application.Quit();
    }


    public void F_Scen()    // 배경 씬 
    {
        SceneManager.LoadScene(0);   // 빌드 세팅에서 순위가 있음
    }

    public void S_Scen()    // 음악 리스트 씬 
    {
        SceneManager.LoadScene(1);   // 빌드 세팅에서 순위가 있음
    }

    public void Setting()    // 설정 씬 
    {
        SceneManager.LoadScene(2);   // 빌드 세팅에서 순위가 있음
    }

    public void In_Game_Scen()    // 게임 씬 
    {
        SceneManager.LoadScene(3);   // 빌드 세팅에서 순위가 있음
    }


}
