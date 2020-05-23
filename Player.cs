using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    

    //grabb
    public GameObject player;
    public Rigidbody2D rb;
    public BoxCollider2D coll2D;
    public float speed = 10f;
    Vector2 movement;
    public float health;
    public GameObject DeathParticles;
    public int deathInt;


    //cds
    private float attackCD;
    //private float attackOnCD = 1;
    //private float attackOffCD = 0;
    private float teleportCD;
    private float tpOnCD = 1;
    private float tpOffCD = 0;
    private float moveCD;
    private float moveOnCD = 1;
    private float moveOffCD = 0;

    public bool attackReady;

    [SerializeField] Transform target;
    float TpRange = 80f;
    public Vector2 targetPos;
    public GameObject Explosion;
    [SerializeField] private GameObject targetPosObject;

    //respawn cords
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public GameObject enemyPrefabs;
    public GameObject[] enemies;

    public GameObject SpawnEnemy;
    public SpawnEnemy SpawnEnemyScript;

    public GameObject restartButton;


    void Start()
    {
        SpawnEnemy = GameObject.Find("Spawner");
        SpawnEnemyScript = SpawnEnemy.GetComponent<SpawnEnemy>();
        targetPos = transform.position;
        teleportCD = 0;
        attackReady = true;
        
    }

    void Update()
    {
        deathInt = 0;
        
        if (health <= 0)
        {
            health = 1;
            Instantiate(DeathParticles, transform.position, Quaternion.identity);
            death();
        }
        
        if (teleportCD > 0) //drar ned teleport cd
        {
            teleportCD -= Time.deltaTime;
            teleportCD = Mathf.Clamp(teleportCD,tpOffCD, tpOnCD); //gör så att de inte går under 0
        }
        //if (attackCD > 0) //drar ned attackCD
        //{
        //  attackCD -= Time.deltaTime;
        //    attackCD = Mathf.Clamp(attackCD, attackOffCD, attackOnCD); //gör så att de inte går under 0
        //}
        if (moveCD > 0) //drar ned moveCD
        {
            moveCD -= Time.deltaTime;
            moveCD = Mathf.Clamp(moveCD, moveOffCD, moveOnCD); //gör så att de inte går under 0
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        

        if (attackReady == true && Input.GetMouseButtonDown(0)) //attack
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.position = targetPos;
            targetPosObject = Instantiate(Explosion, targetPos, Quaternion.identity) as GameObject;
            Explosion.transform.position = targetPos;
            attackReady = false;
        }
        
        if (Input.GetMouseButtonDown(1) && (teleportCD == 0)) //teleport
        {
            moveCD = .08f;
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.position = targetPos;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, TpRange * Time.deltaTime);
            teleportCD = 0.5f;
        }

        if (attackReady == false)
        {

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion" || col.gameObject.tag == "Death" || col.gameObject.tag == "Enemy")
        {
            health = 0;
        }

    }

    public void death()
    {
        ScoreScript.ScoreValue = 0;
        deathInt = 1;
        Time.timeScale = 0;
        restartButton.SetActive(true);
    }
    
    void FixedUpdate()//movement
    {
        if (moveCD == 0)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }     
    }
}
