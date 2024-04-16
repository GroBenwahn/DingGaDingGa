using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Sound : MonoBehaviour
{

    public int selectedClipIndex;

    public float selectedSpeed;
    public Sound_Speed soundSpeedScript;

    void Start()
    {
        soundSpeedScript = FindObjectOfType<Sound_Speed>();
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
        
        Debug.Log("sound" + selectedClipIndex); 

    }

    public void SpeedValue()
    {
        selectedSpeed = soundSpeedScript.GetSelectedSpeed();
        Debug.Log("sound" + selectedSpeed);
    }
    
}
