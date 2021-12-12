using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    private int score;
    public Text scoreText;

    void Start()
    {
        score = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObstaclePassed"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
