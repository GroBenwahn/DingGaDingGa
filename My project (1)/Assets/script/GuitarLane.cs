using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarLane : MonoBehaviour
{
    public GuitarCode guitarcode; // ������ ���� �÷��̼�
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction; // ��Ʈ�� ������ �� ���Ǵ� ��ǥ ����
    public GameObject notePrefab; // ������ ��Ʈ�� ������
    public List<double> timeStamps = new List<double>(); // ��Ʈ ���� �ð��� Ÿ�ӽ����� ����Ʈ

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
                double timeStamp = (double)metricTimeSpan.TotalSeconds; // ��Ʈ�� ���� �ð��� �� ������ �����մϴ�.
                timeStamps.Add(timeStamp);
            }
        }
    }

    void Update()
    {
        // �� �κп����� ��Ʈ ���� ������ �����մϴ�.
        if (spawnIndex < timeStamps.Count)
        {
            if (GamePlay.GetAudioSourceTime() >= timeStamps[spawnIndex])
            {
                // ��Ʈ ���� �ð��� �����ϸ� �������� �ν��Ͻ�ȭ�Ͽ� ���ο� �����մϴ�.
                var note = Instantiate(notePrefab, transform.position, Quaternion.identity, transform);
                spawnIndex++;
                Debug.Log("spawnIndex" + spawnIndex);
            }
        }
    }
}
