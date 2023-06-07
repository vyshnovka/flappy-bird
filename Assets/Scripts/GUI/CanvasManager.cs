using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    [Header("UI elements")]
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject resetButton;
    [SerializeField]
    private Text scoreText;

    [Header("Games played before the monologue")]
    [SerializeField]
    private int min;
    [SerializeField]
    private int max;

    private int gamesCount;
    private int gamesToPlay;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }

        instance = this;
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("GamesToPlay"))
        {
            PlayerPrefs.SetInt("GamesToPlay", Random.Range(min, max));
        }

        gamesToPlay = PlayerPrefs.GetInt("GamesToPlay", -1);
        gamesCount = PlayerPrefs.GetInt("Count", 1);

        Time.timeScale = 0;

        AudioController.instance.SetVolume(0f);
    }

    public void ShowRestartButton()
    {
        Time.timeScale = 0;

        scoreText.gameObject.SetActive(false);
        resetButton.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;

        AudioController.instance.SetVolume(1f);
        AudioController.instance.PlayTap();

        playButton.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        if (PlayerPrefs.GetInt("Decision", 0) == 0)
        {
            if (gamesCount >= gamesToPlay)
            {
                SceneLoader.Load("Monologue");
            }
            else
            {
                gamesCount++;
                PlayerPrefs.SetInt("Count", gamesCount);

                SceneLoader.Load("Gameplay");
            }
        }
        else
        {
            SceneLoader.Load("Gameplay");
        }
    }
}
