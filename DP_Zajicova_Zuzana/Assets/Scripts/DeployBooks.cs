using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeployBooks : MonoBehaviour
{
    public GameObject booksPrefab;
    private float respawnTime = 1;
    private Vector2 screenBounds;

    public Score score;
    public OtherParser otherParser;

    private int exerciseIndex;
    private int subjectIndex;
    private int mathIndex;
    private int subjectIndexVl;
    private int subjectIndexVlastni;
    private int exerciseIndexVlastni;


    public GameObject[] notes;
    public GameObject[] notes_hodnoty;

    int randomNote;
    int randomNote_hodnota;



    private void Awake()
    {
        exerciseIndex = PlayerPrefs.GetInt("SelectedExercise", 9);
        subjectIndex = PlayerPrefs.GetInt("SelectedSubject", 9);
        mathIndex = PlayerPrefs.GetInt("SelectedMath", 0);
        subjectIndexVl = PlayerPrefs.GetInt("SelectedSubjectVl", 0);
        subjectIndexVlastni = PlayerPrefs.GetInt("SelectedSubjectVlastni", 0);
        exerciseIndexVlastni = PlayerPrefs.GetInt("SelectedExerciseVlastni", 0);
    }
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //èeština matika, vytváøí knížky s textem
        if ((subjectIndex == 0 && subjectIndexVl == 0) || (subjectIndex == 1 && subjectIndexVl == 0) || subjectIndexVl == 1)
        { StartCoroutine(bookWave()); }

        //hudebka náhodnì generuje obrázky not
        if (subjectIndex == 2 && subjectIndexVl == 0)
        { StartCoroutine(noteWave()); }


    }

    void Update()
    {
        //zrychlování tvorby objektù dle skóre, postupnì se zrychluje

        // print(Score.score_.score);
        //èeština
        if (subjectIndex == 0 && subjectIndexVl == 0)
        {
            if (Score.score_.score <= 10)
            {
                respawnTime = 6;
            }
            else if (Score.score_.score > 10 && Score.score_.score <= 20)
            {
                respawnTime = 5;
            }
            else if (Score.score_.score > 20 && Score.score_.score <= 50)
            {
                respawnTime = 4;
            }

            else if (Score.score_.score > 50)
            {
                respawnTime = 3;
            }
        }
        //matika
        if ((subjectIndex == 1 && subjectIndexVl == 0) || subjectIndexVl == 1)
        {
            if (Score.score_.score <= 10)
            {
                respawnTime = 6;
            }
            else if (Score.score_.score > 10 && Score.score_.score <= 40)
            {
                respawnTime = 5;
            }
            else if (Score.score_.score > 40 && Score.score_.score <= 100)
            {
                respawnTime = 4;
            }

            else if (Score.score_.score > 100)
            {
                respawnTime = 3;
            }
        }
        //hudebka
        if (subjectIndex == 2 && subjectIndexVl == 0)
        {
            if (Score.score_.score <= 30)
            {
                respawnTime = 6;
            }
            else if (Score.score_.score > 30 && Score.score_.score <= 50)
            {
                respawnTime = 5;
            }
            else if (Score.score_.score > 50 && Score.score_.score <= 100)
            {
                respawnTime = 4;
            }

            else if (Score.score_.score > 100)
            {
                respawnTime = 3;
            }
        }
    }

    //create books
    private void spawnEnemy()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;


        GameObject a = Instantiate(booksPrefab) as GameObject;
        TextMeshPro textMesh = a.GetComponentInChildren<TextMeshPro>();
        a.transform.position = new Vector3(Random.Range(-screenBounds.x + 2, screenBounds.x - 1), screenBounds.y * 1.3f, -2);

        if (subjectIndexVl == 0)
        {
            //B
            if (exerciseIndex == 0)
            {
                Word index = WordParser.words0[Random.Range(0, 162)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //L
            else if (exerciseIndex == 1)
            {
                Word index = WordParser.words1[Random.Range(0, 91)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //M
            else if (exerciseIndex == 2)
            {
                Word index = WordParser.words2[Random.Range(0, 111)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //P
            else if (exerciseIndex == 3)
            {
                Word index = WordParser.words3[Random.Range(0, 65)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //S
            else if (exerciseIndex == 4)
            {
                Word index = WordParser.words4[Random.Range(0, 88)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //V
            else if (exerciseIndex == 5)
            {
                Word index = WordParser.words5[Random.Range(0, 147)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //Z
            else if (exerciseIndex == 6)
            {
                Word index = WordParser.words6[Random.Range(0, 52)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //  i/y
            else if (exerciseIndex == 7)
            {
                Word index = WordParser.words7[Random.Range(0, 105)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //  s/z
            else if (exerciseIndex == 8)
            {
                Word index = WordParser.words8[Random.Range(0, 69)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //  mix èeština
            else if (exerciseIndex == 9)
            {
                Word index = WordParser.words9[Random.Range(0, 1492)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }




            //matika
            //20
            else if (exerciseIndex == 10 && mathIndex == 0)
            {
                Word index = MathParser.number[Random.Range(0, 104)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }
            else if (exerciseIndex == 10 && mathIndex == 1)
            {
                Word index = MathParser.number2[Random.Range(0, 105)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }


            // *
            else if (exerciseIndex == 11 && mathIndex == 0)
            {
                Word index = MathParser.number[Random.Range(105, 159)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }
            else if (exerciseIndex == 11 && mathIndex == 1)
            {
                Word index = MathParser.number2[Random.Range(106, 160)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            // /
            else if (exerciseIndex == 12 && mathIndex == 0)
            {
                Word index = MathParser.number[Random.Range(160, 214)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }
            else if (exerciseIndex == 12 && mathIndex == 1)
            {
                Word index = MathParser.number2[Random.Range(161, 215)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

            //mix
            else if (exerciseIndex == 13 && mathIndex == 0)
            {
                Word index = MathParser.number[Random.Range(0, 214)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }
            else if (exerciseIndex == 13 && mathIndex == 1)
            {
                Word index = MathParser.number2[Random.Range(0, 215)];
                textMesh.text = index.word;
                a.GetComponent<Book>().word = index;
            }

        }

        //  další (vlastní)
        else if (subjectIndexVl == 1)
        {
         
            if (subjectIndexVlastni == 0)
            {
                

                if (exerciseIndexVlastni == 0 && OtherParser.otherParser.lines1 !=0)
                {
                    Word index = OtherParser.other1[Random.Range(0, OtherParser.otherParser.lines1 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 1 && OtherParser.otherParser.lines2 != 0)
                {
                    Word index = OtherParser.other2[Random.Range(0, OtherParser.otherParser.lines2 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 2 && OtherParser.otherParser.lines3 != 0)
                {
                    Word index = OtherParser.other3[Random.Range(0, OtherParser.otherParser.lines3 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 3 && OtherParser.otherParser.lines4 != 0)
                {
                    Word index = OtherParser.other4[Random.Range(0, OtherParser.otherParser.lines4 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 4 && OtherParser.otherParser.lines5 != 0)
                {
                    Word index = OtherParser.other5[Random.Range(0, OtherParser.otherParser.lines5 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
            }
            if (subjectIndexVlastni == 1)
            {
                if (exerciseIndexVlastni == 0 && OtherParser.otherParser.lines6 != 0)
                {
                    Word index = OtherParser.other6[Random.Range(0, OtherParser.otherParser.lines6 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 1 && OtherParser.otherParser.lines7 != 0)
                {
                    Word index = OtherParser.other7[Random.Range(0, OtherParser.otherParser.lines7 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 2 && OtherParser.otherParser.lines8 != 0)
                {
                    Word index = OtherParser.other8[Random.Range(0, OtherParser.otherParser.lines8 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 3 && OtherParser.otherParser.lines9 != 0)
                {
                    Word index = OtherParser.other9[Random.Range(0, OtherParser.otherParser.lines9 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 4 && OtherParser.otherParser.lines10 != 0)
                {
                    Word index = OtherParser.other10[Random.Range(0, OtherParser.otherParser.lines10 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
            }
            if (subjectIndexVlastni == 2)
            {
                if (exerciseIndexVlastni == 0 && OtherParser.otherParser.lines11 != 0)
                {
                    Word index = OtherParser.other11[Random.Range(0, OtherParser.otherParser.lines11 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 1 && OtherParser.otherParser.lines12 != 0)
                {
                    Word index = OtherParser.other12[Random.Range(0, OtherParser.otherParser.lines12 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 2 && OtherParser.otherParser.lines13 != 0)
                {
                    Word index = OtherParser.other13[Random.Range(0, OtherParser.otherParser.lines13 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 3 && OtherParser.otherParser.lines14 != 0)
                {
                    Word index = OtherParser.other14[Random.Range(0, OtherParser.otherParser.lines14 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 4 && OtherParser.otherParser.lines15 != 0)
                {
                    Word index = OtherParser.other15[Random.Range(0, OtherParser.otherParser.lines15 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
            }
            if (subjectIndexVlastni == 3)
            {
                if (exerciseIndexVlastni == 0 && OtherParser.otherParser.lines16 != 0)
                {
                    Word index = OtherParser.other16[Random.Range(0, OtherParser.otherParser.lines16 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 1 && OtherParser.otherParser.lines17 != 0)
                {
                    Word index = OtherParser.other17[Random.Range(0, OtherParser.otherParser.lines17 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 2 && OtherParser.otherParser.lines18 != 0)
                {
                    Word index = OtherParser.other18[Random.Range(0, OtherParser.otherParser.lines18 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 3 && OtherParser.otherParser.lines19 != 0)
                {
                    Word index = OtherParser.other19[Random.Range(0, OtherParser.otherParser.lines19 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 4 && OtherParser.otherParser.lines20 != 0)
                {
                    Word index = OtherParser.other20[Random.Range(0, OtherParser.otherParser.lines20 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
            }
            if (subjectIndexVlastni == 4)
            {
                if (exerciseIndexVlastni == 0 && OtherParser.otherParser.lines21 != 0)
                {
                    Word index = OtherParser.other21[Random.Range(0, OtherParser.otherParser.lines21 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 1 && OtherParser.otherParser.lines22 != 0)
                {
                    Word index = OtherParser.other22[Random.Range(0, OtherParser.otherParser.lines22 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 2 && OtherParser.otherParser.lines23 != 0)
                {
                    Word index = OtherParser.other23[Random.Range(0, OtherParser.otherParser.lines23 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 3 && OtherParser.otherParser.lines24 != 0)
                {
                    Word index = OtherParser.other24[Random.Range(0, OtherParser.otherParser.lines24 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
                if (exerciseIndexVlastni == 4 && OtherParser.otherParser.lines25 != 0)
                {
                    Word index = OtherParser.other25[Random.Range(0, OtherParser.otherParser.lines25 - 1)];
                    textMesh.text = index.word;
                    a.GetComponent<Book>().word = index;
                }
            }
        }

    }

    IEnumerator bookWave()
    {

        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }

    IEnumerator noteWave()
    {

        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnNote();
        }
    }


    private void spawnNote()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;


        //houslovy klic 
        if (exerciseIndex == 14)
        {
            randomNote = Random.Range(13, notes.Length);
            GameObject a = Instantiate(notes[randomNote]) as GameObject;
            a.transform.position = new Vector3(Random.Range(-screenBounds.x + 2, screenBounds.x - 1), screenBounds.y * 1.3f, -2);
        }

        //basovy klic 
        if (exerciseIndex == 15)
        {
            randomNote = Random.Range(0, 12);
            GameObject a = Instantiate(notes[randomNote]) as GameObject;
            a.transform.position = new Vector3(Random.Range(-screenBounds.x + 2, screenBounds.x - 1), screenBounds.y * 1.3f, -2);
        }

        //mix 
        if (exerciseIndex == 16)
        {
            randomNote = Random.Range(0, notes.Length);
            GameObject a = Instantiate(notes[randomNote]) as GameObject;
            a.transform.position = new Vector3(Random.Range(-screenBounds.x + 2, screenBounds.x - 1), screenBounds.y * 1.3f, -2);
        }

        //hodnoty 
        if (exerciseIndex == 17)
        {
            randomNote_hodnota = Random.Range(0, notes_hodnoty.Length);
            GameObject b = Instantiate(notes_hodnoty[randomNote_hodnota]) as GameObject;
            b.transform.position = new Vector3(Random.Range(-screenBounds.x + 2, screenBounds.x - 1), screenBounds.y * 1.3f, -2);
        }
    }


}
