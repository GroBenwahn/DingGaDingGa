using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Sound : MonoBehaviour
{
    public int selectedClipIndex;

    void Start()
    {
        
    }


    void Update()
    {

    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetClipIndex(int clipIndex)
    {
        selectedClipIndex = clipIndex; // 선택된 AudioClip의 인덱스를 저장합니다.
        
        Debug.Log("soundClipIndex = " + selectedClipIndex); 

    }
    
}
