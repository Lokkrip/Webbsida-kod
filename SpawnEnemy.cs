using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float timer;
    public float megaTimer;
    public float xMin = -5;
    public float xMax = 5;
    public float yMin = -5;
    public float yMax = 5;
    public GameObject enemy;

    public bool fas1;
    public bool fas2;
    public bool fas3;

    // Start is called before the first frame update
    void Start()
    {
        fas1 = true;
    }

    // Update is called once per frame
    void Update()
    {

        megaTimer += 1 * Time.deltaTime;
        if (megaTimer >= 0 && megaTimer < 15)
        {
            fas1 = true;
            fas2 = false;
            fas3 = false;

            FasScriptText.FasNummer = 1;
        }
        if (megaTimer > 15)
        {
            fas1 = false;
            fas2 = true;
            fas3 = false;

            FasScriptText.FasNummer = 2;
        }
        if (megaTimer > 30)
        {
            fas1 = false;
            fas2 = false;
            fas3 = true;
            FasScriptText.FasNummer = 3;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if ((timer <= 0) && fas1 == true)
        {
            timer = 4;
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(enemy, pos, transform.rotation);
        }
        if ((timer <= 0) && fas2 == true)
        {
            timer = 3;
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(enemy, pos, transform.rotation);
        }
        if ((timer <= 0) && fas3 == true)
        {
            timer = 2;
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(enemy, pos, transform.rotation);
        }
    }
}
