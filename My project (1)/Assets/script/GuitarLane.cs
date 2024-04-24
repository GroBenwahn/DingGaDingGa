using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarLane : MonoBehaviour
{
    public GuitarCode guitarcode; // ������ ���� �÷��̼�
    public GameObject[] notePrefabs; // 0���� 42������ ��Ʈ�� ���� ������ �迭
    public List<double> timeStamps = new List<double>(); // ��Ʈ ���� �ð��� Ÿ�ӽ����� ����Ʈ

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
                // ��Ʈ�� �ش��ϴ� �����հ� ���� �ð��� �߰�.
                GameObject selectedPrefab = notePrefabs[note.NoteNumber];
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, GuitarMidi.midiFile.GetTempoMap());
                double timeStamp = (double)metricTimeSpan.TotalSeconds; // ��Ʈ�� ���� �ð��� �� ������ �����մϴ�.
                timeStamps.Add(timeStamp);
            }
        }
    }

    void Update()
    {
        // ��Ʈ ���� �ε����� ����Ʈ ũ�⺸�� ���� ���� ����
        if (spawnIndex < timeStamps.Count)
        {
            // ���� ��� ���� �ð��� ��Ʈ ���� �ð����� ũ�ų� ������ ��Ʈ�� ����
            if (GamePlay.GetAudioSourceTime() >= timeStamps[spawnIndex])
            {
                // ���ο� ��Ʈ�� ������ ���� �������� off.
                if (currentPrefab != null)
                {
                    currentPrefab.SetActive(false);
                    Debug.Log("currentPrefab" + currentPrefab);
                }

                // ���ο� ��Ʈ�� �������� on
                currentPrefab = notePrefabs[spawnIndex];
                currentPrefab.SetActive(true);
                Debug.Log("currentPrefab" + currentPrefab);

                spawnIndex++;
                Debug.Log("spawnIndex" + spawnIndex);
            }
        }
    }
}
