using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Melanchall.DryWetMidi.Core;


public class GuitarMidi : MonoBehaviour
{
    public GuitarCode guitarcode;
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


    public void ReadFromGuitarCodeData(string fileLocation)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath + "/" + fileLocation);

        try
        {
            midiFile = MidiFile.Read(filePath);
            Debug.Log("GuitarCodemidi파일을 불러옴");
        }

        catch (IOException e)
        {
            Debug.LogError("파일을 읽을 수 없음: " + e.Message);
        }
    }

    public MidiFile GetGuitarMidiFile()
    {
        return midiFile;
    }
}
