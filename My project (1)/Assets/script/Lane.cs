using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lane : MonoBehaviour
{
    public Playset Playset;
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();

    int spawnIndex = 0;
    int inputIndex = 0;

    
    void Start()
    {

    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, MidiCD.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    void Update()
    {

        if (spawnIndex < timeStamps.Count)
        {
            if (GamePlay.GetAudioSourceTime() >= timeStamps[spawnIndex] - GamePlay.Instance.playset.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = GamePlay.Instance.playset.marginOfError;
            double goodLine = GamePlay.Instance.playset.goodLine;
            double audioTime = GamePlay.GetAudioSourceTime() - (GamePlay.Instance.playset.inputDelayInMilliseconds / 1000.0) + 0.1;

            if (Input.GetKeyDown(input))
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    // Perfect
                    Hit();
                    print($"Perfect on {inputIndex} note");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                    /*HitGood();
                    print($"Good on {inputIndex} note");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;*/
                }
                
                else if (Math.Abs(audioTime - timeStamp) < goodLine)
                {
                    /*Hit();
                    print($"Perfect on {inputIndex} note");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;*/
                    // Good
                    HitGood();
                    print($"Good on {inputIndex} note");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                
                else
                {
                    print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                }
            }
            if (timeStamp + goodLine <= audioTime)
            {
                Miss();
                print($"Missed {inputIndex} note");
                inputIndex++;
            }
        }

    }
    private void Hit()
    {
        Score.Hit();
    }
    private void HitGood()
    {
        Score.HitGood();
    }
    private void Miss()
    {
        Score.Miss();
    }
}