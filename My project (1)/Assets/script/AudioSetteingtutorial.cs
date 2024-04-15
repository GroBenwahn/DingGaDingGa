using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSetteingtutorial : MonoBehaviour
{

    private static readonly string GameaudioPref = "GameaudioPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float gameaudioFloat, soundEffectsFloat;
    public AudioSource[] gameaudio;
    public AudioSource[] soundEffectsAudio;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings() 
    {
        gameaudioFloat = PlayerPrefs.GetFloat(GameaudioPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        for (int a = 0; a < gameaudio.Length; a++)
        {
            gameaudio[a].volume = gameaudioFloat;
        }
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
    
}
