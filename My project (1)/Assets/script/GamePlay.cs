using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;


public class GamePlay : MonoBehaviour
{  
    public MidiCD midi; 
    public Playset playset;
    public static GamePlay Instance;
    //public static MidiFile midiFile;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    //public int playerData;

    void Start()
    {
        
        Instance = this;
        GetDataFromMidi(MidiCD. midiFile);
        Debug.Log("void Start() 작동중");
       
        int selectedClipIndex = FindObjectOfType<Sound>().selectedClipIndex;
        audioSource.clip = audioClips[selectedClipIndex];
        /*
        if (selectedClipIndex >= 0 && selectedClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[selectedClipIndex];
        }
        */
        Debug.Log("gamep" + selectedClipIndex);
        Debug.Log("Length" + audioClips.Length); 
        Debug.Log("sound 클립  작동중");
       
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
