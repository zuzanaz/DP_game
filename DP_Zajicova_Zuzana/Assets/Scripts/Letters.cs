using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Letters : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Score score;
    private Vector2 screenBounds;

    public GameObject Prefab_1;
    public GameObject Prefab_10;
    int exerciseIndex;
    int subjectIndex;
    int mathIndex;
    int subjectIndexVl;



    void Start()
    {
        rb.velocity = transform.up * speed;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        exerciseIndex = PlayerPrefs.GetInt("SelectedExercise", 9);
        subjectIndex = PlayerPrefs.GetInt("SelectedSubject", 0);
        mathIndex = PlayerPrefs.GetInt("SelectedMath", 0);
        subjectIndexVl = PlayerPrefs.GetInt("SelectedSubjectVl", 0);

    }

    void Update()
    {

        //destroy letter - out of screen
        if (transform.position.y > screenBounds.y - 1.5)
        {
            Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        //kolize s knihou, pouze jednou
        if ((collider.gameObject.name == "otevrenakniha(Clone)") && collider.isTrigger )
        {
            collider.isTrigger = false;
           
            Book word = collider.gameObject.GetComponent<Book>();
            print(word);
            print(word.word);

            TextMeshPro text = GetComponentInChildren<TextMeshPro>();
            print(text);

            TextMeshPro text_book = collider.gameObject.GetComponentInChildren<TextMeshPro>();

            text_book.text = word.word.word.Replace('_', text.text[0]);




            exerciseIndex = PlayerPrefs.GetInt("SelectedExercise", 9);
            subjectIndex = PlayerPrefs.GetInt("SelectedSubject", 0);


            //èeština nesprávná odpovìï --> ztratit život, zabarvit knihu èervenì, zobrazit ztrátu životu, zvuk,...
            if (sceneName == "game" && word.word.correctString != text.text && subjectIndex == 0 && subjectIndexVl != 1
                //( exerciseIndex == 0 || exerciseIndex == 1 || exerciseIndex == 2 || exerciseIndex == 3 || exerciseIndex == 4 || exerciseIndex == 5 || exerciseIndex == 6 || exerciseIndex == 7 || exerciseIndex == 8 || exerciseIndex == 9 )
                )
            {

                LifeCount.lifeCount.LoseLife();
                FindObjectOfType<AudioManager>().Play("False");
                text_book.color = Color.red;
                GameObject p_10 = Instantiate(Prefab_1, collider.transform.position, Quaternion.identity);
                Destroy(p_10.gameObject, 0.3f);
            }

            //èeština správná odpovìï --> score, zelenì,...
            if (sceneName == "game" && word.word.correctString == text.text && subjectIndex == 0 && subjectIndexVl != 1)
            //(exerciseIndex == 0 || exerciseIndex == 1 || exerciseIndex == 2 || exerciseIndex == 3 || exerciseIndex == 4 || exerciseIndex == 5 || exerciseIndex == 6 || exerciseIndex == 7 || exerciseIndex == 8 || exerciseIndex == 9))
            {
                Score.score_.score += 10;
                FindObjectOfType<AudioManager>().Play("True");
                text_book.color = Color.green;
                GameObject p_1 = Instantiate(Prefab_10, collider.transform.position, Quaternion.identity);
                //Score.score_.IncreaseScore();
                Destroy(p_1.gameObject, 0.3f);
            }




            //matika nesprávná odpovìï
            if (sceneName == "game" && word.word.correctString != text.text && subjectIndex == 1 && subjectIndexVl != 1)
            //(exerciseIndex == 10 || exerciseIndex == 11 || exerciseIndex == 12 || exerciseIndex == 13 ))
            {
                LifeCount.lifeCount.LoseLife();
                FindObjectOfType<AudioManager>().Play("False");
                // text_book.color = Color.red;
                GameObject p_10 = Instantiate(Prefab_1, collider.transform.position, Quaternion.identity);
                Destroy(p_10.gameObject, 0.3f);
            }

            //matika správná odpovìï
            if (sceneName == "game" && word.word.correctString == text.text && subjectIndex == 1 && subjectIndexVl != 1)
            //&& (exerciseIndex == 10 || exerciseIndex == 11 || exerciseIndex == 12 || exerciseIndex == 13))
            {
                Score.score_.score += 10;
                FindObjectOfType<AudioManager>().Play("True");
                // text_book.color = Color.green;
                GameObject p_1 = Instantiate(Prefab_10, collider.transform.position, Quaternion.identity);
                //Score.score_.IncreaseScore();
                Destroy(p_1.gameObject, 0.3f);
            }


            //matika zabarvení ano/ne, dle správnosti výrazu, nikoliv odpovìdi
            if (sceneName == "game" && word.word.correctString == "a" && subjectIndex == 1 && mathIndex == 0 && subjectIndexVl != 1)
            {
                text_book.color = Color.green;
            }
            if (sceneName == "game" && word.word.correctString == "n" && subjectIndex == 1 && mathIndex == 0 && subjectIndexVl != 1)
            {
                text_book.color = Color.red;
            }

            //matika zabarvení, dle správnosti odpovìdi (doplòování èísel)
            if (sceneName == "game" && word.word.correctString == text.text && subjectIndex == 1 && mathIndex == 1 && subjectIndexVl != 1)
            {
                text_book.color = Color.green;
            }
            if (sceneName == "game" && word.word.correctString != text.text && subjectIndex == 1 && mathIndex == 1 && subjectIndexVl != 1)
            {
                text_book.color = Color.red;
            }



            //vlastní nesprávná odpovìï 
            if (sceneName == "game" && word.word.correctString != text.text && subjectIndexVl == 1 )
            {
                LifeCount.lifeCount.LoseLife();
                FindObjectOfType<AudioManager>().Play("False");
                text_book.color = Color.red;
                GameObject p_10 = Instantiate(Prefab_1, collider.transform.position, Quaternion.identity);
                Destroy(p_10.gameObject, 0.3f);
            }

            //vlastní správná odpovìï 
            if (sceneName == "game" && word.word.correctString == text.text && subjectIndexVl == 1)
            {
                Score.score_.score += 10;
                FindObjectOfType<AudioManager>().Play("True");
                text_book.color = Color.green;
                GameObject p_1 = Instantiate(Prefab_10, collider.transform.position, Quaternion.identity);
                Destroy(p_1.gameObject, 0.3f);
            }




            //smazat hozené písmeno/èíslo, smazat knihu po 0.5s (aby stihla být vidìt správnost odpovìdi, pro pouèení)
            Destroy(gameObject);
            Destroy(collider.gameObject, 0.5f);

        }





      






        //notes
        if (sceneName == "game" && collider.gameObject.name != "Player_girl(Clone)" && collider.gameObject.name != "Player_boy(Clone)" && collider.isTrigger

      && (collider.gameObject.name == "bass_a(Clone)" || collider.gameObject.name == "bass_a2(Clone)" || collider.gameObject.name == "bass_c(Clone)" || collider.gameObject.name == "bass_c2(Clone)" || collider.gameObject.name == "bass_d(Clone)" || collider.gameObject.name == "bass_e(Clone)" || collider.gameObject.name == "bass_e2(Clone)" || collider.gameObject.name == "bass_f(Clone)" || collider.gameObject.name == "bass_f2(Clone)" || collider.gameObject.name == "bass_g(Clone)" || collider.gameObject.name == "bass_g2(Clone)" || collider.gameObject.name == "bass_h(Clone)" || collider.gameObject.name == "bass_h2(Clone)"
    || collider.gameObject.name == "a(Clone)" || collider.gameObject.name == "c(Clone)" || collider.gameObject.name == "c2(Clone)" || collider.gameObject.name == "d(Clone)" || collider.gameObject.name == "d2(Clone)" || collider.gameObject.name == "e(Clone)" || collider.gameObject.name == "e2(Clone)" || collider.gameObject.name == "f(Clone)" || collider.gameObject.name == "f2(Clone)" || collider.gameObject.name == "g(Clone)" || collider.gameObject.name == "g2(Clone)" || collider.gameObject.name == "h(Clone)" || collider.gameObject.name == "h1(Clone)"
     || collider.gameObject.name == "1(Clone)" || collider.gameObject.name == "2(Clone)" || collider.gameObject.name == "4(Clone)" || collider.gameObject.name == "8(Clone)" || collider.gameObject.name == "16(Clone)" || collider.gameObject.name == "32(Clone)" || collider.gameObject.name == "64(Clone)"
    ))
        {

            collider.isTrigger = false;
            TextMeshPro text = GetComponentInChildren<TextMeshPro>();

            if (text.text != "")
            {
                //správné odpovìdi not
                if ((collider.gameObject.name == "bass_a(Clone)" && text.text == "A")
                    || (collider.gameObject.name == "bass_a2(Clone)" && text.text == "A")
                    || (collider.gameObject.name == "bass_c(Clone)" && text.text == "C")
                    || (collider.gameObject.name == "bass_c2(Clone)" && text.text == "C")
                    || (collider.gameObject.name == "bass_d(Clone)" && text.text == "D")
                    || (collider.gameObject.name == "bass_e(Clone)" && text.text == "E")
                    || (collider.gameObject.name == "bass_e2(Clone)" && text.text == "E")
                    || (collider.gameObject.name == "bass_f(Clone)" && text.text == "F")
                    || (collider.gameObject.name == "bass_f2(Clone)" && text.text == "F")
                    || (collider.gameObject.name == "bass_g(Clone)" && text.text == "G")
                    || (collider.gameObject.name == "bass_g2(Clone)" && text.text == "G")
                    || (collider.gameObject.name == "bass_h(Clone)" && text.text == "H")
                    || (collider.gameObject.name == "bass_h2(Clone)" && text.text == "H")

                    || (collider.gameObject.name == "a(Clone)" && text.text == "A")
                    || (collider.gameObject.name == "c(Clone)" && text.text == "C")
                    || (collider.gameObject.name == "c2(Clone)" && text.text == "C")
                    || (collider.gameObject.name == "d(Clone)" && text.text == "D")
                    || (collider.gameObject.name == "d2(Clone)" && text.text == "D")
                    || (collider.gameObject.name == "e(Clone)" && text.text == "E")
                    || (collider.gameObject.name == "e2(Clone)" && text.text == "E")
                    || (collider.gameObject.name == "f(Clone)" && text.text == "F")
                    || (collider.gameObject.name == "f2(Clone)" && text.text == "F")
                    || (collider.gameObject.name == "g(Clone)" && text.text == "G")
                    || (collider.gameObject.name == "g2(Clone)" && text.text == "G")
                    || (collider.gameObject.name == "h(Clone)" && text.text == "H")
                    || (collider.gameObject.name == "h1(Clone)" && text.text == "H")

                      || (collider.gameObject.name == "1(Clone)" && text.text == "1")
                    || (collider.gameObject.name == "2(Clone)" && text.text == "2")
                    || (collider.gameObject.name == "4(Clone)" && text.text == "4")
                    || (collider.gameObject.name == "8(Clone)" && text.text == "8")
                    || (collider.gameObject.name == "16(Clone)" && text.text == "16")
                    || (collider.gameObject.name == "32(Clone)" && text.text == "32")
                    || (collider.gameObject.name == "64(Clone)" && text.text == "64")
                    )
                {
                    Score.score_.score += 10;
                    FindObjectOfType<AudioManager>().Play("True");
                    GameObject p_1 = Instantiate(Prefab_10, collider.transform.position, Quaternion.identity);
                    Destroy(p_1.gameObject, 0.3f);

                }
                //nesprávná odpovìï
                else

                //  && (collider.gameObject.name != "Player_boy(Clone)" || collider.gameObject.name != "Player_girl(Clone)")

                {
                    LifeCount.lifeCount.LoseLife();
                    FindObjectOfType<AudioManager>().Play("False");
                    GameObject p_10 = Instantiate(Prefab_1, collider.transform.position, Quaternion.identity);
                    Destroy(p_10.gameObject, 0.3f);

                }

                //smazat
                Destroy(gameObject);
                Destroy(collider.gameObject, 0.5f);
            }
        }

    }





}








