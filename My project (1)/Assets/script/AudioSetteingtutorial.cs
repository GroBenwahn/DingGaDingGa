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
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;

    const string MIXER_MUSIC = "BGM";

    void Awake()
    {
        ContinueSettings();
        musicSlider.value = PlayerPrefs.GetFloat(MIXER_MUSIC);

    }

    private void ContinueSettings() 
    {
        gameaudioFloat = PlayerPrefs.GetFloat(GameaudioPref);
        gameaudioFloat = PlayerPrefs.GetFloat(MIXER_MUSIC);
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
