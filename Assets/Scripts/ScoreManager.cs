using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI titleText;
    public int score = 0;
    public string[] titles;
    public int[] _stages;
    private int x;

    public static ScoreManager instance;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        AdjustTitle(0);
        Debug.Log("scoremanager at start");

    }

    public void Awake()
    {
        instance = this;
    }

    public void AddPoint(int value)
    {
        score+=value;
        scoreText.text = "Score: " + score.ToString();
        AdjustTitle(score);
        Debug.Log("Scoremanager Added Point");
    }

    private void AdjustTitle(int score)
    {
        Debug.Log("adjusted title");


        for (int i = 0; i < _stages.Length; i++)
        {
            if (score> _stages[i] && score < _stages[i + 1])
            {
                titleText.text = "Title: " + titles[i];
            }
        }
    }

       
    }
