using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    [SerializeField] public static float Explosionlifetime;

    public GameObject DifficultyWithScript;
    private Difficulty difficultyScript;


    // Use this for initialization
    void Start () {
        DifficultyWithScript = GameObject.Find("DifficultySave");
        difficultyScript = DifficultyWithScript.GetComponent<Difficulty>();
        Explosionlifetime = Difficulty.lifetime;
    }
	
	// Update is called once per frame
	void Update () {
        Explosionlifetime -= Time.deltaTime;
        if(Explosionlifetime <= 0)
        {
            Destroy(gameObject);
        }

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }




}
