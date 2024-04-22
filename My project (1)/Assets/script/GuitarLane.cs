using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarLane : MonoBehaviour
{
    public GuitarCode guitarcode; // 레인이 속한 플레이셋
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction; // 노트가 생성될 때 사용되는 음표 제한
    public GameObject notePrefab; // 생성될 노트의 프리팹
    public List<double> timeStamps = new List<double>(); // 노트 생성 시간의 타임스탬프 리스트

    int spawnIndex = 0;

    void Start()
    {
        
    }

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, GuitarMidi.midiFile.GetTempoMap());
                double timeStamp = (double)metricTimeSpan.TotalSeconds; // 노트의 생성 시간을 초 단위로 변경합니다.
                timeStamps.Add(timeStamp);
            }
        }
    }

    void Update()
    {
        // 이 부분에서는 노트 생성 로직을 구현합니다.
        if (spawnIndex < timeStamps.Count)
        {
            if (GamePlay.GetAudioSourceTime() >= timeStamps[spawnIndex])
            {
                // 노트 생성 시간에 도달하면 프리팹을 인스턴스화하여 레인에 생성합니다.
                var note = Instantiate(notePrefab, transform.position, Quaternion.identity, transform);
                spawnIndex++;
                Debug.Log("spawnIndex" + spawnIndex);
            }
        }
    }
}
