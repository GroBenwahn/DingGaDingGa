using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Speed : MonoBehaviour
{
    private static readonly string SelectedSpeedPref = "SelectedSpeedPref";
    private float selectedSpeedFloat;
   

    public float selectedSpeed;
    public void Music_Speed(float speed)
    {
        selectedSpeed = speed;
        selectedSpeedFloat = selectedSpeed;
        PlayerPrefs.SetFloat(SelectedSpeedPref, selectedSpeedFloat);
        Debug.Log(selectedSpeed);
        Debug.Log("selected" + selectedSpeedFloat);
        Debug.Log("selectedPref" + SelectedSpeedPref);
        Debug.Log(selectedSpeed);
    }

    
    public float GetSelectedSpeed()
    {
       return selectedSpeed;
    }
    
}
