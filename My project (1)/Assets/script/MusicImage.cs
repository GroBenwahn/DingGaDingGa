using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.SceneManagement;

public class MusicImage : MonoBehaviour
{
    // ��ư�� �ش��ϴ� �̹��� ���� �̸� �߰� ���� 
    public string aImageName = "���ɿ���"; 
    public string bImageName = "�����ǹ�";
    public string cImageName = "�Ƶ�����";
    public string dImageName = "����Ʈ����";

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
        else if (buttonName == "song_3")
        {
            PlayerPrefs.SetString("ImageName", cImageName);
            Debug.Log(" image.texture : " + cImageName);
        }
        else if (buttonName == "song_4")
        {
            PlayerPrefs.SetString("ImageName", dImageName);
            Debug.Log(" image.texture : " + dImageName);
        }

    }
}
