using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI perfectScoreText, goodScoreText, missScoreText, comboScoreText;


    int perfectScore;
    int goodScore;
    int missScore;
    int comboScore;
    private Score scoreScript;

    void Awake() 
    {
        // Score 스크립트의 인스턴스를 참조합니다.
        scoreScript = Score.Instance;

        // GetScores() 메서드를 호출하여 점수 데이터를 가져옵니다.
        (perfectScore, goodScore, missScore, comboScore) = scoreScript.GetScores();

        // 가져온 점수 데이터를 사용합니다.
        Debug.Log("Perfect Score: " + perfectScore);
        Debug.Log("Good Score: " + goodScore);
        Debug.Log("Miss Score: " + missScore);
        Debug.Log("Combo Score: " + comboScore);

        // 이후에 필요한 작업을 수행합니다.
    }


    // Start is called before the first frame update
    void Start()
    {
        perfectScoreText.text = perfectScore.ToString();
        goodScoreText.text = goodScore.ToString();
        missScoreText.text = missScore.ToString();
        comboScoreText.text = comboScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
