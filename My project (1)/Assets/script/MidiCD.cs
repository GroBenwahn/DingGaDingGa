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
            Debug.Log("midi������ �ҷ���");
        }
            
        catch (IOException e)
        {
            Debug.LogError("������ ���� �� ����: " + e.Message);
        }
    }

    public MidiFile GetMidiFile()
    {
        return midiFile;
    }
}

