using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    [SerializeField] public static float lifetime;
    public static int DiffPointsToAdd;
    public GameObject DifficultyObject;
    // Start is called before the first frame update
    void Start()
    {
        DiffPointsToAdd = 1;
        lifetime = 3;
        DontDestroyOnLoad(DifficultyObject.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
