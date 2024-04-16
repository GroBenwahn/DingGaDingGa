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
    //public string fileLocation;

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

    //public int playerData; 

    public void ReadFromFileAndSendData(string fileLocation)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath + "/" + fileLocation);
        //gamePlay.playerData = playerData;  // GamePlay�� playerData�� ������ ����
        try
        {
            midiFile = MidiFile.Read(filePath);
            Debug.Log("ReadFromFileAndSendData������ �ҷ���");

        }
            
        catch (IOException e)
        {
            Debug.LogError("������ ���� �� ����: " + e.Message);
        }
    }
}

