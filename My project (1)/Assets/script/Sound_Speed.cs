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
   
    private static readonly string SelectedBPMPref = "SelectedBPMPref";
    private float selectedBPMFloat;
    public float selectedBPM;

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

    public void Music_BPM(float BPM)
    {
        selectedBPM = BPM;
        selectedBPMFloat = selectedBPM;
        PlayerPrefs.SetFloat(SelectedBPMPref, selectedBPMFloat);
        Debug.Log(selectedBPM);
        Debug.Log("selected" + selectedBPMFloat);
        Debug.Log("selectedPref" + SelectedBPMPref);
        Debug.Log(selectedBPM);
    }
    public float GetSelectedBPM()
    {
        return selectedBPM;
    }

}
