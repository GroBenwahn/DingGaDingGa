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
            Debug.Log("GuitarCodemidi������ �ҷ���");
        }

        catch (IOException e)
        {
            Debug.LogError("������ ���� �� ����: " + e.Message);
        }
    }

    public MidiFile GetGuitarMidiFile()
    {
        return midiFile;
    }
}
