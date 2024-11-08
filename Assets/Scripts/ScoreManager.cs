using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI titleText;
    public int score = 0;
    public string[] titles;
    public int[] _stages;

    public static ScoreManager instance;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        AdjustTitle(0);

    }

    public void Awake()
    {
        instance = this;
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        AdjustTitle(score);
    }

    private void AdjustTitle(int score)
    {
        int x = 0;
        while(x> _stages.Length)
        {
            if (score >= _stages[x])
            {
                titleText.text = "Title: " + titles[x];
                x = _stages.Length + 1;
            }
            else
            {
                x++;
            }
        }

       
    }
}
