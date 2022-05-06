using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject p;
    public Animator anime;
    public Transform[] Portal;
    private float timeBtwSpawns;
    public float StartTimeBtwSpawns;
    public int spawnNum=5;
    public int enemiesLeft;

    void Start()
    {
        timeBtwSpawns = StartTimeBtwSpawns;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0 && spawnNum > 0)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], Portal[0].transform.position, Quaternion.Euler(0, 0, 0));
            timeBtwSpawns = StartTimeBtwSpawns;
            spawnNum--;
                
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
        enemiesLeft = GameObject.FindGameObjectsWithTag("pEnemy").Length;

        if (spawnNum <=0 && enemiesLeft == 0)
        {
            anime.SetTrigger("Intro2End");
        }
    }
}
