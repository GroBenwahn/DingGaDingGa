using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarLane : MonoBehaviour
{
    public GameObject[] notePrefabs; // 0���� 42������ ��Ʈ�� ���� ������ �迭
    public List<double> timeStamps = new List<double>(); // ��Ʈ ���� �ð��� Ÿ�ӽ����� ����Ʈ

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
                // ��Ʈ�� �ش��ϴ� �����հ� ���� �ð��� �߰�.
                GameObject selectedPrefab = notePrefabs[note.NoteNumber];
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, GuitarMidi.midiFile.GetTempoMap());
                double timeStamp = (double)metricTimeSpan.TotalSeconds + 1.0; // ��Ʈ�� ���� �ð��� �� ������ �����մϴ�.
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
        // ���� �ð��� �����ɴϴ�.
        double currentTime = GamePlay.GetAudioSourceTime();

        // ������ ������ ��Ʈ�� ���� �ð��� ���� �ð� ���̿� �ִ� ��Ʈ�� ��� Ȱ��ȭ�մϴ�.
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

        // ���� �ð��� ���� �ð��� �����մϴ�.
        //previousTime = currentTime;
    }
}

