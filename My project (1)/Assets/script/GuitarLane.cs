using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarLane : MonoBehaviour
{
    public GuitarCode guitarcode; // 레인이 속한 플레이셋
    public GameObject[] notePrefabs; // 0부터 42까지의 노트에 대한 프리팹 배열
    public List<double> timeStamps = new List<double>(); // 노트 생성 시간의 타임스탬프 리스트

    int spawnIndex = 0;
    GameObject currentPrefab;

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
                double timeStamp = (double)metricTimeSpan.TotalSeconds; // 노트의 생성 시간을 초 단위로 변경합니다.
                timeStamps.Add(timeStamp);
            }
        }
    }

    void Update()
    {
        // 노트 생성 인덱스가 리스트 크기보다 작을 때만 실행
        if (spawnIndex < timeStamps.Count)
        {
            // 현재 재생 중인 시간이 노트 생성 시간보다 크거나 같으면 노트를 생성
            if (GamePlay.GetAudioSourceTime() >= timeStamps[spawnIndex])
            {
                // 새로운 노트가 나오면 현재 프리팹을 off.
                if (currentPrefab != null)
                {
                    currentPrefab.SetActive(false);
                    Debug.Log("currentPrefab" + currentPrefab);
                }

                // 새로운 노트에 프리팹을 on
                currentPrefab = notePrefabs[spawnIndex];
                currentPrefab.SetActive(true);
                Debug.Log("currentPrefab" + currentPrefab);

                spawnIndex++;
                Debug.Log("spawnIndex" + spawnIndex);
            }
        }
    }
}
