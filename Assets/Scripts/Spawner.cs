using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
    public float StartTimeBtwSpawns;

    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length - 1);
            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnSpots[randPos].transform.position, Quaternion.Euler(0, 0, 0));
            timeBtwSpawns = StartTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}