using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public static Score score_;

    // zobrazení score
    void Start()

    {
        score_ = this;
        score = 0;
        scoreText.text = "Poèet bodù: " + score;
    }

    void Update()
    {
        scoreText.text = "Poèet bodù: " + score;
    }


}
