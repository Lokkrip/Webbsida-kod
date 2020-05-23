using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pointsToAdd;
    public float speed;
    public Transform target;
    public BoxCollider2D Collider2D;

    public float health;
    public GameObject DeathParticles;

    public float speedOverTime;

    public GameObject PlayerWithScripts;
    private Player playerScript;

    public GameObject DifficultyWithScript;
    private Difficulty difficultyScript;
    void Start()
    {
        PlayerWithScripts = GameObject.FindGameObjectWithTag("Player");
        playerScript = PlayerWithScripts.GetComponent<Player>();

        DifficultyWithScript = GameObject.Find("DifficultySave");
        difficultyScript = DifficultyWithScript.GetComponent<Difficulty>();
    }

    void Update()
    {

        speed += Time.deltaTime * speedOverTime;
        target = GameObject.FindWithTag("Player").transform;

        if (health <= 0)
        {
            health = 1;
            Instantiate(DeathParticles, transform.position, Quaternion.identity);
            death();
            
        }

        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            health = 0;
        }

    }

    public void death()
    {
        playerScript.attackReady = true;
        ScoreScript.ScoreValue += Difficulty.DiffPointsToAdd;        
        Destroy(gameObject);
    }

}
