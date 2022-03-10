using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static int Score;
    public Text ScoreText;

    public static int HighScore;
    public Text HighScoreText;
    private void Start()
    {
        Score = 0;
    }
    private void Update()
    {
        if(Score > HighScore)
        {
            HighScore = Score;
        }
        ScoreText.text = "Score:" + Score.ToString();
        HighScoreText.text = "HightScore:" + HighScore.ToString();
    }
    
}
