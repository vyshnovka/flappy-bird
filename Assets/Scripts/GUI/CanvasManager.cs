using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject resetButton;
    [SerializeField]
    private Text scoreText;

    private int count;

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
        count = PlayerPrefs.GetInt("Count", 1);

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
            PlayerPrefs.SetInt("Count", count + 1);

            if (count >= 5)
            {
                SceneLoader.Load("Monologue");
            }
            else
            {
                SceneLoader.Load("Gameplay");
            }
        }
        else
        {
            SceneLoader.Load("Gameplay");
        }
    }
}
