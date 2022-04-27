using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.Networking;
using System.Net;
using System.Text;

public class ToTextFile : MonoBehaviour
{
    public InputField inputFieldSpravne;
    public InputField inputFieldOtazka;
    public InputField input_predmet;
    public InputField input_tema;

    private int subjectIndexVlastni;
    private int exerciseIndexVlastni;
    public GameObject[] subjectsVlastni;
    public GameObject[] exercisesVlastni;


    public Button btn_add_predmet;
    public GameObject add_predmet;

    public Button btn_add_tema;
    public GameObject add_tema;

    public Button btn_add_otazky;
    public GameObject add_otazky;

    public TextMeshProUGUI[] predmety_text;
    public Button[] predmety_btn;

    public TextMeshProUGUI[] tema_predmety1;
    public Button[] temata1_btn;
    public TextMeshProUGUI[] tema_predmety2;
    public Button[] temata2_btn;
    public TextMeshProUGUI[] tema_predmety3;
    public Button[] temata3_btn;
    public TextMeshProUGUI[] tema_predmety4;
    public Button[] temata4_btn;
    public TextMeshProUGUI[] tema_predmety5;
    public Button[] temata5_btn;
    public GameObject[] inside;



    public int pocet_predmetu;
    public int pocet_temat;
    public int pocet_temat2;
    public int pocet_temat3;
    public int pocet_temat4;
    public int pocet_temat5;

    public GameObject prihlasen;

    public Transform contentWindow;
    public GameObject recallTextObject;

    void Start()
    {

        //listener na pøidání - vyskakovací okna s input
        btn_add_predmet.onClick.AddListener(ShowPredmet);
        btn_add_tema.onClick.AddListener(ShowTema);
        btn_add_otazky.onClick.AddListener(ShowOtazky);

        //player preferences
        subjectIndexVlastni = PlayerPrefs.GetInt("SelectedSubjectVlastni", 0);
        exerciseIndexVlastni = PlayerPrefs.GetInt("SelectedExerciseVlastni", 0);

      //  Instantiate(recallTextObject, contentWindow);
       // recallTextObject.GetComponent<Text>().text = OtherParser.other1[0].word;

    }




    void Update()
    {
      //  print(OtherParserMenu.otherParserMenu.linesPredmety);


        //zobrazeni tlacitek predmetu, dle txt souboru

        if (OtherParserMenu.otherParserMenu.linesPredmety == 1)
        {
            predmety_text[0].text = OtherParserMenu.otherPredmety[0].word;
            predmety_btn[0].gameObject.SetActive(true);
          
        }
        else if (OtherParserMenu.otherParserMenu.linesPredmety == 2)
        {
            predmety_text[1].text = OtherParserMenu.otherPredmety[1].word;
            predmety_btn[1].gameObject.SetActive(true);
            predmety_text[0].text = OtherParserMenu.otherPredmety[0].word;
            predmety_btn[0].gameObject.SetActive(true);

        }
        else if (OtherParserMenu.otherParserMenu.linesPredmety == 3)
        {
            predmety_text[2].text = OtherParserMenu.otherPredmety[2].word;
            predmety_btn[2].gameObject.SetActive(true);
            predmety_text[1].text = OtherParserMenu.otherPredmety[1].word;
            predmety_btn[1].gameObject.SetActive(true);
            predmety_text[0].text = OtherParserMenu.otherPredmety[0].word;
            predmety_btn[0].gameObject.SetActive(true);
          //  print(OtherParserMenu.otherPredmety[2].word + "3");
        }
      else  if (OtherParserMenu.otherParserMenu.linesPredmety == 4)
        {
            predmety_text[3].text = OtherParserMenu.otherPredmety[3].word;
            predmety_btn[3].gameObject.SetActive(true);
            predmety_text[2].text = OtherParserMenu.otherPredmety[2].word;
            predmety_btn[2].gameObject.SetActive(true);
            predmety_text[1].text = OtherParserMenu.otherPredmety[1].word;
            predmety_btn[1].gameObject.SetActive(true);
            predmety_text[0].text = OtherParserMenu.otherPredmety[0].word;
            predmety_btn[0].gameObject.SetActive(true);

        }
       else if (OtherParserMenu.otherParserMenu.linesPredmety == 5)
        {
            predmety_text[4].text = OtherParserMenu.otherPredmety[4].word;
            predmety_btn[4].gameObject.SetActive(true);
            predmety_text[3].text = OtherParserMenu.otherPredmety[3].word;
            predmety_btn[3].gameObject.SetActive(true);
            predmety_text[2].text = OtherParserMenu.otherPredmety[2].word;
            predmety_btn[2].gameObject.SetActive(true);
            predmety_text[1].text = OtherParserMenu.otherPredmety[1].word;
            predmety_btn[1].gameObject.SetActive(true);
            predmety_text[0].text = OtherParserMenu.otherPredmety[0].word;
            predmety_btn[0].gameObject.SetActive(true);

        }

        //zobrazeni tlacitek temat 1, dle txt souboru
        if (OtherParserMenu.otherParserMenu.linesTemata1 > 1)
        {
            Word index = OtherParserMenu.otherTemata1[0];
            tema_predmety1[0].text = index.word;
            temata1_btn[0].gameObject.SetActive(false);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata1 >= 1)
        {
            Word index = OtherParserMenu.otherTemata1[0];
            tema_predmety1[0].text = index.word;
            temata1_btn[0].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata1 >= 2)
        {
            Word index = OtherParserMenu.otherTemata1[1];
            tema_predmety1[1].text = index.word;
            temata1_btn[1].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata1 >= 3)
        {
            Word index = OtherParserMenu.otherTemata1[2];
            tema_predmety1[2].text = index.word;
            temata1_btn[2].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata1 >= 4)
        {
            Word index = OtherParserMenu.otherTemata1[3];
            tema_predmety1[3].text = index.word;
            temata1_btn[3].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata1 >= 5)
        {
            Word index = OtherParserMenu.otherTemata1[4];
            tema_predmety1[4].text = index.word;
            temata1_btn[4].gameObject.SetActive(true);
        }


        //zobrazeni tlacitek temat 2, dle txt souboru
        if (OtherParserMenu.otherParserMenu.linesTemata2 > 1)
        {
            Word index = OtherParserMenu.otherTemata2[0];
            tema_predmety2[0].text = index.word;
            temata2_btn[0].gameObject.SetActive(false);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata2 >= 1)
        {
            Word index = OtherParserMenu.otherTemata2[0];
            tema_predmety2[0].text = index.word;
            temata2_btn[0].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata2 >= 2)
        {
            Word index = OtherParserMenu.otherTemata2[1];
            tema_predmety2[1].text = index.word;
            temata2_btn[1].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata2 >= 3)
        {
            Word index = OtherParserMenu.otherTemata2[2];
            tema_predmety2[2].text = index.word;
            temata2_btn[2].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata2 >= 4)
        {
            Word index = OtherParserMenu.otherTemata2[3];
            tema_predmety2[3].text = index.word;
            temata2_btn[3].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata2 >= 5)
        {
            Word index = OtherParserMenu.otherTemata2[4];
            tema_predmety2[4].text = index.word;
            temata2_btn[4].gameObject.SetActive(true);
        }

        //zobrazeni tlacitek temat 3, dle txt souboru
        if (OtherParserMenu.otherParserMenu.linesTemata3 > 1)
        {
            Word index = OtherParserMenu.otherTemata3[0];
            tema_predmety3[0].text = index.word;
            temata3_btn[0].gameObject.SetActive(false);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata3 >= 1)
        {
            Word index = OtherParserMenu.otherTemata3[0];
            tema_predmety3[0].text = index.word;
            temata3_btn[0].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata3 >= 2)
        {
            Word index = OtherParserMenu.otherTemata3[1];
            tema_predmety3[1].text = index.word;
            temata3_btn[1].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata3 >= 3)
        {
            Word index = OtherParserMenu.otherTemata3[2];
            tema_predmety3[2].text = index.word;
            temata3_btn[2].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata3 >= 4)
        {
            Word index = OtherParserMenu.otherTemata3[3];
            tema_predmety3[3].text = index.word;
            temata3_btn[3].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata3 >= 5)
        {
            Word index = OtherParserMenu.otherTemata3[4];
            tema_predmety3[4].text = index.word;
            temata3_btn[4].gameObject.SetActive(true);
        }

        //zobrazeni tlacitek temat 4, dle txt souboru
        if (OtherParserMenu.otherParserMenu.linesTemata4 > 1)
        {
            Word index = OtherParserMenu.otherTemata4[0];
            tema_predmety4[0].text = index.word;
            temata4_btn[0].gameObject.SetActive(false);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata4 >= 1)
        {
            Word index = OtherParserMenu.otherTemata4[0];
            tema_predmety4[0].text = index.word;
            temata4_btn[0].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata4 >= 2)
        {
            Word index = OtherParserMenu.otherTemata4[1];
            tema_predmety4[1].text = index.word;
            temata4_btn[1].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata4 >= 3)
        {
            Word index = OtherParserMenu.otherTemata4[2];
            tema_predmety4[2].text = index.word;
            temata4_btn[2].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata4 >= 4)
        {
            Word index = OtherParserMenu.otherTemata4[3];
            tema_predmety4[3].text = index.word;
            temata4_btn[3].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata4 >= 5)
        {
            Word index = OtherParserMenu.otherTemata4[4];
            tema_predmety4[4].text = index.word;
            temata4_btn[4].gameObject.SetActive(true);
        }

        //zobrazeni tlacitek temat 5, dle txt souboru
        if (OtherParserMenu.otherParserMenu.linesTemata5 > 1)
        {
            Word index = OtherParserMenu.otherTemata5[0];
            tema_predmety4[0].text = index.word;
            temata4_btn[0].gameObject.SetActive(false);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata5 >= 1)
        {
            Word index = OtherParserMenu.otherTemata5[0];
            tema_predmety4[0].text = index.word;
            temata4_btn[0].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata5 >= 2)
        {
            Word index = OtherParserMenu.otherTemata5[1];
            tema_predmety5[1].text = index.word;
            temata5_btn[1].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata5 >= 3)
        {
            Word index = OtherParserMenu.otherTemata5[2];
            tema_predmety5[2].text = index.word;
            temata5_btn[2].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata5 >= 4)
        {
            Word index = OtherParserMenu.otherTemata5[3];
            tema_predmety5[3].text = index.word;
            temata5_btn[3].gameObject.SetActive(true);
        }
        if (OtherParserMenu.otherParserMenu.linesTemata5 >= 5)
        {
            Word index = OtherParserMenu.otherTemata5[4];
            tema_predmety5[4].text = index.word;
            temata5_btn[4].gameObject.SetActive(true);
        }








        //zobrazeni tlacitka pridat tema, pokud je aktivni alespon 1 predmet
        if (predmety_btn[0].gameObject.activeSelf == true && prihlasen.activeSelf == true)
        {
            btn_add_tema.gameObject.SetActive(true);
        }
        //pokud je plny pocet predmetu, nelze pridavat dalsi
        if (predmety_btn[4].gameObject.activeSelf == true)
        {
            btn_add_predmet.gameObject.SetActive(false);
        }

        //po prihlaseni 

        if (prihlasen.activeSelf == true)
        {
            btn_add_predmet.gameObject.SetActive(true);
        }
        else if (prihlasen.activeSelf == false)
        {
            btn_add_predmet.gameObject.SetActive(false);
            btn_add_otazky.gameObject.SetActive(false);
            btn_add_tema.gameObject.SetActive(false);
        }

        //pokud je tema, lze pridat otazky do souboru
        if (prihlasen.activeSelf == true && (temata1_btn[0].gameObject.activeSelf == true || temata2_btn[0].gameObject.activeSelf == true || temata3_btn[0].gameObject.activeSelf == true || temata4_btn[0].gameObject.activeSelf == true || temata5_btn[0].gameObject.activeSelf == true))
        {
            btn_add_otazky.gameObject.SetActive(true);
        }


        //zobrazeni temat dle predmetu
        if (subjectIndexVlastni == 0)
            inside[0].gameObject.SetActive(true);

        if (subjectIndexVlastni == 1)
        {
            inside[0].gameObject.SetActive(false);
            inside[1].gameObject.SetActive(true);
        }

        if (subjectIndexVlastni == 2)
        {
            inside[0].gameObject.SetActive(false);
            inside[1].gameObject.SetActive(false);
            inside[2].gameObject.SetActive(true);
        }

        if (subjectIndexVlastni == 3)
        {
            inside[0].gameObject.SetActive(false);
            inside[1].gameObject.SetActive(false);
            inside[2].gameObject.SetActive(false);
            inside[3].gameObject.SetActive(true);
        }

        if (subjectIndexVlastni == 4)
        {
            inside[0].gameObject.SetActive(false);
            inside[1].gameObject.SetActive(false);
            inside[2].gameObject.SetActive(false);
            inside[3].gameObject.SetActive(false);
            inside[4].gameObject.SetActive(true);
        }
    }



    //vytvorit novy predmet
    public void Create()
    {
        if (input_predmet.text != "" && OtherParserMenu.otherParserMenu.linesPredmety <= 5)
        {
            if (input_predmet.text != "" && predmety_btn[4].gameObject.activeSelf == false)
            {
                if (predmety_btn[0].gameObject.activeSelf == false)
                {
                    predmety_text[0].enabled = true;
                    predmety_btn[0].gameObject.SetActive(true);
                    predmety_text[0].text = input_predmet.text;
                    subjectIndexVlastni = 0;
                }
                else if (predmety_btn[0].gameObject.activeSelf == true && predmety_btn[1].gameObject.activeSelf == false)
                {
                    predmety_text[1].enabled = true;
                    predmety_btn[1].gameObject.SetActive(true);
                    predmety_text[1].text = input_predmet.text;
                    subjectIndexVlastni = 1;
                }
                else if (predmety_btn[1].gameObject.activeSelf == true && predmety_btn[2].gameObject.activeSelf == false)
                {
                    predmety_text[2].enabled = true;
                    predmety_btn[2].gameObject.SetActive(true);
                    predmety_text[2].text = input_predmet.text;
                    subjectIndexVlastni = 2;
                }
                else if (predmety_btn[2].gameObject.activeSelf == true && predmety_btn[3].gameObject.activeSelf == false)
                {
                    predmety_text[3].enabled = true;
                    predmety_btn[3].gameObject.SetActive(true);
                    predmety_text[3].text = input_predmet.text;
                    subjectIndexVlastni = 3;
                }
                else if (predmety_btn[3].gameObject.activeSelf == true && predmety_btn[4].gameObject.activeSelf == false)
                {
                    predmety_text[4].enabled = true;
                    predmety_btn[4].gameObject.SetActive(true);
                    predmety_text[4].text = input_predmet.text;
                    subjectIndexVlastni = 4;
                }

                StartCoroutine(UploadPredmet());
                input_predmet.text = "";
            }
        }
    }

    //vytvorit nove tema
    public void CreateTema()
    {

        if (input_tema.text != "" && subjectIndexVlastni == 0 && OtherParserMenu.otherParserMenu.linesTemata1 <= 5)
        {
            if (temata1_btn[4].gameObject.activeSelf == false)
            {
                if (temata1_btn[0].gameObject.activeSelf == false)
                {
                    tema_predmety1[0].enabled = true;
                    temata1_btn[0].gameObject.SetActive(true);
                    tema_predmety1[0].text = input_tema.text;
                    exerciseIndexVlastni = 0;
                }
                else if (temata1_btn[0].gameObject.activeSelf == true && temata1_btn[1].gameObject.activeSelf == false)
                {
                    tema_predmety1[1].enabled = true;
                    temata1_btn[1].gameObject.SetActive(true);
                    tema_predmety1[1].text = input_tema.text;
                    exerciseIndexVlastni = 1;
                }
                else if (temata1_btn[1].gameObject.activeSelf == true && temata1_btn[2].gameObject.activeSelf == false)
                {
                    tema_predmety1[2].enabled = true;
                    temata1_btn[2].gameObject.SetActive(true);
                    tema_predmety1[2].text = input_tema.text;
                    exerciseIndexVlastni = 2;
                }
                else if (temata1_btn[2].gameObject.activeSelf == true && temata1_btn[3].gameObject.activeSelf == false)
                {
                    tema_predmety1[3].enabled = true;
                    temata1_btn[3].gameObject.SetActive(true);
                    tema_predmety1[3].text = input_tema.text;
                    exerciseIndexVlastni = 3;
                }
                else if (temata1_btn[3].gameObject.activeSelf == true && temata1_btn[4].gameObject.activeSelf == false)
                {
                    tema_predmety1[4].enabled = true;
                    temata1_btn[4].gameObject.SetActive(true);
                    tema_predmety1[4].text = input_tema.text;
                    exerciseIndexVlastni = 4;
                }
            }
            StartCoroutine(UploadPredmet());
            input_tema.text = "";
        }

        if (input_tema.text != "" && subjectIndexVlastni == 1 && OtherParserMenu.otherParserMenu.linesTemata2 <= 5)
        {
            if (temata2_btn[4].gameObject.activeSelf == false)
            {
                if (temata2_btn[0].gameObject.activeSelf == false)
                {
                    tema_predmety2[0].enabled = true;
                    temata2_btn[0].gameObject.SetActive(true);
                    tema_predmety2[0].text = input_tema.text;
                    exerciseIndexVlastni = 0;
                }
                else if (temata2_btn[0].gameObject.activeSelf == true && temata2_btn[1].gameObject.activeSelf == false)
                {
                    tema_predmety2[1].enabled = true;
                    temata2_btn[1].gameObject.SetActive(true);
                    tema_predmety2[1].text = input_tema.text;
                    exerciseIndexVlastni = 1;
                }
                else if (temata2_btn[1].gameObject.activeSelf == true && temata2_btn[2].gameObject.activeSelf == false)
                {
                    tema_predmety2[2].enabled = true;
                    temata2_btn[2].gameObject.SetActive(true);
                    tema_predmety2[2].text = input_tema.text;
                    exerciseIndexVlastni = 2;
                }
                else if (temata2_btn[2].gameObject.activeSelf == true && temata2_btn[3].gameObject.activeSelf == false)
                {
                    tema_predmety2[3].enabled = true;
                    temata2_btn[3].gameObject.SetActive(true);
                    tema_predmety2[3].text = input_tema.text;
                    exerciseIndexVlastni = 3;
                }
                else if (temata2_btn[3].gameObject.activeSelf == true && temata2_btn[4].gameObject.activeSelf == false)
                {
                    tema_predmety2[4].enabled = true;
                    temata2_btn[4].gameObject.SetActive(true);
                    tema_predmety2[4].text = input_tema.text;
                    exerciseIndexVlastni = 4;
                }
            }
            //sendTema2ToFile();
            StartCoroutine(UploadPredmet());
            input_tema.text = "";
        }
        if (input_tema.text != "" && subjectIndexVlastni == 2 && OtherParserMenu.otherParserMenu.linesTemata3 <= 5)
        {
            if (temata3_btn[4].gameObject.activeSelf == false)
            {
                if (temata3_btn[0].gameObject.activeSelf == false)
                {
                    tema_predmety3[0].enabled = true;
                    temata3_btn[0].gameObject.SetActive(true);
                    tema_predmety3[0].text = input_tema.text;
                    exerciseIndexVlastni = 0;
                }
                else if (temata3_btn[0].gameObject.activeSelf == true && temata3_btn[1].gameObject.activeSelf == false)
                {
                    tema_predmety3[1].enabled = true;
                    temata3_btn[1].gameObject.SetActive(true);
                    tema_predmety3[1].text = input_tema.text;
                    exerciseIndexVlastni = 1;
                }
                else if (temata3_btn[1].gameObject.activeSelf == true && temata3_btn[2].gameObject.activeSelf == false)
                {
                    tema_predmety3[2].enabled = true;
                    temata3_btn[2].gameObject.SetActive(true);
                    tema_predmety3[2].text = input_tema.text;
                    exerciseIndexVlastni = 2;
                }
                else if (temata3_btn[2].gameObject.activeSelf == true && temata3_btn[3].gameObject.activeSelf == false)
                {
                    tema_predmety3[3].enabled = true;
                    temata3_btn[3].gameObject.SetActive(true);
                    tema_predmety3[3].text = input_tema.text;
                    exerciseIndexVlastni = 3;
                }
                else if (temata3_btn[3].gameObject.activeSelf == true && temata3_btn[4].gameObject.activeSelf == false)
                {
                    tema_predmety3[4].enabled = true;
                    temata3_btn[4].gameObject.SetActive(true);
                    tema_predmety3[4].text = input_tema.text;
                    exerciseIndexVlastni = 4;
                }
            }
            //sendTema3ToFile();
            StartCoroutine(UploadPredmet());
            input_tema.text = "";
        }
        if (input_tema.text != "" && subjectIndexVlastni == 3 && OtherParserMenu.otherParserMenu.linesTemata4 <= 5)
        {
            if (temata4_btn[4].gameObject.activeSelf == false)
            {
                if (temata4_btn[0].gameObject.activeSelf == false)
                {
                    tema_predmety4[0].enabled = true;
                    temata4_btn[0].gameObject.SetActive(true);
                    tema_predmety4[0].text = input_tema.text;
                    exerciseIndexVlastni = 0;
                }
                else if (temata4_btn[0].gameObject.activeSelf == true && temata4_btn[1].gameObject.activeSelf == false)
                {
                    tema_predmety4[1].enabled = true;
                    temata4_btn[1].gameObject.SetActive(true);
                    tema_predmety4[1].text = input_tema.text;
                    exerciseIndexVlastni = 1;
                }
                else if (temata4_btn[1].gameObject.activeSelf == true && temata4_btn[2].gameObject.activeSelf == false)
                {
                    tema_predmety4[2].enabled = true;
                    temata4_btn[2].gameObject.SetActive(true);
                    tema_predmety4[2].text = input_tema.text;
                    exerciseIndexVlastni = 2;
                }
                else if (temata4_btn[2].gameObject.activeSelf == true && temata4_btn[3].gameObject.activeSelf == false)
                {
                    tema_predmety4[3].enabled = true;
                    temata4_btn[3].gameObject.SetActive(true);
                    tema_predmety4[3].text = input_tema.text;
                    exerciseIndexVlastni = 3;
                }
                else if (temata4_btn[3].gameObject.activeSelf == true && temata4_btn[4].gameObject.activeSelf == false)
                {
                    tema_predmety4[4].enabled = true;
                    temata4_btn[4].gameObject.SetActive(true);
                    tema_predmety4[4].text = input_tema.text;
                    exerciseIndexVlastni = 4;
                }
            }
            //sendTema4ToFile();
            StartCoroutine(UploadPredmet());
            input_tema.text = "";
        }
        if (input_tema.text != "" && subjectIndexVlastni == 4 && OtherParserMenu.otherParserMenu.linesTemata5 <= 5)
        {
            if (temata5_btn[4].gameObject.activeSelf == false)
            {
                if (temata5_btn[0].gameObject.activeSelf == false)
                {
                    tema_predmety5[0].enabled = true;
                    temata5_btn[0].gameObject.SetActive(true);
                    tema_predmety5[0].text = input_tema.text;
                    exerciseIndexVlastni = 0;
                }
                else if (temata5_btn[0].gameObject.activeSelf == true && temata5_btn[1].gameObject.activeSelf == false)
                {
                    tema_predmety5[1].enabled = true;
                    temata5_btn[1].gameObject.SetActive(true);
                    tema_predmety5[1].text = input_tema.text;
                    exerciseIndexVlastni = 1;
                }
                else if (temata5_btn[1].gameObject.activeSelf == true && temata5_btn[2].gameObject.activeSelf == false)
                {
                    tema_predmety5[2].enabled = true;
                    temata5_btn[2].gameObject.SetActive(true);
                    tema_predmety5[2].text = input_tema.text;
                    exerciseIndexVlastni = 2;
                }
                else if (temata5_btn[2].gameObject.activeSelf == true && temata5_btn[3].gameObject.activeSelf == false)
                {
                    tema_predmety5[3].enabled = true;
                    temata5_btn[3].gameObject.SetActive(true);
                    tema_predmety5[3].text = input_tema.text;
                    exerciseIndexVlastni = 3;
                }
                else if (temata5_btn[3].gameObject.activeSelf == true && temata5_btn[4].gameObject.activeSelf == false)
                {
                    tema_predmety5[4].enabled = true;
                    temata5_btn[4].gameObject.SetActive(true);
                    tema_predmety5[4].text = input_tema.text;
                    exerciseIndexVlastni = 4;
                }
            }
            //sendTema5ToFile();
            StartCoroutine(UploadPredmet());
            input_tema.text = "";
        }


    }


    //pridej otazky
    public void New()
    {

        //text in input field send to log
        if (inputFieldSpravne.text != "" && inputFieldOtazka.text != "")
        {
            StartCoroutine(UploadOtazky());
            //sendOtazkyToFile();
            inputFieldSpravne.text = "";
            inputFieldOtazka.text = "";
        }

    }





    //zobraz vyskakovaci okno s input pro nove predmety
    public void ShowPredmet()
    {
        if (add_predmet.activeSelf != true)
        {
            add_predmet.SetActive(true);
        }
        else
        {
            add_predmet.SetActive(false);
        }
    }

    //zobraz vyskakovaci okno s input pro nova temata
    public void ShowTema()
    {
        if (add_tema.activeSelf == true)
        {
            add_tema.SetActive(false);
        }
        else
        {
            add_tema.SetActive(true);
        }
    }

    //zobraz vyskakovaci okno s input pro nove otazky
    public void ShowOtazky()
    {
        if (add_otazky.activeSelf == true)
        {
            add_otazky.SetActive(false);

        }
        else
        {
            add_otazky.SetActive(true);
        }
    }


    //subject selection
    public void ChangeSubjectVlastni(int index)
    {
        this.subjectIndexVlastni = index;
        subjectsVlastni[index].SetActive(true);

        Debug.Log(subjectsVlastni[index]);

        PlayerPrefs.SetInt("SelectedSubjectVlastni", subjectIndexVlastni);
    }


    //exercise selection
    public void ChangeExerciseVlastni(int index)
    {
        this.exerciseIndexVlastni = index;
        exercisesVlastni[index].SetActive(true);

        Debug.Log(exercisesVlastni[index]);

        PlayerPrefs.SetInt("SelectedExerciseVlastni", exerciseIndexVlastni);
    }

    IEnumerator UploadPredmet()
    {
        WWWForm form = new WWWForm();

        //predmety
        if (input_predmet.text != "")
        {
            form.AddField("path", "predmety/predmety.txt");
            form.AddField("content", input_predmet.text + "\n");
        }
        //temata
        if (input_tema.text != "" && subjectIndexVlastni == 0)
        {
            form.AddField("path", "predmety/temata1.txt");
            form.AddField("content", input_tema.text + "\n");
        }
        if (input_tema.text != "" && subjectIndexVlastni == 1)
        {
            form.AddField("path", "predmety/temata2.txt");
            form.AddField("content", input_tema.text + "\n");
        }
        if (input_tema.text != "" && subjectIndexVlastni == 2)
        {
            form.AddField("path", "predmety/temata3.txt");
            form.AddField("content", input_tema.text + "\n");
        }
        if (input_tema.text != "" && subjectIndexVlastni == 3)
        {
            form.AddField("path", "predmety/temata4.txt");
            form.AddField("content", input_tema.text + "\n");
        }
        if (input_tema.text != "" && subjectIndexVlastni == 4)
        {
            form.AddField("path", "predmety/temata5.txt");
            form.AddField("content", input_tema.text + "\n");
        }

        //nahrani
        using (UnityWebRequest www = UnityWebRequest.Post("https://zuzana.pythonanywhere.com/upload", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");

            }
        }
       
    }

   
            IEnumerator UploadOtazky()
    {
        WWWForm form = new WWWForm();
        if (inputFieldOtazka.text != "" && inputFieldSpravne.text != "" && subjectIndexVlastni == 0)
        {
            if (exerciseIndexVlastni == 0)
            {
                form.AddField("path", "predmety/otazky/1.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 1)
            {
                form.AddField("path", "predmety/otazky/2.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 2)
            {
                form.AddField("path", "predmety/otazky/3.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 3)
            {
                form.AddField("path", "predmety/otazky/4.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 4)
            {
                form.AddField("path", "predmety/otazky/5.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
        }
        if (inputFieldOtazka.text != "" && inputFieldSpravne.text != "" && subjectIndexVlastni == 1)
        {
            if (exerciseIndexVlastni == 0)
            {
                form.AddField("path", "predmety/otazky/6.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 1)
            {
                form.AddField("path", "predmety/otazky/7.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 2)
            {
                form.AddField("path", "predmety/otazky/8.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 3)
            {
                form.AddField("path", "predmety/otazky/9.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 4)
            {
                form.AddField("path", "predmety/otazky/10.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
        }
        if (inputFieldOtazka.text != "" && inputFieldSpravne.text != "" && subjectIndexVlastni == 2)
        {
            if (exerciseIndexVlastni == 0)
            {
                form.AddField("path", "predmety/otazky/11.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 1)
            {
                form.AddField("path", "predmety/otazky/12.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 2)
            {
                form.AddField("path", "predmety/otazky/13.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 3)
            {
                form.AddField("path", "predmety/otazky/14.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 4)
            {
                form.AddField("path", "predmety/otazky/15.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
        }
        if (inputFieldOtazka.text != "" && inputFieldSpravne.text != "" && subjectIndexVlastni == 3)
        {
            if (exerciseIndexVlastni == 0)
            {
                form.AddField("path", "predmety/otazky/16.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 1)
            {
                form.AddField("path", "predmety/otazky/17.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 2)
            {
                form.AddField("path", "predmety/otazky/18.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 3)
            {
                form.AddField("path", "predmety/otazky/19.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 4)
            {
                form.AddField("path", "predmety/otazky/20.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
        }
        if (inputFieldOtazka.text != "" && inputFieldSpravne.text != "" && subjectIndexVlastni == 4)
        {
            if (exerciseIndexVlastni == 0)
            {
                form.AddField("path", "predmety/otazky/21.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 1)
            {
                form.AddField("path", "predmety/otazky/22.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 2)
            {
                form.AddField("path", "predmety/otazky/23.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 3)
            {
                form.AddField("path", "predmety/otazky/24.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
            if (exerciseIndexVlastni == 4)
            {
                form.AddField("path", "predmety/otazky/25.txt");
                form.AddField("content", inputFieldSpravne.text.ToUpper() + "," + inputFieldOtazka.text + "\n");
            }
        }


        using (UnityWebRequest www = UnityWebRequest.Post("https://zuzana.pythonanywhere.com/upload", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }


}
