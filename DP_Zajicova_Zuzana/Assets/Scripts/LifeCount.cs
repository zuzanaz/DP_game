using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCount : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TextMeshProUGUI display2;
    public static bool GameIsOver = false;
    public GameObject GameOverUI;
    public GameObject[] mraky;


    public Button pause;
    public Button play;
    public Button play2;
    public Button stop;

    public Score score;

    int subjectIndex;
    int subjectIndexVl;

    public Image[] lifes;
    public int lifesRemaining;
    public static LifeCount lifeCount;
    //5 lifes - 5 images (1, 2, 3, 4, 5)
    //4 lifes - 4 images (1, 2, 3, 4, [5])
    //3 lifes - 3 images (1, 2, 3, [4, 5])
    //2 lifes - 2 images (1, 2, [3, 4, 5])
    //1 lifes - 1 images (1, [2, 3, 4, 5])
    //0 lifes - 0 images ([1, 2, 3, 4, 5]) LOSE
    public void Start()
    {
        lifeCount = this;
        subjectIndex = PlayerPrefs.GetInt("SelectedSubject", 0);
        subjectIndexVl = PlayerPrefs.GetInt("SelectedSubjectVl", 0);
    }


    private void Update()
    {
        //mìnit poèasí (barevnost nebe a mrakù) podle poètu životù
        foreach (GameObject mrak in mraky)
        {
            if (lifesRemaining == 4)
            {

                Camera.main.backgroundColor = new Color(0.698f, 0.890f, 0.890f);//(178,227,227);
                mrak.GetComponent<Renderer>().material.color = new Color(0.878f, 0.839f, 0.839f);//(224, 214, 214);
            }
            if (lifesRemaining == 3)
            {

                mrak.GetComponent<Renderer>().material.color = new Color(0.756f, 0.733f, 0.733f);//(195, 187, 187);
                Camera.main.backgroundColor = new Color(0.588f, 0.761f, 0.776f);//(150, 194, 198);
            }
            if (mrak.name == "mrak" && lifesRemaining == 2)
            {
                mrak.GetComponent<Renderer>().material.color = new Color(0.616f, 0.596f, 0.596f);//(157, 152, 152);
                Camera.main.backgroundColor = new Color(0.537f, 0.671f, 0.682f);//(137, 171, 174);
            }
            if (mrak.name == "mrak" && lifesRemaining == 1)
            {
                mrak.GetComponent<Renderer>().material.color = new Color(0.502f, 0.490f, 0.490f);//(128, 125, 125);
                Camera.main.backgroundColor = new Color(0.502f, 0.635f, 0.643f);//(128, 162, 164);
            }
            if (mrak.name == "mrak" && lifesRemaining == 0)
            {
                mrak.GetComponent<Renderer>().material.color = new Color(0.353f, 0.341f, 0.341f);//(90, 87, 87);
                Camera.main.backgroundColor = new Color(0.424f, 0.541f, 0.549f);//(108, 138, 140);
            }
        }


    }


    //lose life
    public void LoseLife()
    {
        //If no lives remaining do nothing
        if (lifesRemaining == 0)
            return;
        //Decrease the value of lifesRemaining
        lifesRemaining--;
        //Hide on of the life images
        lifes[lifesRemaining].enabled = false;

        //If we run out of lifes we lose the game
        if (lifesRemaining == 0)
        {
            Debug.Log("You lost!");

            GameOver();

        }

    }

    //gameover
    void GameOver()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;


        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
        FindObjectOfType<AudioManager>().Play("EndGame");

        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        stop.gameObject.SetActive(true);
        play2.gameObject.SetActive(true);

        //hlášky èeština
        if (sceneName == "game" && subjectIndex == 0 && score.score < 100 && subjectIndexVl != 1)
        {
            display.text = "Zopakuj si pravidla èeského pravopisu! ";
        }

        if (subjectIndex == 0 && score.score >= 100 && score.score < 200 && subjectIndexVl != 1)
        {
            display.text = "Malý neználek.";
        }
        if (subjectIndex == 0 && score.score >= 200 && score.score < 300 && subjectIndexVl != 1)
        {
            display.text = "Popleta.";
        }
        if (sceneName == "game" && subjectIndex == 0 && score.score >= 300 && score.score < 400 && subjectIndexVl != 1)
        {
            display.text = "Prùmìrný èeštináø.";
        }
        if (sceneName == "game" && subjectIndex == 0 && score.score >= 400 && score.score < 600 && subjectIndexVl != 1)
        {
            display.text = "Nadìjný èeštináø.";
        }
        if (sceneName == "game" && subjectIndex == 0 && score.score >= 600 && subjectIndexVl != 1)
        {
            display.text = "Gramatický mág.";
        }

        //matika
        if (sceneName == "game" && subjectIndex == 1 && score.score < 100 && subjectIndexVl != 1)
        {
            display.text = "Zkus to znovu.";
        }
        if (sceneName == "game" && subjectIndex == 1 && score.score >= 100 && score.score < 200 && subjectIndexVl != 1)
        {
            display.text = "Prùmìrný matikáø.";
        }
        if (sceneName == "game" && subjectIndex == 1 && score.score >= 200 && score.score < 500 && subjectIndexVl != 1)
        {
            display.text = "Nadìjný matikáø.";
        }
        if (sceneName == "game" && subjectIndex == 1 && score.score >= 500 && subjectIndexVl != 1)
        {
            display.text = "Matematický mág.";
        }

        //hudebka
        if (sceneName == "game" && (subjectIndex == 2 || subjectIndexVl == 1) && score.score < 100)
        {
            display.text = "Zkus to znovu.";
        }
        if (sceneName == "game" && (subjectIndex == 2 || subjectIndexVl == 1) && score.score >= 100 && score.score < 200)
        {
            display.text = "Dobøe.";
        }
        if (sceneName == "game" && ( subjectIndex == 2 || subjectIndexVl == 1) && score.score >= 200 && score.score < 300)
        {
            display.text = "Výbornì";
        }
        if (sceneName == "game" && (subjectIndex == 2 || subjectIndexVl == 1) && score.score >= 300)
        {
            display.text = "Jsi génius.";
        }


        display2.text = "Dosažený poèet bodù: " + score.score;
    }

}
