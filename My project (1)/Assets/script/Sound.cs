using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Sound : MonoBehaviour
{
    private static readonly string SelectedClipIndexPref = "SelectedClipIndexPref";

    private int SelectedClipIndexint;
    public int selectedClipIndex;

    void Start()
    {
        
    }


    void Update()
    {

    }


    public void SetClipIndex(int clipIndex)
    {
        selectedClipIndex = clipIndex; // 선택된 AudioClip의 인덱스를 저장합니다.
        SelectedClipIndexint = selectedClipIndex;
        PlayerPrefs.SetInt(SelectedClipIndexPref, SelectedClipIndexint);


        Debug.Log("soundClipIndex = " + selectedClipIndex); 

    }
    
}
