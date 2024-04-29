using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.SceneManagement;

public class MusicImage : MonoBehaviour
{
    // 버튼에 해당하는 이미지 파일 이름 추가 가능 
    public string aImageName = "[Busker Busker - Topic] 벚꽃 엔딩 (KvthiAoGTfo)"; 
    public string bImageName = "c.va"; 

    public void LoadThirdScene(string buttonName)
    {
        // 해당 버튼에 대한 이미지 파일 이름을 PlayerPrefs에 저장
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
