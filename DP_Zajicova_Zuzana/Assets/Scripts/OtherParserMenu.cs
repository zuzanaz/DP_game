using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OtherParserMenu : MonoBehaviour
{
    public static List<Word> otherPredmety = new List<Word>();
    public static List<Word> otherTemata1 = new List<Word>();
    public static List<Word> otherTemata2 = new List<Word>();
    public static List<Word> otherTemata3 = new List<Word>();
    public static List<Word> otherTemata4 = new List<Word>();
    public static List<Word> otherTemata5 = new List<Word>();


    public static OtherParserMenu otherParserMenu;
    public int linesPredmety;
    public int linesTemata1;
    public int linesTemata2;
    public int linesTemata3;
    public int linesTemata4;
    public int linesTemata5;

    public TextMeshProUGUI[] predmety_text;
    public Button[] predmety_btn;


    void Awake()
    {
        otherParserMenu = this;
        StartCoroutine(GetRequest("https://zuzana.pythonanywhere.com/download?path=predmety/predmety.txt"));
        StartCoroutine(GetRequestTema1("https://zuzana.pythonanywhere.com/download?path=predmety/temata1.txt"));
        StartCoroutine(GetRequestTema2("https://zuzana.pythonanywhere.com/download?path=predmety/temata2.txt"));
        StartCoroutine(GetRequestTema3("https://zuzana.pythonanywhere.com/download?path=predmety/temata3.txt"));
        StartCoroutine(GetRequestTema4("https://zuzana.pythonanywhere.com/download?path=predmety/temata4.txt"));
        StartCoroutine(GetRequestTema5("https://zuzana.pythonanywhere.com/download?path=predmety/temata5.txt"));

     
    }
  



    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
            linesPredmety = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split();
                otherPredmety.Add(new Word() { word = tmp[0] });
            }

            /*
            //tlacitka menu
            if (linesPredmety == 1)
            {
                predmety_text[0].text = otherPredmety[0].word;
                predmety_btn[0].gameObject.SetActive(true);

            }
            else if (linesPredmety == 2)
            {
                predmety_text[1].text = otherPredmety[1].word;
                predmety_btn[1].gameObject.SetActive(true);
                predmety_text[0].text = otherPredmety[0].word;
                predmety_btn[0].gameObject.SetActive(true);

            }
            else if (linesPredmety == 3)
            {
                predmety_text[2].text = otherPredmety[2].word;
                predmety_btn[2].gameObject.SetActive(true);
                predmety_text[1].text = otherPredmety[1].word;
                predmety_btn[1].gameObject.SetActive(true);
                predmety_text[0].text = otherPredmety[0].word;
                predmety_btn[0].gameObject.SetActive(true);
                print(otherPredmety[2].word + "3");
            }
            else if (linesPredmety == 4)
            {
                predmety_text[3].text = otherPredmety[3].word;
                predmety_btn[3].gameObject.SetActive(true);
                predmety_text[2].text = otherPredmety[2].word;
                predmety_btn[2].gameObject.SetActive(true);
                predmety_text[1].text = otherPredmety[1].word;
                predmety_btn[1].gameObject.SetActive(true);
                predmety_text[0].text = otherPredmety[0].word;
                predmety_btn[0].gameObject.SetActive(true);

            }
            else if (linesPredmety == 5)
            {
                predmety_text[4].text = otherPredmety[4].word;
                predmety_btn[4].gameObject.SetActive(true);
                predmety_text[3].text = otherPredmety[3].word;
                predmety_btn[3].gameObject.SetActive(true);
                predmety_text[2].text = otherPredmety[2].word;
                predmety_btn[2].gameObject.SetActive(true);
                predmety_text[1].text = otherPredmety[1].word;
                predmety_btn[1].gameObject.SetActive(true);
                predmety_text[0].text = otherPredmety[0].word;
                predmety_btn[0].gameObject.SetActive(true);

            }
            */

        }
    }


    IEnumerator GetRequestTema1(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;
                case UnityWebRequest.Result.Success:
                    break;
            }
            linesTemata1 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split();
                otherTemata1.Add(new Word() { word = tmp[0] });
            }
        }
    }


    IEnumerator GetRequestTema2(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;
                case UnityWebRequest.Result.Success:
                    break;
            }
            linesTemata2 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split();
                otherTemata2.Add(new Word() { word = tmp[0] });
            }
        }
    }
    IEnumerator GetRequestTema3(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;
                case UnityWebRequest.Result.Success:
                    break;
            }
            linesTemata3 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split();
                otherTemata3.Add(new Word() { word = tmp[0] });
            }
        }
    }
    IEnumerator GetRequestTema4(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;
                case UnityWebRequest.Result.Success:
                    break;
            }
            linesTemata4 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split();
                otherTemata4.Add(new Word() { word = tmp[0] });
            }
        }
    }
    IEnumerator GetRequestTema5(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;
                case UnityWebRequest.Result.Success:
                    break;
            }
            linesTemata5 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split();
                otherTemata5.Add(new Word() { word = tmp[0] });
            }
        }
    }

}
