using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.SceneManagement;

public class MusicImage : MonoBehaviour
{
    // ��ư�� �ش��ϴ� �̹��� ���� �̸� �߰� ���� 
    public string aImageName = "[Busker Busker - Topic] ���� ���� (KvthiAoGTfo)"; 
    public string bImageName = "c.va"; 

    public void LoadThirdScene(string buttonName)
    {
        // �ش� ��ư�� ���� �̹��� ���� �̸��� PlayerPrefs�� ����
        if (buttonName == "song_1")
        {
            PlayerPrefs.SetString("ImageName", aImageName);
            Debug.Log(" image.texture : " + aImageName);
        }
        else if (buttonName == "song_2")
        {
            PlayerPrefs.SetString("ImageName", bImageName);
            Debug.Log(" image.texture : " + bImageName);
        }

    }
}
