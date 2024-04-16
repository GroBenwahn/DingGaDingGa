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
        //gamePlay.playerData = playerData;  // GamePlay의 playerData에 데이터 전달
        try
        {
            midiFile = MidiFile.Read(filePath);
            Debug.Log("ReadFromFileAndSendData파일을 불러옴");

        }
            
        catch (IOException e)
        {
            Debug.LogError("파일을 읽을 수 없음: " + e.Message);
        }
    }
}

