using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 1f;
        }

    }
