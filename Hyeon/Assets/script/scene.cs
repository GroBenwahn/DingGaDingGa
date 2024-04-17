using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//<- �̰� �ʼ� �Է�

public class Scen : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void Game_Exit()   //���� ����
    {
        Application.Quit();
        UnityEngine.Debug.Log("������ ����Ǿ����ϴ�.");
    }


    public void main_Scene()    // ��� �� 
    {
        SceneManager.LoadScene(0);   // ���� ���ÿ��� ������ ����
    }

    public void select_Scene()    // ���� ����Ʈ �� 
    {
        SceneManager.LoadScene(1);   // ���� ���ÿ��� ������ ����
    }

    public void option_Scene()    // ���� �� 
    {
        SceneManager.LoadScene(2);   // ���� ���ÿ��� ������ ����
    }

    public void In_Game_Scene()    // ���� �� 
    {
        SceneManager.LoadScene(4);   // ���� ���ÿ��� ������ ����
    }

    public void audio_scene()    // ���� �� 
    {
        SceneManager.LoadScene(3);   // ���� ���ÿ��� ������ ����
    }

    public void score_Scene()    // 스코어 씬 
    {
        SceneManager.LoadScene(5);   // 빌드 세팅에서 순위가 있음
    }
}