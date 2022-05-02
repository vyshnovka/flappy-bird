using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject resetButton;
    [SerializeField]
    private Text scoreText;

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
        Time.timeScale = 0;
    }

    public void ShowRestartUI()
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
        resetButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
