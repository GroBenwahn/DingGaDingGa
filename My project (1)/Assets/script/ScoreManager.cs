using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI perfectScoreText, goodScoreText, missScoreText, maxComboText, accuracyText, rankText;
    public RawImage image; // 이미지를 표시할 RawImage 컴포넌트

    int perfectScore;
    int goodScore;
    int missScore;
    int maxCombo;
    int total;  // 전체 노트 값
    float accuracy;
    private Score scoreScript;
    string rank;

    void Awake() 
    {
        // Score 스크립트의 인스턴스를 참조합니다.
        scoreScript = Score.Instance;
        perfectScore = 0;
        goodScore = 0;
        missScore = 0;
        maxCombo = 0;
        total = 0;
        rank = "";

        // GetScores() 메서드를 호출하여 점수 데이터를 가져옵니다.
        (perfectScore, goodScore, missScore, maxCombo, total) = scoreScript.GetScores();

        // 가져온 점수 데이터를 사용합니다.
        Debug.Log("Perfect Score: " + perfectScore);
        Debug.Log("Good Score: " + goodScore);
        Debug.Log("Miss Score: " + missScore);
        Debug.Log("Max Combo: " + maxCombo);
        Debug.Log("Total: " + total);

        accuracy = CalculateAccuracy(perfectScore, goodScore, total);
        Debug.Log("Accuracy: " + accuracy);
        rank = Rank(accuracy);
        Debug.Log("Rank: " + rank);
    }

    private string Rank(float accuracy)     // 랭크 반환
    {
        if (accuracy >= 98.00) return "S";
        else if (accuracy >= 92.00) return "A";
        else if (accuracy >= 83.00) return "B";
        else if (accuracy >= 75.00) return "C";
        else if (accuracy >= 65.00) return "D";
        else if (accuracy >= 55.00) return "E";
        else return "F";
    }

    private float CalculateAccuracy(int perfectScore, int goodScore, int total)    // 정확도 계산
    {   
        if (total == 0) return 0;
        return (float)(perfectScore + goodScore) / total * 100;
    }

    
    void Start()
    {
        string imageName = PlayerPrefs.GetString("ImageName");

        // Resources 폴더 내에서 해당 이미지를 로드
        Texture2D texture = Resources.Load<Texture2D>( imageName);
        if (texture != null)
        {
            // RawImage에 이미지 설정
            image.texture = texture;
        }
        Debug.Log(" image.texture : " + texture);

        perfectScoreText.text = perfectScore.ToString();
        goodScoreText.text = goodScore.ToString();
        missScoreText.text = missScore.ToString();
        maxComboText.text = maxCombo.ToString();
        accuracyText.text = accuracy.ToString("F2");
        rankText.text = rank;
    }

    
    void Update()
    {
        
    }

    
}
