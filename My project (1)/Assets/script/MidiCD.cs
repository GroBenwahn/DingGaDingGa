using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using System;

public class MidiCD : MonoBehaviour
{
    public GamePlay gamePlay ;
    public static MidiFile midiFile;

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


    public void ReadFromFileAndSendData(string fileLocation)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath + "/" + fileLocation);
        
        try
        {
            midiFile = MidiFile.Read(filePath);
            Debug.Log("midi파일을 불러옴");
        }
            
        catch (IOException e)
        {
            Debug.LogError("파일을 읽을 수 없음: " + e.Message);
        }
    }

    public MidiFile GetMidiFile()
    {
        return midiFile;
    }
}

