using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;



public class GuitarCode : MonoBehaviour
{

    public GuitarMidi guitarmidi;
    public static GuitarCode Instance;
    public GuitarLane[] lanes;


    void Start()
    {
        Instance = this;

        GetDataFromGuitarCodeMidi(GuitarMidi.midiFile);
        Debug.Log("GuitarCode �� midi �ҷ���");
    }


    public void GetDataFromGuitarCodeMidi(MidiFile midiFile)
    {
        Debug.Log("GetDataFromGuitarCodeMidi �۵���");
        if (midiFile != null)
        {
            var notes = midiFile.GetNotes();
            var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
            notes.CopyTo(array, 0);

            foreach (var lane in Instance.lanes)
            {
                lane.SetTimeStamps(array);
            }
            // Invoke(nameof(StartSong), playset.songDelayInSeconds);
        }
        else
        {
            Debug.LogError("MidiFile is null.");
        }
    }

    
    void Update()
    {
        
    }
}
