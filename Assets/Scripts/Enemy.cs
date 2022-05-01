using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    private PlayerHealth player;
   	public float maxHealth;
	public float health;
    public GameObject deathEffect;
    public int amount;
    public int damage;
    GameController cont;

  	public Image healthImage;
	
	public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            FindObjectOfType<AudioManager>().Play("Death");
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
		health = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cont = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
		
		//transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
		
		healthImage.fillAmount = health / maxHealth;
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

