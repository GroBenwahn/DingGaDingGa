using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using UnityEngine.SceneManagement;


public class GamePlay : MonoBehaviour
{
    public Sound soundScript;
    public MidiCD midi; 
    public Playset playset;
    public Start_bt start_bt;
    public static GamePlay Instance;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    //private bool gameEnded; // 게임 종료 여부를 나타내는 변수


    void Start()
    {
        Instance = this;
       // gameEnded = false;
        GetDataFromMidi(MidiCD. midiFile);
        Debug.Log("GamePlay 에 midi 불러옴");

        int selectedClipIndex = FindObjectOfType<Sound>().selectedClipIndex;
        audioSource.clip = audioClips[selectedClipIndex];
        Debug.Log("ClipIndex = " + selectedClipIndex);
        Debug.Log("사운드 클립  작동중");

        float selectedSpeed = FindObjectOfType<Start_bt>().selectedSpeed;
        audioSource.pitch = selectedSpeed;
        Debug.Log("sound speed  = " + selectedSpeed);
        Debug.Log("사운드 스피드  작동중");
    }


    public void GetDataFromMidi(MidiFile midiFile)
    {
        Debug.Log("GetDataFromMidi 작동중");
        if (midiFile != null)
        {
            var notes = midiFile.GetNotes();
            var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
            notes.CopyTo(array, 0);

            foreach (var lane in playset.lanes)
            {
                lane.SetTimeStamps(array);
            }

            Invoke(nameof(StartSong), playset.songDelayInSeconds);
        }
        else
        {
            Debug.LogError("MidiFile is null.");
        }
    }

   /* // 게임 종료 시 호출되는 함수
    public void EndGame()
    {
        gameEnded = true;
        audioSource.Stop(); // 오디오 정지
        Debug.LogError("EndGame()");
        // 여기에 추가적인 종료 처리 작업을 추가할 수 있습니다.
    }*/

    public void StartSong()
    {
        audioSource.Play();
    }


    public static double GetAudioSourceTime()
    {
            return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    // Invoke() 메소드 호출을 위한 메소드
    /*private void SwitchToNextScene()
    {
        // 여기서 다음 씬으로 전환
        SceneManager.LoadScene("score_scene");
    }
    */
    /*
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            // 오디오가 종료되었다면 게임을 종료
            EndGame();
            // Invoke("SwitchToNextScene", 1.0f);
            Debug.LogError("EndGame() -> score_scene");
            SceneManager.LoadScene("score_scene"); // "Score" 씬으로 전환
        }
    }
    */
}
