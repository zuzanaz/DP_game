using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public static Vector3 pos = new Vector3(-3.6f, -1.96f, -5);

    public GameObject[] playerPrefabs;
    private int characterIndex;

    public static bool GameStarted = false;
    public GameObject StartUI_czech_iy;
    public GameObject StartUI_czech_sz;
    public GameObject StartUI_math;
    public GameObject StartUI_music;
    public GameObject StartUI_music2;
    public GameObject StartUI_math2;
    public GameObject StartUI_other;
    private int exerciseIndex;
    private int subjectIndex;
    private int soundIndex;
    private int mathIndex;
    private int subjectIndexVl;

    public GameObject turnoff;
    public GameObject turnon;
    public GameObject[] sounds;

    public GameObject math;
    public GameObject czech;
    public GameObject music;
    public GameObject other;


    void Awake()
    {
        exerciseIndex = PlayerPrefs.GetInt("SelectedExercise", 9);
        subjectIndex = PlayerPrefs.GetInt("SelectedSubject", 0);
        soundIndex = PlayerPrefs.GetInt("Sound", 0);
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        mathIndex = PlayerPrefs.GetInt("SelectedMath", 0);
        subjectIndexVl = PlayerPrefs.GetInt("SelectedSubjectVl", 0);



        Instantiate(playerPrefabs[characterIndex], pos, Quaternion.identity);


        Time.timeScale = 0f;
        GameStarted = true;

        //pozadí dle pøedmìtu
        if (subjectIndex == 0 && subjectIndexVl == 0)
        {
            czech.SetActive(true);
        }
        if (subjectIndex == 1 && subjectIndexVl == 0)
        {
            math.SetActive(true);
        }
        if (subjectIndex == 2 && subjectIndexVl == 0)
        {
            music.SetActive(true);
        }
        if (subjectIndexVl == 1)
        {
            other.SetActive(true);
        }



        //úvodní návod, jak hrát
        if (subjectIndex == 0 && exerciseIndex == 8 && subjectIndexVl == 0)
        {
            StartUI_czech_sz.SetActive(true);
            Time.timeScale = 0f;
            GameStarted = true;
        }
        if (subjectIndex == 0 && exerciseIndex != 8 && subjectIndexVl == 0)
        {
            StartUI_czech_iy.SetActive(true);
            Time.timeScale = 0f;
            GameStarted = true;
        }
        if (subjectIndex == 1 && mathIndex == 0 && subjectIndexVl == 0)
        {
            StartUI_math.SetActive(true);
            Time.timeScale = 0f;
            GameStarted = true;
        }
        if (subjectIndex == 1 && mathIndex == 1 && subjectIndexVl == 0)
        {
            StartUI_math2.SetActive(true);
            Time.timeScale = 0f;
            GameStarted = true;
        }
        if (subjectIndex == 2 && exerciseIndex != 17 && subjectIndexVl == 0)
        {
            StartUI_music.SetActive(true);
            Time.timeScale = 0f;
            GameStarted = true;
        }
        if (subjectIndex == 2 && exerciseIndex == 17 && subjectIndexVl == 0)
        {
            StartUI_music2.SetActive(true);
            Time.timeScale = 0f;
            GameStarted = true;
        }
        if (subjectIndexVl == 1 )
        {
            StartUI_other.SetActive(true);
            Time.timeScale = 0f;
            GameStarted = true;
        }


        //po spuštìní automaticky obrázek vypnutého/zapnutého zvuku
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

    }

    private void Start()
    {

    }

    void Update()
    {


        //po zmáèknutí jakékoliv klávesy zrušit návod a spustit hru
        if ((StartUI_czech_iy.activeSelf == true || StartUI_czech_sz.activeSelf == true || StartUI_math.activeSelf == true || StartUI_music.activeSelf == true || StartUI_music2.activeSelf == true || StartUI_math2.activeSelf == true || StartUI_other.activeSelf == true)
            && (Input.anyKeyDown))
        {
            StartUI_czech_iy.SetActive(false);
            StartUI_czech_sz.SetActive(false);
            StartUI_math.SetActive(false);
            StartUI_music.SetActive(false);
            StartUI_music2.SetActive(false);
            StartUI_math2.SetActive(false);
            StartUI_other.SetActive(false);
            Time.timeScale = 1f;
            GameStarted = false;
        }

    }

    //nastavení zvuku
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
