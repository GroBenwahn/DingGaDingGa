using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarLane : MonoBehaviour
{
    public GameObject[] notePrefabs; // 0부터 42까지의 노트에 대한 프리팹 배열
    public List<double> timeStamps = new List<double>(); // 노트 생성 시간의 타임스탬프 리스트

    int spawnIndex = 0;
    GameObject currentPrefab;
    //double previousTime = 0.0;

    void Start()
    {
        
    }

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteNumber >= 0 && note.NoteNumber < notePrefabs.Length)
            {
                // 노트에 해당하는 프리팹과 생성 시간을 추가.
                GameObject selectedPrefab = notePrefabs[note.NoteNumber];
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, GuitarMidi.midiFile.GetTempoMap());
                double timeStamp = (double)metricTimeSpan.TotalSeconds + 1.0; // 노트의 생성 시간을 초 단위로 변경합니다.
                timeStamps.Add(timeStamp);
            }
        }
    }

    public void Able() 
    {
        currentPrefab.SetActive(true);

    }

    public void Disable()
    {
        currentPrefab.SetActive(false);
    }

    void Update()
    {
        // 현재 시간을 가져옵니다.
        double currentTime = GamePlay.GetAudioSourceTime();

        // 이전에 생성된 노트의 생성 시간과 현재 시간 사이에 있는 노트를 모두 활성화합니다.
        if (spawnIndex < timeStamps.Count && spawnIndex < notePrefabs.Length && timeStamps[spawnIndex] <= currentTime)
        {
            if (currentPrefab != null)
            {
                //Invoke("Disable", .1f);
                Disable();
            }
            currentPrefab = notePrefabs[spawnIndex];
            //Invoke("Able", 0f);
            Able();
            spawnIndex++;
        }

        // 현재 시간과 이전 시간을 갱신합니다.
        //previousTime = currentTime;
    }
}

