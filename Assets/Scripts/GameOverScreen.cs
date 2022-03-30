using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   // public Text pointsText;

   /* public void Setup(int Scores)
    {
        gameObject.SetActive(true);
        pointsText.text = Scores.ToString() + " Points";
    }
   */

    public void RestartButton()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Level1");
    }
    public void ExitButton()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("MainMenu");
    }
}
