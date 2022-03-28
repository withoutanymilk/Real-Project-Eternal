using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text enemiesText;
    int numOfEnemies;

    // Start is called before the first frame update
    void Update()
    {
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesText.text = "Enemies Left: " + numOfEnemies.ToString();

        if (numOfEnemies <= 0)
        {
            NextLevel();
        }
    }

    private void NextLevel()
   {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

}
