using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    private PlayerHealth player;
    public float health;
    public GameObject deathEffect;
    public int amount;
    public int damage;
    GameController cont;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        cont.AddScore(amount);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cont = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Player"))
        {
            player.currentHealth -= damage;
            Debug.Log(player.currentHealth);
        }
    }

}

