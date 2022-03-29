using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField]
    public Text enemiesText;
    int numOfEnemies;
    public Text scoreText;

    int scores = 0;

    public GameObject gameOverUI;

    public bool gameOver;

    void Start()
    {
        scoreText.text = "Scores: " + scores.ToString();

        gameOver = false;

    }

    // Start is called before the first frame update
    void Update()
    {
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesText.text = "Enemies Left: " + numOfEnemies.ToString();

        if (numOfEnemies <= 0)
        {
            NextLevel();
        }

        scoreText.text = "Scores: " + scores.ToString();

    }

    public void AddScore(int amount)
    {
        scores += amount;
    }

    private void NextLevel()
   {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}