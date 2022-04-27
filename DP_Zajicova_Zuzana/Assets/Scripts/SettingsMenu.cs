using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject[] characters;
    public int selectedCharacter;

    public GameObject[] exercises;
    public GameObject[] subjects;
    public GameObject[] subjectsVlastni;
    public GameObject[] math_exercise;
    private int exerciseIndex;
    private int subjectIndex;
    private int mathIndex;
    private int subjectIndexVl;
    

    public int soundIndex;
    public GameObject[] sounds;

    public GameObject math_selection;
    public GameObject czech_selection;
    public GameObject music_selection;
    public GameObject math;
    public GameObject czech;
    public GameObject math2;
    public GameObject czech2;
    public GameObject music;
    public GameObject music2;
    public GameObject turnon;
    public GameObject turnoff;

    public GameObject optionsMenu;
    public GameObject vlastniMenu;

    public static SettingsMenu menu;



    private void Start()
    {
        menu = this;
        
    }
    void Awake()
    {
        soundIndex = PlayerPrefs.GetInt("Sound", 0);
        subjectIndex = PlayerPrefs.GetInt("SelectedSubject", 0);
        exerciseIndex = PlayerPrefs.GetInt("SelectedExercise", 9);
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        mathIndex = PlayerPrefs.GetInt("SelectedMath", 0);
        subjectIndexVl = PlayerPrefs.GetInt("SelectedSubjectVl", 0);

        foreach (GameObject player in characters)
            player.SetActive(false);

        characters[selectedCharacter].SetActive(true);


        //úvodní nastavení dle preferencí hráèe a posledního nastavení
        if (soundIndex == 0)
        {
            turnon.SetActive(true);
            turnoff.SetActive(false);
        }
        if (soundIndex == 1)
        {
            turnon.SetActive(false);
            turnoff.SetActive(true);
        }




        if (subjectIndex == 0 && subjectIndexVl==0)
        {
            czech_selection.SetActive(true);
            math_selection.SetActive(false);
            music_selection.SetActive(false);
            czech2.SetActive(true);
            math.SetActive(true);
            czech.SetActive(false);
            math2.SetActive(false);
            music.SetActive(true);
            music2.SetActive(false);
            PlayerPrefs.SetInt("SelectedExercise", 9);
            
        }

         if (subjectIndex == 1 && subjectIndexVl == 0)
        {
            czech_selection.SetActive(false);
            math_selection.SetActive(true);
            music_selection.SetActive(false);
            czech2.SetActive(false);
            math.SetActive(false);
            czech.SetActive(true);
            math2.SetActive(true);
            music.SetActive(true);
            music2.SetActive(false);
            PlayerPrefs.SetInt("SelectedExercise", 13);

        }

        if (subjectIndex == 2 && subjectIndexVl == 0)
        {
            music_selection.SetActive(true);
            czech_selection.SetActive(false);
            math_selection.SetActive(false);
            czech2.SetActive(false);
            math.SetActive(true);
            czech.SetActive(true);
            math2.SetActive(false);
            music.SetActive(false);
            music2.SetActive(true);
            PlayerPrefs.SetInt("SelectedExercise", 16);

        }

        if (subjectIndexVl == 1)
        {
          vlastniMenu.SetActive(true);
          optionsMenu.SetActive(false);

        }



    }


    private void Update()
    {
        

    }

    //character selection
    public void ChangeNext()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == characters.Length)
            selectedCharacter = 0;

        characters[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);


    }


    //subject selection

    public void ChangeSubject(int index)
    {
        this.subjectIndex = index;
        subjects[index].SetActive(true);

        Debug.Log(subjects[index]);

        PlayerPrefs.SetInt("SelectedSubject", subjectIndex);


    }

    //pøepnout na vlastní
    public void ChangeSubjectVlastni(int index)
    {
        this.subjectIndexVl = index;
        subjectsVlastni[index].SetActive(true);

        PlayerPrefs.SetInt("SelectedSubjectVl", subjectIndexVl);


    }


    //exercise selection
    public void ChangeExercise(int index)
    {
        this.exerciseIndex = index;
        exercises[index].SetActive(true);

        Debug.Log(exercises[index]);

        PlayerPrefs.SetInt("SelectedExercise", exerciseIndex);

    }


    //math selection - true/false  || numbers throwing
    public void ChangeMath(int index)
    {
        this.mathIndex = index;
        math_exercise[index].SetActive(true);

        Debug.Log(math_exercise[index]);

        PlayerPrefs.SetInt("SelectedMath", mathIndex);

    }


    //play game
    public void PlayGame()
    {
       // if (subjectIndex == 0 || subjectIndex == 1)
       // {
            SceneManager.LoadScene("game");
       // }
        //   if (subjectIndex == 2)
       // {
         //   SceneManager.LoadScene("Game_notes");
       // }

    }



    //volume
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
       
    }

    public void QuietDown(float volume)
    {
        audioMixer.SetFloat("volume", -80);
    }

    public void TurnOn(float volume)
    {
        audioMixer.SetFloat("volume", 0);
    }

    public void ChangeSound(int index2)
    {
        this.soundIndex = index2;
        sounds[index2].SetActive(true);

        PlayerPrefs.SetInt("Sound", soundIndex);
    }



}
