using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimDestroy : MonoBehaviour {

    [SerializeField] private float lifetime;
    public GameObject PlayerWithScripts;
    private Player playerScript;

    // Use this for initialization
    void Start () {
        lifetime = 1;
        PlayerWithScripts = GameObject.Find("Player");
        playerScript = PlayerWithScripts.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }


    }
}
