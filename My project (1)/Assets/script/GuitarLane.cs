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
    GameObject nextNotePrefab;

    void Start()
    {
        // PlayerPrefs���� ������ �ӵ� �б�
        float selectedSpeed = PlayerPrefs.GetFloat("SelectedSpeedPref");
        Time.timeScale = selectedSpeed;
        
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
                    Debug.Log("���� ��Ʈ ���� ---- " + currentPrefab);
                }

                // ���ο� ��Ʈ�� �������� on
                currentPrefab = notePrefabs[spawnIndex];
                currentPrefab.transform.position = new Vector3(950f, 800f, 0f);
                currentPrefab.transform.localScale = new Vector3(490f, 380f, 0f);
                currentPrefab.SetActive(true);
                Debug.Log("���� ��Ʈ ���� ---- " + currentPrefab);



                if (spawnIndex < timeStamps.Count - 1)
                {
                    nextNotePrefab = notePrefabs[spawnIndex + 1];
                    nextNotePrefab.transform.position = new Vector3(1550f, 800f, 0f);
                    nextNotePrefab.transform.localScale = new Vector3(400f, 280f, 0f);
                    nextNotePrefab.SetActive(true);
                    Debug.Log("���� ��Ʈ Prefab ���� ---- " + nextNotePrefab);
                }

                if (spawnIndex > 0)
                {
                    nextNotePrefab = notePrefabs[spawnIndex -1];
                    nextNotePrefab.SetActive(false);
                    Debug.Log("���� ��Ʈ Prefab ���� ---- " + nextNotePrefab);
                }

                spawnIndex++;
                Debug.Log("spawnIndex" + spawnIndex);
            }
        }
    }
}

