using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MathParser : MonoBehaviour
{

    public static List<Word> number = new List<Word>();
    public static List<Word> number2 = new List<Word>();


    public void Start()
    {
        //naèíst txt numbers, uložit správné odpovìdi
        TextAsset asset = Resources.Load("numbers") as TextAsset;
        string[] split = asset.text.Split('\n');
        foreach (string line in split)
        {
            string[] tmp = line.Split(',');
            number.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "n" : "a") });
        }


        TextAsset asset0 = Resources.Load("numbers_dopln") as TextAsset;
        string[] split0 = asset0.text.Split('\n');
        foreach (string line in split0)
        {
            string[] tmp = line.Split(',');
            number2.Add(new Word() { word = tmp[1], correctString = (tmp[0]) });
        }

    }

}