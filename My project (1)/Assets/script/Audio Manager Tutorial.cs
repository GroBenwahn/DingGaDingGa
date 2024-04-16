using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerTutorial : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string GameaudioPref = "GameaudioPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider gameaudioSlider, soundEffectsSlider;
    private float gameaudioFloat, soundEffectsFloat, mixervolFloat ;
    public AudioSource[] gameaudio;
    public AudioSource[] soundEffectsAudio;
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;

    const string MIXER_MUSIC = "BGM";

    void Awake() 
    {
        gameaudioSlider.onValueChanged.AddListener(SetMusicVolume);
        gameaudioSlider.value = PlayerPrefs.GetFloat(MIXER_MUSIC);
        SetMusicVolume(gameaudioSlider.value);

    }

    void SetMusicVolume(float value) 
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(MIXER_MUSIC, value);
    }

    

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
        SetMusicVolume(gameaudioSlider.value);
        for (int a = 0; a < gameaudio.Length; a++)
        {
            gameaudio[a].volume = gameaudioSlider.value;
            Debug.Log(gameaudioSlider.value);
        }
        for (int i = 0; i < soundEffectsAudio.Length; i++) 
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }

}
