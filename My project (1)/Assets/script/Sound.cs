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
        selectedClipIndex = clipIndex; // ���õ� AudioClip�� �ε����� �����մϴ�.
        
        Debug.Log("soundClipIndex = " + selectedClipIndex); 

    }
    
}
