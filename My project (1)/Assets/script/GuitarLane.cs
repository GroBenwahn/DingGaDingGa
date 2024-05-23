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
    GameObject nextNotePrefab;
    GameObject[] selectedPrefab;

    void Start()
    {
        // PlayerPrefs에서 설정한 속도 읽기
        float selectedSpeed = PlayerPrefs.GetFloat("SelectedSpeedPref");
        Time.timeScale = selectedSpeed;
        
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        selectedPrefab = new GameObject[array.Length]; // 선택된 노트 프리팹들을 저장할 배열 초기화
        int index = 0; // 배열 인덱스를 추적하기 위한 변수

        foreach (var note in array)
        {   
            if (note.NoteNumber >= 0 && note.NoteNumber < notePrefabs.Length)
            {
                // 노트에 해당하는 프리팹과 생성 시간을 추가.
                selectedPrefab[index] = notePrefabs[note.NoteNumber];
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, GuitarMidi.midiFile.GetTempoMap());
                double timeStamp = (double)metricTimeSpan.TotalSeconds; // 노트의 생성 시간을 초 단위로 변경합니다.
                timeStamps.Add(timeStamp);
                index++;
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
                }

                // 새로운 노트에 프리팹을 on
                currentPrefab = selectedPrefab[spawnIndex];
                currentPrefab.transform.position = new Vector3(835f, 800f, 0f);
                currentPrefab.transform.localScale = new Vector3(580f, 380f, 0f);
                currentPrefab.SetActive(true);
                Debug.Log("현재Prefab : " + currentPrefab);


                if (spawnIndex < timeStamps.Count - 1)
                {
                    nextNotePrefab = selectedPrefab[spawnIndex + 1];
                    nextNotePrefab.transform.position = new Vector3(1550f, 767f, 0f);
                    nextNotePrefab.transform.localScale = new Vector3(490f, 320f, 0f);
                    nextNotePrefab.SetActive(true);
                    Debug.Log("다음Prefab : " + nextNotePrefab);
                }

                if (spawnIndex > 0)
                {
                    nextNotePrefab = selectedPrefab[spawnIndex -1];
                    nextNotePrefab.SetActive(false);
                }

                spawnIndex++;
            }
        }
    }
}

