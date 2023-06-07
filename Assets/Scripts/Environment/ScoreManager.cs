using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;

    [SerializeField]
    private Text scoreText;

    void Start()
    {
        score = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
