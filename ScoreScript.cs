using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int ScoreValue;
    public Text Score;
    public Text HighScore;

    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + ScoreValue.ToString();
        HighScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
        if (ScoreValue > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", ScoreValue);
            HighScore.text = "Highscore: " + ScoreValue.ToString();
        }
    }
}
