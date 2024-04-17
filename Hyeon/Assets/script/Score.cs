using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText, hitText;
    static string hit_t;
    private static int comboScore;
    private static int perfectScore;
    private static int goodScore;
    private static int missScore;
    private static int maxCombo;

    void Start()
    {
        Instance = this;
        comboScore = 0;
        perfectScore = 0;
        goodScore = 0;
        missScore = 0;
        maxCombo = 0;
    }

    // Max Combo 
    public static void UpdateMaxCombo(int currentCombo)
    {
        if (currentCombo > maxCombo)
        {
            maxCombo = currentCombo;
        }
    }

    public static void Hit()
    {
        // Hit Perfect
        Instance.hitSFX.Play();
        comboScore += 1;
        perfectScore++;
        hit_t = "Perfect";
        UpdateMaxCombo(comboScore);
    }

    public static void HitGood()
    {
        // Hit Good
        Instance.hitSFX.Play();
        comboScore += 1;
        hit_t = "Good";
        goodScore++;
        UpdateMaxCombo(comboScore);
    }

    public static void Miss()
    {
        // Miss
        Instance.missSFX.Play();
        comboScore = 0;
        missScore++;
        hit_t = "miss";
    }
    

    private void Update()
    {
        scoreText.text = comboScore.ToString();
        hitText.text = hit_t;
    }

    public (int, int, int, int) GetScores() 
    {
        return (perfectScore, goodScore, missScore, maxCombo);
    }
}