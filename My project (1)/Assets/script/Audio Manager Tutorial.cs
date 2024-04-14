using UnityEngine.UI;
using UnityEngine;

public class AudioManagerTutorial : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string GameaudioPref = "GameaudioPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider gameaudioSlider, soundEffectsSlider;
    private float gameaudioFloat, soundEffectsFloat;
    public AudioSource[] gameaudio;
    public AudioSource[] soundEffectsAudio;


    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0) 
        {
            gameaudioFloat = .25f;
            soundEffectsFloat = .75f;
            gameaudioSlider.value = gameaudioFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(GameaudioPref, gameaudioFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            gameaudioFloat = PlayerPrefs.GetFloat(GameaudioPref);
            gameaudioSlider.value = gameaudioFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void saveSoundSettings() 
    {
        PlayerPrefs.SetFloat(GameaudioPref, gameaudioSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
        
    }
    void OnApplicationFocus(bool inFocus) 
    {
        if (!inFocus)
        {
            saveSoundSettings();
        }
    }

    public void UpdateSound() 
    {
        for (int a = 0; a < gameaudio.Length; a++)
        {
            gameaudio[a].volume = gameaudioSlider.value;
        }
        for (int i = 0; i < soundEffectsAudio.Length; i++) 
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }

}
