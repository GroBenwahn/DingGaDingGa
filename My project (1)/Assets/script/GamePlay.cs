using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;


public class GamePlay : MonoBehaviour
{
    public Sound soundScript;
    public MidiCD midi; 
    public Playset playset;
    public static GamePlay Instance;
    public AudioSource audioSource;
    public AudioClip[] audioClips;


    void Start()
    {
        
        Instance = this;
        GetDataFromMidi(MidiCD. midiFile);
        Debug.Log("void Start() 작동중");
       
        int selectedClipIndex = FindObjectOfType<Sound>().selectedClipIndex;
        audioSource.clip = audioClips[selectedClipIndex];
        Debug.Log("ClipIndex" + selectedClipIndex);
        Debug.Log("sound 클립  작동중");

        float selectedSpeed = FindObjectOfType<Sound>().selectedSpeed;
        audioSource.pitch = selectedSpeed;
        Debug.Log("sound speed " + selectedSpeed);

    }


    public void GetDataFromMidi(MidiFile midiFile)
    {
        Debug.Log("GetDataFromMidi 작동중");
        if (midiFile != null)
        {
            var notes = midiFile.GetNotes();
            var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
            notes.CopyTo(array, 0);

            foreach (var lane in playset.lanes)
            {
                lane.SetTimeStamps(array);
            }

            Invoke(nameof(StartSong), playset.songDelayInSeconds);
        }
        else
        {
            Debug.LogError("MidiFile is null.");
        }
    }


    public void StartSong()
    {
        audioSource.Play();
    }


    public static double GetAudioSourceTime()
    {
            return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    void Update()
    {
        
    }
}
