using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Throw : MonoBehaviour
{
    public Transform LaunchOffset;
    public GameObject letterPrefab;
    public GameObject doplnPrefab;

    public Score score;

    public Animator animator;
    int subjectIndex;
    int exerciseIndex;
    int mathIndex;
    int subjectIndexVl;

    public string pismena = "";


    private void Awake()
    {
        subjectIndex = PlayerPrefs.GetInt("SelectedSubject", 0);
        exerciseIndex = PlayerPrefs.GetInt("SelectedExercise", 0);
        mathIndex = PlayerPrefs.GetInt("SelectedMath", 0);
        subjectIndexVl = PlayerPrefs.GetInt("SelectedSubjectVl", 0);
        GameObject z = transform.GetChild(2).gameObject;


        //zobrazení nápisu krabièky, kterou drží hráè podle toho, co hází
        if (subjectIndex == 0 && exerciseIndex != 8 && subjectIndexVl != 1)
        {
            z.GetComponentInChildren<TextMeshPro>().text = "I/Y";
        }
        if (subjectIndex == 0 && exerciseIndex == 8 && subjectIndexVl != 1)
        {

            z.GetComponentInChildren<TextMeshPro>().text = "S/Z";
        }
        if (subjectIndex == 1 && mathIndex == 0 && subjectIndexVl != 1)
        {

            z.GetComponentInChildren<TextMeshPro>().text = "A/N";
        }
        if (subjectIndex == 1 && mathIndex == 1 && subjectIndexVl != 1)
        {

            z.GetComponentInChildren<TextMeshPro>().text = "123";
        }
        if (subjectIndex == 2 && exerciseIndex != 17 && subjectIndexVl != 1)
        {

            z.GetComponentInChildren<TextMeshPro>().text = "CDE";
        }


    }



    void Update()
    {
       // print(MouseOver.mouseOver.mouseOverButton);

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;


        //nastavení toho co hráè hází a na stisk jakých kláves reaguje
        if (sceneName == "game" && subjectIndex == 0 && exerciseIndex != 8 && subjectIndexVl != 1 && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Mouse1)))
        {
            Throws("y");
        }

        if (sceneName == "game" && subjectIndex == 1 && mathIndex == 0 && subjectIndexVl != 1 && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Mouse1)))
        {
            Throws("n");
        }

        if (sceneName == "game" && subjectIndex == 0 && exerciseIndex != 8 && subjectIndexVl != 1 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1) || (MouseOver.mouseOver.mouseOverButton == false && Input.GetKeyDown(KeyCode.Mouse0))))
        {
            Throws("i");
        }

        if (sceneName == "game" && subjectIndex == 1 && mathIndex == 0 && subjectIndexVl != 1 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1) || (MouseOver.mouseOver.mouseOverButton == false && Input.GetKeyDown(KeyCode.Mouse0))))
        {
            Throws("a");
        }

        if (subjectIndex == 0 && exerciseIndex == 8 && subjectIndexVl != 1 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1) || (MouseOver.mouseOver.mouseOverButton == false && Input.GetKeyDown(KeyCode.Mouse0))))
        {
            Throws("s");
        }

        if (subjectIndex == 0 && exerciseIndex == 8 && subjectIndexVl != 1 && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Mouse1)))
        {
            Throws("z");
        }



        //notes

        //naètení toho jakou klávesu hráè zmáèkl, nereagovat na šipky, space, return,.. pøi zmáèknutí napø. alpha0 pøepsat a uložit pouze jako 0
        var allKeys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
        foreach (var key in allKeys)
        {
            if (Input.GetKeyDown(key) && Time.timeScale == 1f)
            {
                //  Debug.Log(key + " was pressed.");
                if (key == KeyCode.Return || key == KeyCode.LeftArrow || key == KeyCode.RightArrow || key == KeyCode.Space || key == KeyCode.Mouse0 || key == KeyCode.Mouse1 || key == KeyCode.KeypadEnter || key == KeyCode.Return || key == KeyCode.Escape)
                    continue;
                //mazání uložených písmen
                else if (key == KeyCode.Backspace && pismena.Length > 0)
                {
                    pismena = pismena.Substring(0, pismena.Length - 1);
                }

                else if (key == KeyCode.Keypad0 || key == KeyCode.Alpha0)
                {
                    pismena += "0";
                }

                else if (key == KeyCode.Keypad1 || key == KeyCode.Alpha1)
                {
                    pismena += "1";
                }

                else if (key == KeyCode.Keypad2 || key == KeyCode.Alpha2)
                {
                    pismena += "2";
                }

                else if (key == KeyCode.Keypad3 || key == KeyCode.Alpha3)
                {
                    pismena += "3";
                }

                else if (key == KeyCode.Keypad4 || key == KeyCode.Alpha4)
                {
                    pismena += "4";
                }

                else if (key == KeyCode.Keypad5 || key == KeyCode.Alpha5)
                {
                    pismena += "5";
                }

                else if (key == KeyCode.Keypad6 || key == KeyCode.Alpha6)
                {
                    pismena += "6";
                }

                else if (key == KeyCode.Keypad7 || key == KeyCode.Alpha7)
                {
                    pismena += "7";
                }

                else if (key == KeyCode.Keypad8 || key == KeyCode.Alpha8)
                {
                    pismena += "8";
                }

                else if (key == KeyCode.Keypad9 || key == KeyCode.Alpha9)
                {
                    pismena += "9";
                }

                //uložit písmena
                else
                {
                    if (key.ToString().Length > 1 || char.IsSymbol(key.ToString()[0]))
                        continue;

                    pismena += key.ToString();
                }


                //hudebka - v krabièce hráèe zobrazovat to co napíšu, aby vidìl co hází
                if ((subjectIndex == 2 && exerciseIndex == 17 && subjectIndexVl == 0) || (subjectIndexVl == 1))
                {
                    GameObject z = transform.GetChild(2).gameObject;
                    z.GetComponentInChildren<TextMeshPro>().text = pismena;
                }
            }
        }


        //hudebka na stisk klávesy rovnou vyhodit písmeno
        if (sceneName == "game" && exerciseIndex != 17 && subjectIndex == 2 && subjectIndexVl != 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
            //GetKeyDown(KeyCode.Mouse0))
            //subjectIndex == 2 (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Alpha2)))
            { }
            else if (Input.anyKeyDown)
            {
                Throws(pismena);
            }
        }

        //písmena jsou vìtší než 0, na stisk enteru vyhodit
        if (((subjectIndex == 2 && exerciseIndex == 17 && subjectIndexVl != 1) || (subjectIndexVl == 1)) && pismena.Length > 0 && ((Input.GetKeyDown(KeyCode.Return) || (Input.GetKeyDown(KeyCode.KeypadEnter)) || (Input.GetKeyDown(KeyCode.Mouse0)))))
        {
            Throws(pismena);

            if (( subjectIndex == 2 && exerciseIndex == 17 && subjectIndexVl != 1) || (subjectIndexVl == 1))
            {
                GameObject z = transform.GetChild(2).gameObject;
                z.GetComponentInChildren<TextMeshPro>().text = pismena;
            }

        }



        //matika házet èísla
        if (subjectIndex == 1 && mathIndex == 1 && subjectIndexVl != 1
            && (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha9)
            || Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Keypad9)
                     ))
        {
            Throws(pismena);
        }

    }

    //házet pouze pokud je hra zaplá
    void Throws(string letter)
    {
        if ((Time.timeScale == 1f))
        {
            animator.SetTrigger("IsThrowing");
            if (exerciseIndex != 17 && subjectIndexVl==0)
            {
                GameObject y = Instantiate(letterPrefab, LaunchOffset.position, Quaternion.identity);
                y.GetComponent<TextMeshPro>().text = letter;
                y.GetComponent<Letters>().score = score;
                FindObjectOfType<AudioManager>().Play("Throw");
                pismena = "";
            }

            else
            {
                GameObject x = Instantiate(doplnPrefab, LaunchOffset.position, Quaternion.identity);
                x.GetComponent<TextMeshPro>().text = letter;
                x.GetComponent<Letters>().score = score;
                FindObjectOfType<AudioManager>().Play("Throw");
                pismena = "";
            }
        }
    }

}
