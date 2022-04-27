using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    public LifeCount lifesRemaining;

    public Button myButtonResume;
    public Button myButtonNewGame;
    public Button pause;
    public Button play;
    public Button play2;
    public Button stop;

   

    void Update()
    {
        if (lifesRemaining.lifesRemaining == 0)
        {
            myButtonResume.gameObject.SetActive(false);
            myButtonNewGame.gameObject.SetActive(true);
        }


        //escape, Q - zobrazit pause menu
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            if (GameIsPaused)
            {
                Resume();

            }
            {
                Pause();
            }
        }



    }

    //spustit, zrušit pauznutí
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pause.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
    }

    //pause, pozastavit hru
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
    }

    //naèíst hlavní menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    //zahájit novou hru
    public void NewGame()
    {
        SceneManager.LoadScene("game");
        Time.timeScale = 1f;
    }

}
