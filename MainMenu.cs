using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour 
{
    public static float lifetime;


    public GameObject DifficultyWithScript;
    private Difficulty difficultyScript;

    void Start()
    {
        DifficultyWithScript = GameObject.Find("DifficultySave");
        difficultyScript = DifficultyWithScript.GetComponent<Difficulty>();

    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("Base");
    }
    public void DifficultyEasy()
    {
        Difficulty.DiffPointsToAdd = 1;
        Difficulty.lifetime = 3;
    }
    public void DifficultyHard()
    {
        Difficulty.DiffPointsToAdd = 2;
        Difficulty.lifetime = 0.1f;
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ClearScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
