using Melanchall.DryWetMidi.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_bt : MonoBehaviour
{
    public Sound_Speed soundSpeedScript;
    public MidiCD midicd;
    public float selectedSpeed;
    
    void Start()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void SpeedValue()
    {
        selectedSpeed = soundSpeedScript.GetSelectedSpeed();
        Debug.Log("soundspeed = " + selectedSpeed);
    }


    public void GetMidiData()
    {
        MidiFile midiFile = midicd.GetMidiFile();
       
        if (midiFile != null)
        {
            Debug.Log("Got MIDI file!");
        }
        else
        {
            Debug.LogError("MIDI file is null!");
        }
    }

        void Update()
    {
        
    }
}
