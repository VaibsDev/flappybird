using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // public GameObject openPageUI;
    bool gameHasEnded;
    public GameObject gameOverScreen;
    public GameObject pause;
    public AudioSource buttonSound;
    private bool gameEnded = false;
    public bool GameEnded
    {
        get { return gameEnded; }
        set { value = gameEnded;}
    }

    void Awake()
    {
        instance = this;
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Time.timeScale = 0f; //HEARTSystem
            Debug.Log("End Game");
            gameOverScreen.SetActive(true);
            pause.SetActive(false);
            gameEnded = true;
        }
        // SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Game");
    }

    /* public void GameStart()
     {
         openPageUI.SetActive(false);
     } */
}
