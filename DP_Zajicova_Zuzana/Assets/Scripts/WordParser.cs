using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordParser : MonoBehaviour
{

    public static List<Word> words0 = new List<Word>();
    public static List<Word> words1 = new List<Word>();
    public static List<Word> words2= new List<Word>();
    public static List<Word> words3 = new List<Word>();
    public static List<Word> words4 = new List<Word>();
    public static List<Word> words5 = new List<Word>();
    public static List<Word> words6 = new List<Word>();
    public static List<Word> words7 = new List<Word>();
    public static List<Word> words8 = new List<Word>();
    public static List<Word> words9 = new List<Word>();


    public void Start()
    {

         //Vyjmenovaná slova B
       
            TextAsset asset0 = Resources.Load("B") as TextAsset;
            string[] split0 = asset0.text.Split('\n');
            foreach (string line in split0)
            {
                string[] tmp = line.Split(',');
                words0.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "y" : "i") });
            }
        

        //Vyjmenovaná slova L
        
            TextAsset asset1 = Resources.Load("L") as TextAsset;
            string[] split1 = asset1.text.Split('\n');
            foreach (string line in split1)
            {
                string[] tmp = line.Split(',');
                words1.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "y" : "i") });
            }
        

        //Vyjmenovaná slova M
        
            TextAsset asset2 = Resources.Load("M") as TextAsset;
            string[] split2 = asset2.text.Split('\n');
            foreach (string line in split2)
            {
                string[] tmp = line.Split(',');
                words2.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "y" : "i") });
            }
        


        //Vyjmenovaná slova P
      
            TextAsset asset3 = Resources.Load("P") as TextAsset;
            string[] split3 = asset3.text.Split('\n');
            foreach (string line in split3)
            {
                string[] tmp = line.Split(',');
                words3.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "y" : "i") });
            }
        

        //Vyjmenovaná slova S
       
            TextAsset asset4 = Resources.Load("S") as TextAsset;
            string[] split4 = asset4.text.Split('\n');
            foreach (string line in split4)
            {
                string[] tmp = line.Split(',');
                words4.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "y" : "i") });
            }
        

        //Vyjmenovaná slova V
       
            TextAsset asset5 = Resources.Load("V") as TextAsset;
            string[] split5 = asset5.text.Split('\n');
            foreach (string line in split5)
            {
                string[] tmp = line.Split(',');
                words5.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "y" : "i") });
            }
        

        //Vyjmenovaná slova Z
       
            TextAsset asset6 = Resources.Load("Z") as TextAsset;
            string[] split6 = asset6.text.Split('\n');
            foreach (string line in split6)
            {
                string[] tmp = line.Split(',');
                words6.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "y" : "i") });
            }
        



        //tvrdé, měkké souhlásky
       
            TextAsset asset7 = Resources.Load("tvrde_mekke") as TextAsset;
            string[] split7 = asset7.text.Split('\n');
            foreach (string line in split7)
            {
                string[] tmp = line.Split(',');
                words7.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "y" : "i") });
            }
        


        //  s/z
        
            TextAsset asset8 = Resources.Load("SZ") as TextAsset;
            string[] split8 = asset8.text.Split('\n');
            foreach (string line in split8)
            {
                string[] tmp = line.Split(',');
                words8.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "z" : "s") });
            }
        

        //mix
        
            TextAsset asset9 = Resources.Load("words") as TextAsset;
            string[] split9 = asset9.text.Split('\n');
            foreach (string line in split9)
            {
                string[] tmp = line.Split(',');
                words9.Add(new Word() { word = tmp[1], correctString = (tmp[0] == "2" ? "y" : "i") });
            }
    
    }


    public void Update()
    {
 
    }

}