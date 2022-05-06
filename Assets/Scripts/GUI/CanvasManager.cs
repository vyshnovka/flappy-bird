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
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        count = PlayerPrefs.GetInt("Count", 1);

        Time.timeScale = 0;
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
                SceneLoader.Load(1);
            }
            else
            {
                SceneLoader.Load(0);
            }
        }
        else
        {
            SceneLoader.Load(0);
        }
    }
}
