using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Your Score Is: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Your Score Is: " + score;
    }

    public void incrementScore()
    {
        score += 1;
        Debug.Log("incrementing score " + score);
    }
}
