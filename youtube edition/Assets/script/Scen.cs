using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //<- �̰� �ʼ� �Է�

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
    }


    public void F_Scen()    // ��� �� 
    {
        SceneManager.LoadScene(0);   // ���� ���ÿ��� ������ ����
    }

    public void S_Scen()    // ���� ����Ʈ �� 
    {
        SceneManager.LoadScene(1);   // ���� ���ÿ��� ������ ����
    }

    public void Setting()    // ���� �� 
    {
        SceneManager.LoadScene(2);   // ���� ���ÿ��� ������ ����
    }

    public void In_Game_Scen()    // ���� �� 
    {
        SceneManager.LoadScene(3);   // ���� ���ÿ��� ������ ����
    }


}
