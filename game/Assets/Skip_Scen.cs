using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //<- 이거 필수 입력

public class Skip_Scen : MonoBehaviour
{
   
    private int previousSceneIndex;  // 서브 메뉴 이어하기 버튼 이전 씬의 인덱스를 저장하기 위한 변수

    void Start()
    {
        // Game_Load(); 저장한 값 불러오기 
        previousSceneIndex = PlayerPrefs.GetInt("PreviousSceneIndex", 2);  // 빌드 2 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F8))   // F8 누르면 개발자 씬으로 이동
        {
            SceneManager.LoadScene(4);
        }
    }

    public void Game_Exit()   //게임 종료
    {
        Application .Quit();
    }

    /*public void Game_Save()  // 저장  게임 데이터 넣을것
    {
        
    }
    
    public void Game_Load()  //불러오기 
    {
        if (!PlayerPrefs.HasKey(" .... "))   // 필수 
            return;
    }
    */

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
        SceneManager.LoadScene(previousSceneIndex);   // 빌드 세팅에서 순위가 있음
    }

    public void In_Game_Scen()    // 게임 씬 
    {
        SceneManager.LoadScene(3);   // 빌드 세팅에서 순위가 있음
    }

    
}
