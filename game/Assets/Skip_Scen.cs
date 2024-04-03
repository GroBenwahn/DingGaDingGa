using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //<- �̰� �ʼ� �Է�

public class Skip_Scen : MonoBehaviour
{
   
    private int previousSceneIndex;  // ���� �޴� �̾��ϱ� ��ư ���� ���� �ε����� �����ϱ� ���� ����

    void Start()
    {
        // Game_Load(); ������ �� �ҷ����� 
        previousSceneIndex = PlayerPrefs.GetInt("PreviousSceneIndex", 2);  // ���� 2 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F8))   // F8 ������ ������ ������ �̵�
        {
            SceneManager.LoadScene(4);
        }
    }

    public void Game_Exit()   //���� ����
    {
        Application .Quit();
    }

    /*public void Game_Save()  // ����  ���� ������ ������
    {
        
    }
    
    public void Game_Load()  //�ҷ����� 
    {
        if (!PlayerPrefs.HasKey(" .... "))   // �ʼ� 
            return;
    }
    */

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
        SceneManager.LoadScene(previousSceneIndex);   // ���� ���ÿ��� ������ ����
    }

    public void In_Game_Scen()    // ���� �� 
    {
        SceneManager.LoadScene(3);   // ���� ���ÿ��� ������ ����
    }

    
}
