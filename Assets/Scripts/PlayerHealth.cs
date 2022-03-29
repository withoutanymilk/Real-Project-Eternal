using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("health")]
    [SerializeField] private float startingHealth = 100f;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {

            currentHealth -= damage;
    
     }
    public void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver();
        }
    }

        void GameOver()
        {
            FindObjectOfType<GameController>().gameOver = true;
            FindObjectOfType<GameController>().gameOverUI.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 0f;
        }

    }
