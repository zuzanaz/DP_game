using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class OtherParser : MonoBehaviour
{
    public static List<Word> predmetyList = new List<Word>();

    public static List<Word> other1 = new List<Word>();
    public static List<Word> other2 = new List<Word>();
    public static List<Word> other3 = new List<Word>();
    public static List<Word> other4 = new List<Word>();
    public static List<Word> other5 = new List<Word>();
    public static List<Word> other6 = new List<Word>();
    public static List<Word> other7 = new List<Word>();
    public static List<Word> other8 = new List<Word>();
    public static List<Word> other9 = new List<Word>();
    public static List<Word> other10 = new List<Word>();
    public static List<Word> other11 = new List<Word>();
    public static List<Word> other12 = new List<Word>();
    public static List<Word> other13 = new List<Word>();
    public static List<Word> other14 = new List<Word>();
    public static List<Word> other15 = new List<Word>();
    public static List<Word> other16 = new List<Word>();
    public static List<Word> other17 = new List<Word>();
    public static List<Word> other18 = new List<Word>();
    public static List<Word> other19 = new List<Word>();
    public static List<Word> other20 = new List<Word>();
    public static List<Word> other21 = new List<Word>();
    public static List<Word> other22 = new List<Word>();
    public static List<Word> other23 = new List<Word>();
    public static List<Word> other24 = new List<Word>();
    public static List<Word> other25 = new List<Word>();

    public static OtherParser otherParser;
    public int lines1;
    public int lines2;
    public int lines3;
    public int lines4;
    public int lines5;
    public int lines6;
    public int lines7;
    public int lines8;
    public int lines9;
    public int lines10;
    public int lines11;
    public int lines12;
    public int lines13;
    public int lines14;
    public int lines15;
    public int lines16;
    public int lines17;
    public int lines18;
    public int lines19;
    public int lines20;
    public int lines21;
    public int lines22;
    public int lines23;
    public int lines24;
    public int lines25;

    public int linesPredmety;
    private int subjectIndexVlastni;
    private int exerciseIndexVlastni;
    void Start()
    {
        otherParser = this;
        subjectIndexVlastni = PlayerPrefs.GetInt("SelectedSubjectVlastni", 0);
        exerciseIndexVlastni = PlayerPrefs.GetInt("SelectedExerciseVlastni", 0);
        StartCoroutine(GetRequestOtazky1("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/1.txt"));
        StartCoroutine(GetRequestOtazky2("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/2.txt"));
        StartCoroutine(GetRequestOtazky3("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/3.txt"));
        StartCoroutine(GetRequestOtazky4("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/4.txt"));
        StartCoroutine(GetRequestOtazky5("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/5.txt"));
        StartCoroutine(GetRequestOtazky6("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/6.txt"));
        StartCoroutine(GetRequestOtazky7("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/7.txt"));
        StartCoroutine(GetRequestOtazky8("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/8.txt"));
        StartCoroutine(GetRequestOtazky9("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/9.txt"));
        StartCoroutine(GetRequestOtazky10("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/10.txt"));
        StartCoroutine(GetRequestOtazky11("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/11.txt"));
        StartCoroutine(GetRequestOtazky12("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/12.txt"));
        StartCoroutine(GetRequestOtazky13("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/13.txt"));
        StartCoroutine(GetRequestOtazky14("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/14.txt"));
        StartCoroutine(GetRequestOtazky15("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/15.txt"));
        StartCoroutine(GetRequestOtazky16("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/16.txt"));
        StartCoroutine(GetRequestOtazky17("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/17.txt"));
        StartCoroutine(GetRequestOtazky18("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/18.txt"));
        StartCoroutine(GetRequestOtazky19("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/19.txt"));
        StartCoroutine(GetRequestOtazky20("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/20.txt"));
        StartCoroutine(GetRequestOtazky21("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/21.txt"));
        StartCoroutine(GetRequestOtazky22("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/22.txt"));
        StartCoroutine(GetRequestOtazky23("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/23.txt"));
        StartCoroutine(GetRequestOtazky24("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/24.txt"));
        StartCoroutine(GetRequestOtazky25("https://zuzana.pythonanywhere.com/download?path=predmety/otazky/25.txt"));


    }

    IEnumerator GetRequestOtazky1(string uri)
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
            lines1 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other1.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }

    IEnumerator GetRequestOtazky2(string uri)
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
            lines2 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other2.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky3(string uri)
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
            lines3 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other3.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky4(string uri)
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
            lines4 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other4.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky5(string uri)
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
            lines5 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other5.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky6(string uri)
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
            lines6 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other6.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky7(string uri)
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
            lines7 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other7.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky8(string uri)
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
            lines8 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other8.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky9(string uri)
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
            lines9 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other9.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky10(string uri)
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
            lines10 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other10.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky11(string uri)
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
            lines11 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other11.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky12(string uri)
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
            lines12 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other12.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky13(string uri)
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
            lines13 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other13.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky14(string uri)
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
            lines14 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other14.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky15(string uri)
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
            lines15 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other15.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky16(string uri)
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
            lines16 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other16.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky17(string uri)
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
            lines17 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other17.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky18(string uri)
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
            lines18 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other18.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky19(string uri)
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
            lines19 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other19.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky20(string uri)
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
            lines20 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other20.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky21(string uri)
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
            lines21 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other21.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky22(string uri)
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
            lines22 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other22.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky23(string uri)
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
            lines23 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other23.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky24(string uri)
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
            lines24 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other24.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
    IEnumerator GetRequestOtazky25(string uri)
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
            lines25 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            string[] split0 = webRequest.downloadHandler.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                other25.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
            }
        }
    }
}
