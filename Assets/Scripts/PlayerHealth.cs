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
    public bool invulnerable = false;
    public float invulTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        if (!invulnerable)
        {
            currentHealth -= damage;
            StartCoroutine(JustHurt());
        }   
     }
    public void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver();
        }
    }
    IEnumerator JustHurt()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulTime);
        invulnerable = false;
    }

        void GameOver()
        {
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 1f;
        }

    }
