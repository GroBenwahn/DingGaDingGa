using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    static int comboScore;
    void Start()
    {
        Instance = this;
        comboScore = 0;
    }
    public static void Hit()
    {
        Instance.hitSFX.Play();
        comboScore += 1;
    }
    public static void Miss()
    {
        Instance.missSFX.Play();
        comboScore = 0;
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }
}